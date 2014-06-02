using System.Collections.Generic;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Paths.Items.Configurations;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes.Configurations
{
    internal class SolutionConfigurationNodeFactory : NodeFactoryBase
    {
        private readonly SolutionConfiguration _configuration;

        public SolutionConfigurationNodeFactory(SolutionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override IEnumerable<INodeFactory> GetNodeChildren(PowerShell.Provider.PathNodeProcessors.IContext context)
        {
            var nodes = new List<INodeFactory>();
            var index = 0;
            foreach (SolutionContext solutionContext in _configuration.SolutionContexts)
            {
                nodes.Add(new SolutionContextNodeFactory(solutionContext, ++index));
            }
            return nodes;
        }
        public override IPathNode GetNodeValue()
        {
            return new PathNode( new ShellSolutionConfiguration(_configuration), Name, true);
        }

        public override string Name
        {
            get { return _configuration.Name; }
        }
    }
}