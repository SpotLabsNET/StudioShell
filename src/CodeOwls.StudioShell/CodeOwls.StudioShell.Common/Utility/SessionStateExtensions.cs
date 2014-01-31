using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace CodeOwls.StudioShell.Common.Utility
{
    public static class SessionStateExtensions
    {
        public static Runspace GetRunspace(this SessionState sessionState)
        {
            var results = sessionState.InvokeCommand.InvokeScript("$host.runspace");
            if (null == results || ! results.Any())
            {
                return null;
            }
            var runspace = results.First().BaseObject as Runspace;
            if (null == runspace)
            {
                return null;
            }
            return runspace;
        }
    }
}
