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
using System.Linq;
using System.Text.RegularExpressions;
using CodeOwls.PowerShell.Host.Executors;
using CodeOwls.PowerShell.Host.Utility;

namespace CodeOwls.PowerShell.Host.AutoComplete
{
    
    internal class PowerShellTabExpansion2AutoCompleteProvider : IAutoCompleteProvider
    {
        private readonly Executor _executor;
        private const string TabExpansionScript = @"TabExpansion2 -input '{0}' -cur {1} | foreach {{
        $i = $_.replacementindex;
        $_.completionmatches | foreach {{
            '{0}'.substring(0,$i) + $_.completiontext;
        }}
    }}";

        private const string TabExpansionFunctionName = "TabExpansion2";
        private const string InputParameterName = "InputScript";
        private const string CursorPositionParameterName = "CursorColumn";

        public PowerShellTabExpansion2AutoCompleteProvider( Executor executor )
        {
            _executor = executor;
        }

        public IEnumerable<string> GetSuggestions(string guess)
        {
            guess = ( guess ?? String.Empty ).Replace( "'", "`'");
            
            try
            {
                var script = String.Format(TabExpansionScript, guess, guess.Length);
                Exception error;
                var results = _executor.ExecuteCommand(script, null, out error,
                                                       ExecutionOptions.None);
                if (null == results)
                {
                    return new string[] { };
                }
               
                return results.ToList().ConvertAll(pso => pso.ToStringValue());
            }
            catch
            {
            }
            return null;
            
        }
    }

    internal class PowerShellTabExansionAutoCompleteProvider : IAutoCompleteProvider
    {
        private const string TabExpansionFunctionName = "TabExpansion";
        private const string LineArgumentName = "line";
        private const string LastWordArgumentName = "lastWord";
        private readonly Executor _executor;

        public PowerShellTabExansionAutoCompleteProvider(Executor executor)
        {
            _executor = executor;
        }

        #region IAutoCompleteProvider Members

        public IEnumerable<string> GetSuggestions(string guess)
        {
            try
            {
                Dictionary<string, object> arguments = SplitGuessIntoArguments(guess);
                Exception error;
                var results = _executor.ExecuteCommand(TabExpansionFunctionName, arguments, out error,
                                                       ExecutionOptions.None);
                if (null == results)
                {
                    return new string[] {};
                }

                return results.ToList().ConvertAll(pso => pso.ToStringValue());
            }
            catch
            {
            }
            return null;
        }

        #endregion

        private Dictionary<string, object> SplitGuessIntoArguments(string guess)
        {
            Dictionary<string, object> args = new Dictionary<string, object>();
            args.Add(LineArgumentName, guess);
            //todo: add more logic to split, handle quotations
            var lastWord = Regex.Split(guess, @"\s+").LastOrDefault();
            args.Add(LastWordArgumentName, lastWord);
            return args;
        }
    }
}
