using System.Collections.Generic;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Paths.Nodes.ProjectModel;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Nodes.Configurations
{
    internal class SolutionStartupProjectsNodeFactory : CollectionNodeFactoryBase
    {
        private readonly DTE2 _dte;
        private readonly object[] _projects;

        public SolutionStartupProjectsNodeFactory(DTE2 dte, object[] projects)
        {
            _dte = dte;
            _projects = projects;
        }

        public override IEnumerable<INodeFactory> GetNodeChildren(PowerShell.Provider.PathNodeProcessors.IContext context)
        {
            var nodes = new List<INodeFactory>();
            foreach (var name in _projects)
            {
                var project = _dte.Solution.Projects.Item(name);
                nodes.Add( ProjectNodeFactory.Create(project));
            }
            return nodes;
        }
        public override string Name
        {
            get { return "StartupProjects"; }
        }
    }
}