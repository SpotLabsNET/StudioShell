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
using System.Management.Automation;
using System.Security.AccessControl;
using CodeOwls.PowerShell.Paths.Processors;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.PowerShell.Provider.PathNodeProcessors
{
    public interface IContext
    {
        PSDriveInfo Drive { get; }
        string GetResourceString(string baseName, string resourceId);
        void ThrowTerminatingError(ErrorRecord errorRecord);
        bool ShouldProcess(string target);
        bool ShouldProcess(string target, string action);
        bool ShouldProcess(string verboseDescription, string verboseWarning, string caption);
        bool ShouldProcess(string verboseDescription, string verboseWarning, string caption, out ShouldProcessReason shouldProcessReason);
        bool ShouldContinue(string query, string caption);
        bool ShouldContinue(string query, string caption, ref bool yesToAll, ref bool noToAll);
        bool TransactionAvailable();
        void WriteVerbose(string text);
        void WriteWarning(string text);
        void WriteProgress(ProgressRecord progressRecord);
        void WriteDebug(string text);
        void WriteItemObject(object item, string path, bool isContainer);
        void WritePropertyObject(object propertyValue, string path);
        void WriteSecurityDescriptorObject(ObjectSecurity securityDescriptor, string path);
        void WriteError(ErrorRecord errorRecord);
        bool Stopping { get; }
        INodeFactory ResolvePath(string path);
        SessionState SessionState { get; }
        ProviderIntrinsics InvokeProvider { get; }
        CommandInvocationIntrinsics InvokeCommand { get; }
        PSCredential Credential { get; }
        bool Force { get; }
        bool Recurse { get; }
        string Filter { get; }
        IEnumerable<string> Include { get; }
        IEnumerable<string> Exclude { get; }
        object DynamicParameters { get; }
        Version PathTopologyVersion { get; }
        string Path { get; }
    }
}
