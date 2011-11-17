using System.Collections.Generic;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Paths.Items;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes.CodeModel
{
    public class ProjectCodeModelNodeFactory : NodeFactoryBase
    {
        private readonly EnvDTE.CodeModel _codeModel;

        public ProjectCodeModelNodeFactory(EnvDTE.CodeModel codeModel)
        {
            _codeModel = codeModel;
        }

        public override string Name
        {
            get { return "CodeModel"; }
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode(new ShellContainer(this), Name, true);
        }

        public override IEnumerable<INodeFactory>  GetNodeChildren( IContext context )
        {
            foreach (CodeElement e in _codeModel.CodeElements)
            {
                var factory = FileCodeModelNodeFactory.CreateNodeFactoryFromCodeElement(e);
                yield return factory;
            }
        }
    }
}