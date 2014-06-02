using System.Collections;
using System.Collections.Generic;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Paths.Items.Configurations;
using CodeOwls.StudioShell.Paths.Nodes.ProjectModel;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes.Configurations
{
    class BuildDependencyNodeFactory : NodeFactoryBase
    {
        private readonly BuildDependency _dependency;

        public BuildDependencyNodeFactory(BuildDependency dependency)
        {
            _dependency = dependency;
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode( new ShellBuildDependency(_dependency), Name, true );
        }

        public override IEnumerable<INodeFactory> GetNodeChildren(PowerShell.Provider.PathNodeProcessors.IContext context)
        {
            var nodes = new List<INodeFactory>();
            foreach (object project in (IEnumerable) _dependency.RequiredProjects)
            {
                nodes.Add( ProjectNodeFactory.Create(project) );
            }

            return nodes;
        }

        public override string Name
        {
            get { return _dependency.Project.Name; }
        }
    }
}