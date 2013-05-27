using System;
using System.Collections.Generic;
using System.Linq;
using CodeOwls.PowerShell.Host.Exceptions;

namespace CodeOwls.PowerShell.Host.Configuration
{
    public class UnsupportedConsoleApplicationConfiguration 
    {
        public UnsupportedConsoleApplicationConfiguration( 
            IEnumerable<string> unsupportedConsoleApplications,
            string variableName,
            string helpTopicName )
        {
            UnsupportedConsoleApplications = unsupportedConsoleApplications;
            UnsupportedConsoleApplicationsVariableName = variableName;
            UnsupportedConsoleApplicationsHelpTopicName = helpTopicName;

            AssertInvariant();
        }

        public UnsupportedConsoleApplicationConfiguration()
        {
            UnsupportedConsoleApplications = new List<string>();
        }

        public IEnumerable<string> UnsupportedConsoleApplications { get; set; }
        public string UnsupportedConsoleApplicationsVariableName { get; private set; }
        public string UnsupportedConsoleApplicationsHelpTopicName { get; private set; }

        public bool IsUnsupportedConsoleApplication(string script, out Exception e)
        {
            e = null;
            if (null == UnsupportedConsoleApplications || ! UnsupportedConsoleApplications.Any() )
            {
                return false;
            }

            if (UnsupportedConsoleApplications.Contains(
                script.Trim(),
                StringComparer.InvariantCultureIgnoreCase
                ))
            {

                e = new NotSupportedException(
                    String.Format(
@"The application ""{0}"" cannot be started because it is in the list of unsupported applications for this host.
To view or modify the list of unsupported applications for this host, see the ${1} variable, or type ""get-help {2}"".
Alternatively, you may try running the application as a unique process using the Start-Process cmdlet.",
                        script,
                        UnsupportedConsoleApplicationsVariableName,
                        UnsupportedConsoleApplicationsHelpTopicName)
                    );
                return true;
            }

            return false;
        }

        void AssertInvariant()
        {
            if (null == UnsupportedConsoleApplications ||
                ! UnsupportedConsoleApplications.Any())
            {
                return;
            }

            if (null != UnsupportedConsoleApplications &&
                UnsupportedConsoleApplications.Any() &&
                ! String.IsNullOrEmpty(UnsupportedConsoleApplicationsVariableName) &&
                ! String.IsNullOrEmpty(UnsupportedConsoleApplicationsHelpTopicName)
                )
            {
                return;
            }

            throw new InvalidUnsupportedConsoleConfigurationException(
                "If you define one or more unsupported console applications, you must also define an unsupported console application variable name and help topic"    
            );
        }
    }
}