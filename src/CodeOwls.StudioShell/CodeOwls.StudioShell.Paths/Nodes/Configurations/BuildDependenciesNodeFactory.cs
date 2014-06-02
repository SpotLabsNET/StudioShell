using System.Collections.Generic;
using CodeOwls.PowerShell.Provider.PathNodes;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes.Configurations
{
    internal class BuildDependenciesNodeFactory : CollectionNodeFactoryBase
    {
        private readonly BuildDependencies _buildDependencies;

        public BuildDependenciesNodeFactory(BuildDependencies buildDependencies)
        {
            _buildDependencies = buildDependencies;
        }

        public override IEnumerable<INodeFactory> GetNodeChildren(PowerShell.Provider.PathNodeProcessors.IContext context)
        {
            var nodes = new List<INodeFactory>();
            foreach (BuildDependency dependency in _buildDependencies)
            {
                var node = new BuildDependencyNodeFactory(dependency);
                nodes.Add(node);
            }

            return nodes;
        }
        public override string Name
        {
            get { return "Dependencies"; }
        }
    }
}