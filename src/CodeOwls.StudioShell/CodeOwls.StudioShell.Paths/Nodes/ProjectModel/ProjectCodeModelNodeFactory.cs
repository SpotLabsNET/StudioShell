using System.Collections.Generic;
using CodeOwls.PowerShell.Provider.Attributes;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes.ProjectModel
{
    [CmdletHelpPathID("ProjectCodeModel")]
    public class ProjectCodeModelNodeFactory : ProjectNodeFactory
    {
        public ProjectCodeModelNodeFactory(Project project) : base(project)
        {
        }

        public override IEnumerable<INodeFactory> GetNodeChildren(IContext context)
        {
            foreach (ProjectItem item in _project.ProjectItems)
            {
                yield return new ProjectItemCodeModelNodeFactory(item);
            }
        }

    }
}