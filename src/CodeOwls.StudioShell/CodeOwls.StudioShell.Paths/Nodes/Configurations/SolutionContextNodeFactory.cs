using System.Globalization;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Paths.Items.Configurations;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes.Configurations
{
    internal class SolutionContextNodeFactory : NodeFactoryBase
    {
        private readonly SolutionContext _solutionContext;
        private readonly int _index;

        public SolutionContextNodeFactory(SolutionContext solutionContext, int index)
        {
            _solutionContext = solutionContext;
            _index = index;
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode( new ShellSolutionContext(_solutionContext), Name, false);
        }

        public override string Name
        {
            get { return _index.ToString(CultureInfo.InvariantCulture); }
        }
    }
}