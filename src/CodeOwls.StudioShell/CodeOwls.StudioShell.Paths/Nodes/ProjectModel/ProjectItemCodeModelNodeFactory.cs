using System.Collections.Generic;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Paths.Nodes.CodeModel;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes.ProjectModel
{
    class ProjectItemCodeModelNodeFactory : ProjectItemNodeFactory
    {
        public ProjectItemCodeModelNodeFactory(ProjectItem item) : base(item)
        {
        }
        public override IEnumerable<INodeFactory> GetNodeChildren(IContext context)
        {
            List<INodeFactory> factories = new List<INodeFactory>();
            if (null != _item.FileCodeModel)
            {
                var cm = new FileCodeModelNodeFactory(_item.FileCodeModel);
                factories.AddRange( cm.GetNodeChildren( context ) );
            }
            return factories;
        }
    }
}