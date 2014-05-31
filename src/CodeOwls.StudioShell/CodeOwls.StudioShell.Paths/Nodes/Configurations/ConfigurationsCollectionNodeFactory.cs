using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeOwls.PowerShell.Host.Configuration;
using CodeOwls.PowerShell.Provider.PathNodes;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Nodes
{
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
