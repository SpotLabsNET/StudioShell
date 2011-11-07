﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Provider;
using System.Text;
using CodeOwls.PowerShell.Paths.Processors;
using CodeOwls.StudioShell.Common.IoC;
using CodeOwls.StudioShell.Common.Utility;
using CodeOwls.StudioShell.Provider.Variables;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Provider
{
    [CmdletProvider("PSDTE", ProviderCapabilities.ShouldProcess)]
    public class DTEProvider : CodeOwls.PowerShell.Provider.Provider
    {
        private DTEDrive DTEDrive
        {
            get
            {
                var drive = PSDriveInfo as DTEDrive;

                if (null == drive)
                {
                    drive = ProviderInfo.Drives.FirstOrDefault() as DTEDrive;
                }

                return drive;
            }
        }

        private static DTE2 DTE2
        {
            get { return Locator.Get<DTE2>(); }
        }

        protected override IPathNodeProcessor PathNodeProcessor
        {
            get { return new PathNodeProcessor( DTE2 ); }
        }

        protected override ProviderInfo Start(ProviderInfo providerInfo)
        {
            ConfigureRunspace( this.SessionState );

            return base.Start(providerInfo);
        }

        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            return new DTEDrive(drive, PathNodeProcessor, DTE2 );
        }

        protected override Collection<PSDriveInfo> InitializeDefaultDrives()
        {
            return new Collection<PSDriveInfo>(
                new List<PSDriveInfo>
                    {
                        new DTEDrive(
                            new PSDriveInfo("DTE", ProviderInfo, "dte:/", "DTE Drive", null),
                            PathNodeProcessor,
                            DTE2
                            )
                    }
                );
        }

        void ConfigureRunspace(SessionState sessionState)
        {
            PSVariable[] psv = GetStudioShellPSVariables();

            psv.ToList().ForEach(sessionState.PSVariable.Set);
        }

        private static DTEEventSource EventSource;

        private PSVariable[] GetStudioShellPSVariables()
        {
            var dte2 = DTEProvider.DTE2;
            var events = dte2.Events as Events2;
            if (null == EventSource)
            {
                EventSource = new DTEEventSource(events);
            }

            return new PSVariable[]
	                   {
	                       new PSVariable("dte", dte2),

                           // adding each individual event container as a unique variable seems silly,
                           //   but it is apparantly necessary to have the types recognized as event-supporting
                           //   .NET COM wrappers in the powershell session
                           new PSVariable("events", events),
	                       new PSVariable("solutionEvents", EventSource.SolutionEvents as SolutionEvents),
	                       new PSVariable("selectionEvents", EventSource.SelectionEvents as SelectionEvents),
                           new PSVariable( "projectEvents", EventSource.ProjectEvents as ProjectsEvents ),
                           new PSVariable( "projectItemEvents", EventSource.ProjectItemsEvents as ProjectItemsEvents ),
                           new PSVariable( "buildEvents", EventSource.BuildEvents),
                           new PSVariable("debuggerEvents", EventSource.DebuggerEvents),
                           new PSVariable("debuggerProcessEvents", EventSource.DebuggerProcessEvents),
                           new PSVariable("debuggerExpressionEvaluationEvents", EventSource.DebuggerExpressionEvaluationEvents),
                           new PSVariable("dteEvents", EventSource.DteEvents),
                           new PSVariable("findEvents", EventSource.FindEvents),
                           new PSVariable("miscFilesEvents", EventSource.MiscFileEvents),
                           new PSVariable("publishEvents", EventSource.PublishEvents),
                           new PSVariable("solutionItemsEvents", EventSource.SolutionItemEvents),
                           
	                       new ActiveWindowVariable(dte2, "activeWindow"),
	                       new SelectedProjectItems(dte2, "selectedProjectItems"),
	                       new SelectedProjects(dte2, "selectedProjects"),
	                       new CurrentDebugModeVariable(dte2),
	                       new CurrentProcessVariable(dte2),
	                       new CurrentStackFrameVariable(dte2),
	                       new CurrentThreadVariable(dte2),
	                       new SelectedCodeElementVariable(dte2, "selectedClass", vsCMElement.vsCMElementClass),
                           new SelectedCodeElementVariable(dte2, "selectedMethod", vsCMElement.vsCMElementFunction),
                           new SelectedCodeElementVariable(dte2, "selectedProperty", vsCMElement.vsCMElementProperty),
                           new SelectedCodeElementVariable(dte2, "selectedNamespace", vsCMElement.vsCMElementNamespace),
	                   };
        }

    }
}