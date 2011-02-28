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
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Security;
using CodeOwls.PowerShell.Host;
using CodeOwls.PowerShell.WinForms.Configuration;
using CodeOwls.PowerShell.WinForms.Utility;

namespace CodeOwls.PowerShell.WinForms.Host
{
    class HostUI : PSHostUserInterface
    {
        private readonly PSTextBox _control;
        private readonly UISettings _settings;
        private PSHostRawUserInterface _rawUI;

        public event EventHandler<ProgressRecordEventArgs> Progress;

        public HostUI( PSTextBox control, UISettings settings, PSHostRawUserInterface rawUi)
        {
            _control = control;
            _settings = settings;
            _rawUI = rawUi;
        }

        public override string ReadLine()
        {
            _control.WritePrompt(String.Empty);
            _control.CommandEnteredEvent.WaitOne();
            return _control.ReadLine();
        }

        public override SecureString ReadLineAsSecureString()
        {
            return ReadLineAsSecureString(_settings.ForegroundColor, _settings.BackgroundColor);
        }

        public override void Write(string value)
        {
            
            _control.WriteLine( value );
        }

        public override void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
        {
            Color fg = Adapt(foregroundColor, _settings.ForegroundColor);
            Color bg = Adapt(backgroundColor, _settings.BackgroundColor);

            _control.Write(value, fg, bg);
        }

        private Color Adapt(ConsoleColor consoleColor, Color @default)
        {
            return ColorAdapter.Adapt(consoleColor, @default);
        }

        public override void WriteLine(string value)
        {
            _control.WriteLine(value);
        }

        public override void WriteErrorLine(string message)
        {
            _control.WriteLine(message, FontStyle.Bold, _settings.ErrorForegroundColor, _settings.ErrorBackgroundColor );
        }

        public override void WriteDebugLine(string value)
        {
            _control.WriteLine(value, FontStyle.Bold, _settings.DebugForegroundColor, _settings.DebugBackgroundColor);
        }

        public override void WriteProgress(long sourceId, ProgressRecord record)
        {
            var ev = Progress;
            if( null == ev )
            {
                return;
            }

            ev( this, new ProgressRecordEventArgs( sourceId, record ));
        }

        public override void WriteVerboseLine(string message)
        {
            _control.WriteLine(message, FontStyle.Bold, _settings.VerboseForegroundColor, _settings.VerboseBackgroundColor);
        }

        public override void WriteWarningLine(string message)
        {

            _control.WriteLine(message, FontStyle.Bold, _settings.WarningForegroundColor, _settings.WarningBackgroundColor);
        }

        public override Dictionary<string, PSObject> Prompt(string caption, string message, Collection<FieldDescription> descriptions)
        {
            _control.WriteLine( String.Empty );
            _control.WriteLine(caption);
            _control.WriteLine( message );

            var results = new Dictionary<string, PSObject>();

            descriptions.ToList().ForEach(
                d=>
                    {
                        var prompt = (d.Label + ": ").Replace("&", String.Empty);
                        _control.WritePrompt(prompt);
                        _control.CommandEnteredEvent.WaitOne();

                        results[ d.Name ] = _control.ReadLine().Trim().ToPSObject();
                    }
                );

            return results;
        }

        public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName)
        {
            return PromptForCredential(caption, message, userName, targetName, PSCredentialTypes.Default,
                                PSCredentialUIOptions.Default);
        }

        public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName, PSCredentialTypes allowedCredentialTypes, PSCredentialUIOptions options)
        {
            try
            {
                if (_settings.PromptForCredentialsInConsole)
                {
                    return PromptForCredentialFromConsole(caption, message, userName, targetName, allowedCredentialTypes,
                                                          options);
                }
            }
            catch 
            {
            }

            IntPtr handle = _control.GetSafeWindowHandle();
            return NativeUtils.CredUIPromptForCredential(
                caption, 
                message, 
                userName, 
                targetName, 
                allowedCredentialTypes,
                options, 
                handle);
        }

        private PSCredential PromptForCredentialFromConsole(string caption, string message, string userName, string targetName, PSCredentialTypes allowedCredentialTypes, PSCredentialUIOptions options)
        {
            var style = _control.Font.Style;
            _control.WriteLine( caption, style, _settings.WarningForegroundColor, _settings.WarningBackgroundColor );
            _control.WriteLine( message, style, _settings.WarningForegroundColor, _settings.WarningBackgroundColor);

            var baseMoniker = String.IsNullOrEmpty(targetName) ? "{1}" : "{0}\\{1}";
            
            var moniker = String.Format(baseMoniker, targetName, userName);
            var prompt = "Password for user " + moniker + ": ";
            _control.WritePrompt(prompt, _settings.WarningForegroundColor, _settings.WarningBackgroundColor);

            var pwd = ReadLineAsSecureString(_settings.WarningForegroundColor, _settings.WarningBackgroundColor);

            return new PSCredential( moniker, pwd );
        }

        public override int PromptForChoice(string caption, string message, Collection<ChoiceDescription> choices, int defaultChoice)
        {
            _control.WriteLine(caption, FontStyle.Bold, _settings.WarningForegroundColor, _settings.WarningBackgroundColor);
            _control.WriteLine(message, FontStyle.Bold, _settings.ForegroundColor, _settings.BackgroundColor);
                        
            while (true)
            {
                int choiceIndex = 0;
                string defaultChoicePrompt = String.Empty;
                List<char> hotkeys = new List<char>();    
                choices.ToList().ForEach(
                    choice =>
                        {
                            var index = choice.Label.IndexOf('&') + 1;
                            if( -1 == index || index > ( choice.Label.Length - 1 ) )
                            {
                                return;
                            }
                            var c = choice.Label.ToUpperInvariant()[index];
                            hotkeys.Add( c );

                            Color color = _settings.ForegroundColor;
                            Color back = _settings.BackgroundColor;

                            if (choiceIndex == defaultChoice)
                            {
                                color = _settings.WarningForegroundColor;
                                back = _settings.WarningBackgroundColor;
                                defaultChoicePrompt = String.Format(" (default is \"{0}\")", c);
                            }
                                
                            _control.Write(
                                String.Format("[{0}]", c),
                                color,
                                _control.BackColor);

                            _control.Write(String.Format(" {0}  ", choice.Label.Replace("&", String.Empty)), color, back);
                            ++choiceIndex;
                        }
                );

                _control.WritePrompt(String.Format(" [?] Help{0}:", defaultChoicePrompt), _settings.ForegroundColor, _settings.BackgroundColor);

                _control.CommandEnteredEvent.WaitOne();

                var line = _control.ReadLine().Trim();
                if( line.Length == 0)
                {
                    if (-1 == defaultChoice)
                    {
                        continue;
                    }
                    return defaultChoice;
                }

                char charChoice = line.ToUpperInvariant()[0];
                
                if( '?' == charChoice )
                {
                    choices.ToList().ForEach(
                    choice => _control.WriteLine(
                                  String.Format(
                                      " {0} - {1}",
                                      choice.Label.Replace("&", String.Empty),
                                      choice.HelpMessage)
                                  ));
                    continue;
                }

                choiceIndex = hotkeys.IndexOf(charChoice);
                if( -1 == choiceIndex )
                {
                    continue;
                }
                return choiceIndex;
            }
        }

        public override PSHostRawUserInterface RawUI
        {
            get { 
                return _rawUI;
            }
        }

        SecureString ReadLineAsSecureString( Color foreground, Color background )
        {
            _control.IsInputEntryModeEnabled = false;
            try
            {
                SecureString str = new SecureString();

                KeyInfo keyInfo;
                char[] eol = new[] {'\r', '\n'};
                while ( !eol.Contains( (keyInfo = _control.ReadNextKey()).Character) )
                {
                    str.AppendChar(keyInfo.Character);
                    _control.Write("*", foreground, background);
                }
                str.MakeReadOnly();
                
                return str;
            }
            finally
            {
                _control.IsInputEntryModeEnabled = true;
                _control.WritePrompt(String.Empty);
                _control.WriteLine(String.Empty);
                _control.ReadLine();
            }
        }

    }
}