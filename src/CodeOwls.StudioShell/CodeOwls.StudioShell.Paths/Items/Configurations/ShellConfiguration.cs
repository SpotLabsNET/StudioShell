using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Items.Configurations
{
    public class ShellConfiguration
    {
        private readonly Configuration _configuration;

        public ShellConfiguration(Configuration configuration)
        {
            _configuration = configuration;
        }

        public string ConfigurationName
        {
            get { return _configuration.ConfigurationName; }
        }

        public string PlatformName
        {
            get { return _configuration.PlatformName; }
        }

        public vsConfigurationType Type
        {
            get { return _configuration.Type; }
        }

        public object Owner
        {
            get { return _configuration.Owner; }
        }

        public Properties Properties
        {
            get { return _configuration.Properties; }
        }

        public bool IsBuildable
        {
            get { return _configuration.IsBuildable; }
        }

        public bool IsRunable
        {
            get { return _configuration.IsRunable; }
        }

        public bool IsDeployable
        {
            get { return _configuration.IsDeployable; }
        }

        public OutputGroups OutputGroups
        {
            get { return _configuration.OutputGroups; }
        }

        public object Object
        {
            get { return _configuration.Object; }
        }
    }
}
