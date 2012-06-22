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
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Threading;
using CodeOwls.PowerShell.Host.Utility;

namespace CodeOwls.PowerShell.Host.Executors
{
    internal class Executor
    {
        private readonly Runspace _runspace;
        private Pipeline _currentPipeline;

        public Executor(Runspace runspace)
        {
            _runspace = runspace;
        }

        private bool IsRunspaceBusy
        {
            get
            {
                return _runspace.RunspaceAvailability != RunspaceAvailability.Available;
            }
        }

        public event EventHandler<EventArgs<Exception>> PipelineException;

        public bool CancelCurrentPipeline(int timeoutInMilliseconds, Action pipelineCancelFailCallback )
        {
            var pipeline = _currentPipeline;
            var activeStates = new[] {PipelineState.Running, PipelineState.NotStarted, PipelineState.Stopping};
            var inactiveStates = new[] {PipelineState.Stopped, PipelineState.Failed, PipelineState.Completed};
            if (null != pipeline &&
                activeStates.Contains(pipeline.PipelineStateInfo.State))
            {
                Timer cancelTimer = null;
                TimerCallback callback = o =>
                                             {
                                                 try
                                                 {
                                                     pipelineCancelFailCallback();
                                                     cancelTimer.Change(-1, -1);
                                                     cancelTimer.Dispose();
                                                     cancelTimer = null;
                                                 }
                                                 catch
                                                 {

                                                 }
                                             };

                cancelTimer = new Timer( callback, null, 
                    TimeSpan.FromMilliseconds( timeoutInMilliseconds), TimeSpan.FromMilliseconds(-1));

                pipeline.StateChanged += (s, a) =>
                                             {
                                                 if( null != cancelTimer && 
                                                     inactiveStates.Contains(a.PipelineStateInfo.State) )
                                                 {
                                                     cancelTimer.Change(-1, -1);
                                                     cancelTimer.Dispose();
                                                     cancelTimer = null;
                                                 }
                                             };
                pipeline.StopAsync();
                //TODO: migrate to event-based timeout
                /*DateTime expiry = DateTime.Now + TimeSpan.FromMilliseconds(timeoutInMilliseconds);
                while (
                    (-1 == timeoutInMilliseconds || DateTime.Now <= expiry) &&
                    activeStates.Contains(pipeline.PipelineStateInfo.State))
                {
                    DoWait();
                }

                return inactiveStates.Contains(pipeline.PipelineStateInfo.State);*/
            }

            return true;
        }

        public string ExecuteAndGetStringResult(string command, out Exception exceptionThrown)
        {
            var results = ExecuteCommand(command, out exceptionThrown, ExecutionOptions.None);
            if (null != exceptionThrown)
            {
                return null;
            }

            if (null == results || ! results.Any())
            {
                return null;
            }

            PSObject pso = results[0];
            if (null == pso)
            {
                return String.Empty;
            }
            if (null == pso.BaseObject)
            {
                return pso.ToString();
            }
            return pso.BaseObject.ToString();
        }

        public Collection<PSObject> ExecuteCommand(string command, Dictionary<string, object> inputs,
                                                   out Exception error, ExecutionOptions options)
        {
            var isscript = null == inputs || !inputs.Any();
            var cmd = new Command(command, isscript, false);

            if (null != inputs && inputs.Any())
            {
                inputs.ToList().ForEach(pair =>
                    cmd.Parameters.Add(pair.Key, pair.Value));
            }

            var pipe = _runspace.CreatePipeline();

            pipe.Commands.Add(cmd);

            return ExecuteCommandHelper(pipe, out error, options);
        }

        public Collection<PSObject> ExecuteCommand(string command, out Exception error, ExecutionOptions options)
        {
            var pipe = _runspace.CreatePipeline(command,
                                                ExecutionOptions.None != (ExecutionOptions.AddToHistory & options));
            return ExecuteCommandHelper(pipe, out error, options);
        }

        private void RaisePipelineExceptionEvent(Exception e)
        {
            EventHandler<EventArgs<Exception>> handler = PipelineException;
            if (handler != null)
            {
                handler(this, new EventArgs<Exception>(e));
            }
        }

        private Collection<PSObject> ExecuteCommandHelper(Pipeline tempPipeline, out Exception exceptionThrown,
                                                          ExecutionOptions options)
        {
            exceptionThrown = null;
            Collection<PSObject> collection = null;
            ApplyExecutionOptionsToPipeline(options, tempPipeline);
            collection = ExecutePipeline(options, tempPipeline, collection, out exceptionThrown);
            return collection;
        }

        private static void ApplyExecutionOptionsToPipeline(ExecutionOptions options, Pipeline tempPipeline)
        {
            if ((options & ExecutionOptions.AddOutputter) != ExecutionOptions.None)
            {
                if (tempPipeline.Commands.Count == 1)
                {
                    tempPipeline.Commands[0].MergeMyResults(PipelineResultTypes.Error, PipelineResultTypes.Output);
                }
                var item = new Command("Out-Default", false, true);
                tempPipeline.Commands.Add(item);
            }
        }

        private Collection<PSObject> ExecutePipeline(ExecutionOptions options, Pipeline tempPipeline,
                                                     Collection<PSObject> collection, out Exception exceptionThrown)
        {
            exceptionThrown = null;
            try
            {
                bool acquired = Monitor.TryEnter(_runspace);
                if (! acquired)
                {
                    return null;
                }

                try
                {
                    _currentPipeline = tempPipeline;

                    Exception exception = null;
                    try
                    {
                        WaitWhileRunspaceIsBusy();

                        tempPipeline.StateChanged += OnPipelineStateChange;
                        try
                        {
                            ExecutePipeline(options, tempPipeline);
                        }
                        catch (PSInvalidOperationException ioe)
                        {                            
                            /*
                             * HACK: there seems to be some lag between the toggle of the runspace
                             * availability state and the clearing of the runspace's current
                             * pipeline state.  it's possible for the runspace to report it's available
                             * for use and then raise a PSInvalidOperationException indicating that another
                             * pipeline is currently executing.
                             * 
                             * This is a hacky way around the issue - wait 1/3 of a second for the 
                             * runspace state to clear and try again.
                             * 
                             * I've also tried adding a WaitWhilePipelineIsRunning method that spins
                             * on a DoWait while the pipeline is not in the completed or failed state;
                             * however this seems to slow the execution down considerably.  
                             */
                            if ( tempPipeline.PipelineStateInfo.State == PipelineState.NotStarted )
                            {
                                Thread.Sleep( 333 );
                                ExecutePipeline(options, tempPipeline);
                            }
                        }
                        tempPipeline.Input.Close();

                        // WaitWhilePipelineIsRunning(tempPipeline);                    

                        collection = tempPipeline.Output.ReadToEnd(); 
                        exception = GetPipelineError(options, tempPipeline);
                    }
                    catch( Exception e )
                    {
                        exception = e;
                    }
                    finally
                    {
                        _currentPipeline = null;
                    }

                    if (null != exception)
                    {
                        RaisePipelineExceptionEvent(exception);
                        exceptionThrown = exception;
                    }
                }
                finally
                {
                    Monitor.Exit(_runspace);
                }
            }
            catch (Exception exception)
            {
                exceptionThrown = exception;
            }
            return collection;
        }

        private static void ExecutePipeline(ExecutionOptions options, Pipeline tempPipeline)
        {
            //if (options.HasFlag(ExecutionOptions.Synchronous))
            //{
            //    tempPipeline.Invoke();
            //}
            //else
            {
                tempPipeline.InvokeAsync();
            }
        }

        public readonly ManualResetEvent RunspaceReady = new ManualResetEvent(false);
        private void OnPipelineStateChange(object sender, PipelineStateEventArgs e)
        {
            switch( e.PipelineStateInfo.State )
            {
                case( PipelineState.Completed ):
                case( PipelineState.Failed) :
                    {
                        ((Pipeline)sender).StateChanged -= OnPipelineStateChange;

                        RunspaceReady.Set();
                        break;
                    }
                case( PipelineState.Running):
                    {
                        RunspaceReady.Reset();
                        break;

                    }
                default:
                    break;
            }
        }

        private void WaitWhilePipelineIsRunning(Pipeline tempPipeline)
        {
            while( tempPipeline.PipelineStateInfo.State != PipelineState.Completed &&
                tempPipeline.PipelineStateInfo.State != PipelineState.Failed )
            {
                DoWait();
            }
        }

        private void WaitWhileRunspaceIsBusy()
        {
            while (IsRunspaceBusy)
            {
                DoWait();
            }
        }

        private void DoWait()
        {

        }

        private Exception GetPipelineError(ExecutionOptions options, Pipeline tempPipeline)
        {
            Exception pipelineException = null;

            if (null != tempPipeline.PipelineStateInfo.Reason)
            {
                return tempPipeline.PipelineStateInfo.Reason;
            }

            if ( 0 < tempPipeline.Error.Count)
            {
                var error = tempPipeline.Error.Read();
                pipelineException = error as Exception;
                if (null == pipelineException)
                {
                    pipelineException = ((ErrorRecord) error).Exception;
                }
            }

            if (null != pipelineException &&
                0 == (options & ExecutionOptions.AddOutputter))
            {
                throw pipelineException;
            }

            return pipelineException;
        }
    }
}
