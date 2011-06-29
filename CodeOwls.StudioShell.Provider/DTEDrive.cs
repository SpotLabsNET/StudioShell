using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using CodeOwls.PowerShell.Paths.Processors;
using EnvDTE80;

namespace CodeOwls.StudioShell.Provider
{
    public class DTEDrive : CodeOwls.PowerShell.Provider.Drive
    {
        private readonly DTE2 _dte;

        public DTEDrive(PSDriveInfo driveInfo, IPathNodeProcessor pathProcessor, DTE2 dte) : base(driveInfo, pathProcessor)
        {
            _dte = dte;
        }

        internal DTE2 ApplicationObject
        {
            get { return _dte; }
        }
    }
}
