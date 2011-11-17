using System.Collections.Generic;
using CodeOwls.PowerShell.Provider.Attributes;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Nodes.ProjectModel
{
    [CmdletHelpPathID("SolutionCodeModel")]
    public class SolutionCodeModelNodeFactory : SolutionProjectsNodeFactory
    {
        public SolutionCodeModelNodeFactory(DTE2 dte) : base( dte )
        {
        }

        public override string Name
        {
            get { return "codemodel"; }
        }

        public override IEnumerable<INodeFactory> GetNodeChildren(IContext context)
        {
            var factories = new List<INodeFactory>();
            foreach (Project project in _dte.Solution.Projects)
            {
                factories.Add(new ProjectCodeModelNodeFactory(project));
            }
            return factories;
        }
    }
}