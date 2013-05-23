using System;
using System.Collections.Generic;
using System.Linq;
using CodeOwls.PowerShell.Host.Executors;
using CodeOwls.PowerShell.Host.Utility;

namespace CodeOwls.PowerShell.Host.AutoComplete
{
    internal class PowerShellTabExpansion2AutoCompleteProvider : IAutoCompleteProvider
    {
        private bool? _enabled; 
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
            if (! _enabled.HasValue)
            {
                InitializeEnabled();
            }

            if (! _enabled.Value )
            {
                return new string[] {};
            }

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

        private void InitializeEnabled()
        {
            Exception error;
            bool enabled;
            var result = _executor.ExecuteAndGetStringResult("test-path function:/tabexpansion2", out error);
            if (null != error)
            {
                _enabled = false;
                return;
            }
            
            bool.TryParse(result, out enabled);
            _enabled = enabled;
        }
    }
}