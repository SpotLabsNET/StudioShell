using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using CodeOwls.PowerShell.Paths.Processors;
using CodeOwls.StudioShell.Common.Configuration;
using EnvDTE80;

namespace CodeOwls.StudioShell.Provider
{
    public class DTEDrive : CodeOwls.PowerShell.Provider.Drive
    {
        private readonly DTE2 _dte;

        public DTEDrive(PSDriveInfo driveInfo, DTE2 dte) : base(driveInfo)
        {
            _dte = dte;
            PathTopologyVersion = DefaultPathTopologyVersion;
        }

        public Version DefaultPathTopologyVersion
        {
            get { return SettingsManager.Settings.DefaultPathTopologyVersion; }
        }
        
        public Version PathTopologyVersion { get; set; }

        internal DTE2 ApplicationObject
        {
            get { return _dte; }
        }
    }
}
