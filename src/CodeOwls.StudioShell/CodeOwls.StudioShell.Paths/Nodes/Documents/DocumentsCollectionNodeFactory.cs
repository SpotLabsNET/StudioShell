using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeOwls.PowerShell.Provider.PathNodes;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Nodes
{
    public class DocumentsCollectionNodeFactory : CollectionNodeFactoryBase
    {
        private readonly DTE2 _dte;

        public DocumentsCollectionNodeFactory( DTE2 dte )
        {
            _dte = dte;
        }

        public override IEnumerable<PowerShell.Provider.PathNodes.INodeFactory> GetNodeChildren(PowerShell.Provider.PathNodeProcessors.IContext context)
        {
            List<INodeFactory> documents = new List<INodeFactory>();
            foreach (Document document in _dte.Documents)
            {
                var node = new DocumentNodeFactory(document);
                documents.Add(node);
            }
            return documents;
        }

        public override string Name
        {
            get { return "Documents"; }
        }
    }
}
