using System.Collections.Generic;
using CodeOwls.PowerShell.Provider.PathNodes;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes.Configurations
{
    internal class SolutionConfigurationsNodeFactory : CollectionNodeFactoryBase
    {
        private readonly SolutionConfigurations _solutionConfigurations;

        public SolutionConfigurationsNodeFactory(SolutionConfigurations solutionConfigurations)
        {
            _solutionConfigurations = solutionConfigurations;
        }
       
        public override IEnumerable<INodeFactory> GetNodeChildren(PowerShell.Provider.PathNodeProcessors.IContext context)
        {
            var nodes = new List<INodeFactory>();
            foreach (SolutionConfiguration configuration in _solutionConfigurations)
            {
                nodes.Add( new SolutionConfigurationNodeFactory( configuration ));
            }
            return nodes;
        }

        public override string Name
        {
            get { return "Configurations";  }
        }
    }
}