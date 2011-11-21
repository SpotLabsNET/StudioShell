﻿using System;
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