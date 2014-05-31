using System;
using System.Collections.Generic;
using CodeOwls.PowerShell.Provider.PathNodes;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes
{
    public class ConfigurationNodeFactory : NodeFactoryBase
    {
        private readonly Configuration _configuration;

        public ConfigurationNodeFactory(Configuration configuration)
        {
            _configuration = configuration;
        }

        public override IEnumerable<INodeFactory> GetNodeChildren(PowerShell.Provider.PathNodeProcessors.IContext context)
        {
            List<INodeFactory> factories = new List<INodeFactory>();
            foreach (Property p in _configuration.Properties)
            {
                var factory = new PropertyNodeFactory(p);
                factories.Add(factory);
            }
            factories.Sort( (a,b)=> StringComparer.InvariantCultureIgnoreCase.Compare(a.Name, b.Name ) );
            return factories;
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode( new Items.Configurations.ShellConfiguration(_configuration), Name, true );
        }

        public override string Name
        {
            get { return String.Format( _configuration.PlatformName + "_" + _configuration.ConfigurationName); }
        }
    }
}