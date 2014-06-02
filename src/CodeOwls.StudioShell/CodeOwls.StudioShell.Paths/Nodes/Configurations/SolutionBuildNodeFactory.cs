using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Paths.Items.Configurations;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Nodes.Configurations
{
    class SolutionBuildNodeFactory : NodeFactoryBase
    {
        private readonly SolutionBuild _build;

        public SolutionBuildNodeFactory(SolutionBuild build)
        {
            _build = build;
        }

        public override IEnumerable<INodeFactory> GetNodeChildren(PowerShell.Provider.PathNodeProcessors.IContext context)
        {
            List<INodeFactory> nodes = new List<INodeFactory>();
            nodes.Add( new BuildDependenciesNodeFactory( _build.BuildDependencies ));
            nodes.Add( new SolutionConfigurationsNodeFactory( _build.SolutionConfigurations ));
            var projectNames = _build.StartupProjects as object[];

            nodes.Add( new SolutionStartupProjectsNodeFactory( (DTE2) _build.DTE, projectNames));
            return nodes;
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode( new ShellSolutionBuild( _build ),Name,true);
        }

        public override string Name
        {
            get { return "Build"; }
        }
    }
}
