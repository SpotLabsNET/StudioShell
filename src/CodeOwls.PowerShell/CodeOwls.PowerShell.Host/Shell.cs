/*
   Copyright (c) 2011 Code Owls LLC, All Rights Reserved.

   Licensed under the Microsoft Reciprocal License (Ms-RL) (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.opensource.org/licenses/ms-rl

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Threading;
using CodeOwls.PowerShell.Host.AutoComplete;
using CodeOwls.PowerShell.Host.Configuration;
using CodeOwls.PowerShell.Host.Console;
using CodeOwls.PowerShell.Host.Executors;
using CodeOwls.PowerShell.Host.History;
using CodeOwls.PowerShell.Host.Host;
using CodeOwls.PowerShell.Host.Utility;

namespace CodeOwls.PowerShell.Host
{
    public class Shell : AsyncCommandExecutorBase, IRunnableCommandExecutor
    {
        private readonly IConsole _consoleWindow;
        private readonly ShellConfiguration _shellConfiguration;
        private AutoCompleteWalker _autoCompleteWalker;
        private Executor _commandExecutor;
        private HistoryStackWalker _historyStackWalker;
        private Host.Host _host;
        private HostUI _hostUi;
        private HostRawUI _rawUi;
        private Runspace _runspace;
        private bool _disposed;
        private Thread _thread;
        private readonly ManualResetEvent _threadStopEvent;

        public Shell(IConsole consoleWindow, ShellConfiguration shellConfiguration)
        {
            _threadStopEvent = new ManualResetEvent(false);
            _consoleWindow = consoleWindow;
            _shellConfiguration = shellConfiguration;
        }

        public void Dispose()
        {
            if( _disposed )
            {
                return;
            }
            _disposed = true;
            _threadStopEvent.Set();                                    
        }

        #region IRunnableCommandExecutor Members

        public override bool CancelCurrentExecution(int timeoutInMilliseconds)
        {
            return _commandExecutor.CancelCurrentPipeline(
                timeoutInMilliseconds,
                RaiseCommandCancelTimeoutEvent
            );
        }

        public void Stop()
        {
            Stop(false);
        }

        public void Stop(bool force)
        {
            var thread = _thread;
            _host.SetShouldExit(0);

            if (force)
            {
                if (null != thread)
                {
                    if (!thread.Join(2500))
                    {
                        thread.Abort();
                        thread.Join(5000);
                    }
                }
            }
        }

        public void Run()
        {
            var thread = new Thread(_Run);

            var existing = Interlocked.CompareExchange(ref _thread, thread, null);
            if (null != existing)
            {
                return;
            }

            StartupState state = new StartupState();
            thread.SetApartmentState(ApartmentState.MTA);
            thread.IsBackground = true;
            thread.Start(state);
            state.WaitForStartup();
        }

        public override CommandExecutorState CurrentState
        {
            get
            {
                return _runspace.RunspaceAvailability == RunspaceAvailability.Available
                           ? CommandExecutorState.Available
                           : CommandExecutorState.Unavailable;
            }
        }

        #endregion

        public event EventHandler<ExitEventArgs> ShouldExit;
        public event EventHandler<ProgressRecordEventArgs> Progress;
        public event EventHandler<EventArgs<bool>> CommandExecutionStateChange;
        public event EventHandler CommandCancelTimeout;

        private void InvokeShouldExit(int exitCode)
        {
            EventHandler<ExitEventArgs> handler = ShouldExit;
            if (handler != null)
            {
                handler(this, new ExitEventArgs(exitCode));
            }
        }

        private void _Run(object o)
        {
            try
            {
                StartupState state = (StartupState) o;

                try
                {
                    InitializeRunspaceAndHost();
                }
                catch (Exception ex)
                {
                    state.SetComplete(ex);
                    return;
                }

                state.SetComplete(null);

                RunProfileScripts();
                RunInitializationScripts();

                ExecuteRunLoop();
            }
            catch (ThreadAbortException)
            {
            }
            finally
            {
                Interlocked.Exchange(ref _thread, null);
            }
        }

        private void ExecuteRunLoop()
        {
            var autoCompleteProviders = new List<IAutoCompleteProvider>
                                            {
                                                new AutoCompleteProviderChain(
                                                    new PowerShellTabExpansion2AutoCompleteProvider(_commandExecutor),
                                                    new PowerShellTabExpansionAutoCompleteProvider(_commandExecutor),
                                                    new CompositeAutoCompleteProvider(
                                                        new ProviderPathAutoCompleteProvider(_commandExecutor),
                                                        new CommandListAutoCompleteProvider(_commandExecutor)
                                                        )
                                                    )
                                            };

            _autoCompleteWalker = new AutoCompleteWalker(autoCompleteProviders);
            _historyStackWalker = new HistoryStackWalker(_commandExecutor);

            _consoleWindow.AutoCompleteWalker = _autoCompleteWalker;
            _consoleWindow.HistoryStackWalker = _historyStackWalker;

            WritePrompt();

            while (true)
            {
                WaitHandle[] handles = new[]
                                           {
                                               _host.ExitWaitHandle,
                                               _consoleWindow.CommandEnteredEvent,
                                               Queue.WaitHandle,
                                               _threadStopEvent
                                           }.ToList().Where( f=>f != null).ToArray();

                int index = WaitHandle.WaitAny(handles);
                switch (index)
                {
                    case (0):
                        InvokeShouldExit(_host.ExitCode);       
                        _host.ResetExitState();                        
                        break;
                    case (1):
                        ExecuteConsoleCommand();
                        break;
                    case (2):
                        ExecuteQueuedCommand();
                        break;
                    case( 3 ):
                        _runspace.Dispose();
                        _threadStopEvent.Close();
                        return;

                    default:
                        break;
                }
            }
        }

        private void ExecuteQueuedCommand()
        {
            this._commandExecutor.RunspaceReady.WaitOne();

            var asynResult = Queue.Dequeue();
            Collection<PSObject> results = null;
            try
            {
                results = ExecuteCommand(asynResult.Command, asynResult.Parameters, asynResult.ExecutionOptions);
                asynResult.SetComplete(results, false, null);
            }
            catch (Exception e)
            {
                asynResult.SetComplete(results, false, e);
            }
        }

        private Collection<PSObject> ExecuteCommand(string command, Dictionary<string, object> parameters, ExecutionOptions executionOptions)
        {
            Exception e;
            var r = ExecuteCommand(command, parameters, executionOptions, out e);
            if( null != e )
            {
                throw e;
            }
            return r;
        }

        private void ExecuteConsoleCommand()
        {
            this._commandExecutor.RunspaceReady.WaitOne();

            _historyStackWalker.Reset();
            _autoCompleteWalker.Reset();

            var input = _consoleWindow.ReadLine();
            Exception e;

            ExecuteCommand(input, ExecutionOptions.AddToHistory | ExecutionOptions.AddOutputter, out e);
            if( e is IncompleteParseException )
            {
                var lastInput = "+";
                while (e is IncompleteParseException)
                {
                    WritePrompt(">> ");
                    _consoleWindow.CommandEnteredEvent.WaitOne();
                    lastInput = _consoleWindow.ReadLine();
                    if( String.IsNullOrEmpty( lastInput ))
                    {
                        ExecuteCommand(input, ExecutionOptions.AddToHistory | ExecutionOptions.AddOutputter, out e);
                    }

                    input += Environment.NewLine + lastInput;
                }
            }

            WritePrompt();
        }

        private void WritePrompt()
        {
            this._commandExecutor.RunspaceReady.WaitOne(); 
            Exception error;
            var prompt = _commandExecutor.ExecuteAndGetStringResult("prompt", out error) ?? String.Empty;
            prompt = prompt.Trim(); 
            WritePrompt(prompt);
        }

        private void WritePrompt(string prompt)
        {
            if (String.IsNullOrEmpty(prompt))
            {
                return;
            }
            
            _consoleWindow.WritePrompt(prompt);
        }

        private Collection<PSObject> ExecuteCommand(string input, ExecutionOptions executionOptions, out Exception error)
        {
            error = null;
            var onx = CommandExecutionStateChange;
            if (null != onx)
            {
                onx(this, new EventArgs<bool>(true));
            }

            var results = _commandExecutor.ExecuteCommand(
                input,
                out error,
                executionOptions
                );

            if (null != onx)
            {
                onx(this, new EventArgs<bool>(false));
            }
            return results;
        }


        private Collection<PSObject> ExecuteCommand(string command, Dictionary<string, object> arguments,
                                                    ExecutionOptions options, out Exception error)
        {
            error = null;
            var onx = CommandExecutionStateChange;
            if (null != onx)
            {
                onx(this, new EventArgs<bool>(true));
            }

            var results = _commandExecutor.ExecuteCommand(
                command,
                arguments,
                out error,
                options
                );

            if (null != onx)
            {
                onx(this, new EventArgs<bool>(false));
            }
            return results;
        }

        private void InitializeRunspaceAndHost()
        {
            if (null == _shellConfiguration.RunspaceConfiguration)
            {
                _shellConfiguration.RunspaceConfiguration = RunspaceConfiguration.Create();
            }

            _shellConfiguration.Cmdlets.ToList().ForEach(
                cce => _shellConfiguration.RunspaceConfiguration.Cmdlets.Append(cce)
                );

            _rawUi = new HostRawUI(_consoleWindow, _shellConfiguration.ShellName);
            _hostUi = new HostUI(_consoleWindow, _shellConfiguration.UISettings, _rawUi);
            _host = new Host.Host(_shellConfiguration.ShellName, _shellConfiguration.ShellVersion, _hostUi,
                                           _shellConfiguration.RunspaceConfiguration);

            _hostUi.Progress += NotifyProgress;

            _runspace = _host.Runspace;
            _runspace.Open();

            _commandExecutor = new Executor(_runspace);
            _commandExecutor.PipelineException += OnPipelineException;


            _shellConfiguration.InitialVariables.ToList().ForEach(pair =>
                                                                  _runspace.SessionStateProxy.PSVariable.Set(pair)
                );
        }

        private void OnPipelineException(object sender, EventArgs<Exception> e)
        {
            //_host.UI.WriteErrorLine(e.Data.ToString());
        }

        private void NotifyProgress(object sender, ProgressRecordEventArgs e)
        {
            var ev = Progress;
            if (null == ev)
            {
                return;
            }

            ev(sender, e);
        }

        private void RunProfileScripts()
        {
            if (null == _shellConfiguration.ProfileScripts)
            {
                return;
            }

            foreach (var entry in _shellConfiguration.ProfileScripts.InRunOrder)
            {
                var fileInfo = new FileInfo(entry);
                if (! fileInfo.Exists)
                {
                    continue;
                }

                Exception error;
                _commandExecutor.ExecuteCommand(fileInfo.ToDotSource(), out error, ExecutionOptions.AddOutputter);
            }
        }

        private void RunInitializationScripts()
        {
            if (null == _shellConfiguration.RunspaceConfiguration.InitializationScripts)
            {
                return;
            }

            foreach (ScriptConfigurationEntry entry in _shellConfiguration.RunspaceConfiguration.InitializationScripts)
            {
                Exception error;
                _commandExecutor.ExecuteCommand(entry.Definition, out error, ExecutionOptions.AddOutputter);
            }
        }

        void RaiseCommandCancelTimeoutEvent()
        {
            var ev = CommandCancelTimeout;
            if( null != ev )
            {
                ev(this, EventArgs.Empty);
            }
        }
        #region Nested type: StartupState

        private class StartupState
        {
            private readonly ManualResetEvent _complete;
            private Exception _exception;

            public StartupState()
            {
                _complete = new ManualResetEvent(false);
            }

            public Exception WaitForStartup()
            {
                _complete.WaitOne(1000);
                return _exception;
            }

            public void SetComplete(Exception e)
            {
                _exception = e;
                _complete.Set();
            }
        }

        #endregion
    }
}
