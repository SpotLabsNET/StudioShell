using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeOwls.PowerShell.Provider.PathNodes;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Nodes
{
    public class PropertyNodeFactory : NodeFactoryBase
    {
        private readonly Property _property;

        public PropertyNodeFactory(Property property)
        {
            _property = property;
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode( _property, Name, false );
        }

        public override string Name
        {
            get { return _property.Name; }
        }
    }
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
            return factories;
        }
        public override IPathNode GetNodeValue()
        {
            return new PathNode( _configuration, Name, true );
        }

        public override string Name
        {
            get { return _configuration.ConfigurationName; }
        }
    }

    public class ConfigurationsCollectionNodeFactory : CollectionNodeFactoryBase
    {
        private readonly Project _project;


        public ConfigurationsCollectionNodeFactory( Project project )
        {
            _project = project;
        }

        public override IEnumerable<INodeFactory> GetNodeChildren(PowerShell.Provider.PathNodeProcessors.IContext context)
        {
            List<INodeFactory> factories = new List<INodeFactory>();
            foreach (Configuration configuration in _project.ConfigurationManager)
            {
                var factory = new ConfigurationNodeFactory(configuration);
                factories.Add( factory );
            }
            return factories;
        }

        public override string Name
        {
            get { return "Configurations"; }
        }
    }
}
