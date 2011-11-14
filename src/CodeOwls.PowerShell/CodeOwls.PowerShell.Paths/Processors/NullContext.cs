﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security.AccessControl;
using System.Text;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;

namespace CodeOwls.PowerShell.Paths.Processors
{
    public class NullContext : IContext
    {
        public static readonly IContext Instance = new NullContext();
        
        public PSDriveInfo Drive
        {
            get { return null; }
        }

        public string GetResourceString(string baseName, string resourceId)
        {
            return null;
        }

        public void ThrowTerminatingError(ErrorRecord errorRecord)
        {
        }

        public bool ShouldProcess(string target)
        {
            return false;
        }

        public bool ShouldProcess(string target, string action)
        {
            return false;
        }

        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption)
        {
            return false;
        }

        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption, out ShouldProcessReason shouldProcessReason)
        {
            shouldProcessReason = ShouldProcessReason.None;
            return false;
        }

        public bool ShouldContinue(string query, string caption)
        {
            return false;
        }

        public bool ShouldContinue(string query, string caption, ref bool yesToAll, ref bool noToAll)
        {
            return false;
        }

        public bool TransactionAvailable()
        {
            return false;
        }

        public void WriteVerbose(string text)
        {
        }

        public void WriteWarning(string text)
        {
        }

        public void WriteProgress(ProgressRecord progressRecord)
        {
        }

        public void WriteDebug(string text)
        {
        }

        public void WriteItemObject(object item, string path, bool isContainer)
        {
        }

        public void WritePropertyObject(object propertyValue, string path)
        {
        }

        public void WriteSecurityDescriptorObject(ObjectSecurity securityDescriptor, string path)
        {
        }

        public void WriteError(ErrorRecord errorRecord)
        {
        }

        public bool Stopping
        {
            get { return false; }
        }

        public SessionState SessionState
        {
            get { return null; }
        }

        public ProviderIntrinsics InvokeProvider
        {
            get { return null; }
        }

        public CommandInvocationIntrinsics InvokeCommand
        {
            get { return null; }
        }

        public PSCredential Credential
        {
            get { return null; }
        }

        public bool Force
        {
            get { return true; }
        }

        public bool Recurse
        {
            get { return false; }
        }

        public string Filter
        {
            get { return null; }
        }

        public IEnumerable<string> Include
        {
            get { return null; }
        }

        public IEnumerable<string> Exclude
        {
            get { return null; }
        }

        public object DynamicParameters
        {
            get { return null; }
        }

        public IPathNodeProcessor PathProcessor
        {
            get { return null; }
        }
    }
}
