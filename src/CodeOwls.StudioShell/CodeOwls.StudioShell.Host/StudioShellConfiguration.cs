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
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using CodeOwls.PowerShell.Host.Configuration;

namespace CodeOwls.StudioShell.Host
{
    public class StudioShellConfiguration : ShellConfiguration
    {
        public StudioShellConfiguration( UISettings uiSettings )
        {            
            var profileScripts = new StudioShellProfileInfo();
            var newProfile = profileScripts.GetProfilePSObject();
            var runspaceConfiguration = RunspaceConfiguration.Create();
            var cce = new List<CmdletConfigurationEntry>();
            var initialVariables = new List<PSVariable>();

            runspaceConfiguration.InitializationScripts.Append(
                new ScriptConfigurationEntry("start-studioshell", Scripts.StartStudioShell)
            );

            initialVariables.Add(new PSVariable("profile", newProfile));

            ShellName = StudioShellInfo.ShellName;
            ShellVersion = StudioShellInfo.ShellVersion;
            Cmdlets = cce;
            InitialVariables = initialVariables;
            RunspaceConfiguration = runspaceConfiguration;
            UISettings = uiSettings;
        }
    }
}
