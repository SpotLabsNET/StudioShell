using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation.Provider;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Paths.Items.ShellDocuments;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes
{
    public class DocumentNodeFactory : NodeFactoryBase, IInvokeItem, IRemoveItem, IClearItem, IGetItemContent, ISetItemContent
    {
        private readonly Document _document;
        private readonly TextDocument _textDocument;
        private readonly string _nodeName;

        public DocumentNodeFactory( Document document )
        {
            _document = document;
            _textDocument = document.Object("TextDocument") as TextDocument;
        }

        public DocumentNodeFactory(Document document, string nodeName )
        {
            _document = document;
            _nodeName = nodeName;
            _textDocument = document.Object("TextDocument") as TextDocument;
        }

        public override IPathNode GetNodeValue()
        {

            return new PathNode( new ShellDocument(_document), Name, false );
        }

        public override string Name
        {
            get { return _nodeName ?? _document.Name; }
        }

        public object InvokeItemParameters { get; private set; }
        public IEnumerable<object> InvokeItem(IContext context, string path)
        {
            _document.Activate();
            return null;
        }

        public object RemoveItemParameters { get; private set; }
        public void RemoveItem(IContext context, string path, bool recurse)
        {
            _document.Close();
        }

        public object ClearItemDynamicParamters { get; private set; }
        public void ClearItem(IContext context, string path)
        {
            var selection = _document.Selection as TextSelection;
            if (null == selection)
            {
                return;
            }

            selection.SelectAll();
            selection.Text = string.Empty;
        }

        public IContentReader GetContentReader(IContext context)
        {
            var selection = _textDocument.Selection;
            var currentPoint = selection.AnchorPoint.LineCharOffset;
            selection.StartOfDocument();

            return new TextSelectionContentReader( selection, currentPoint );
        }

        public object GetContentReaderDynamicParameters(IContext context)
        {
            return null;
        }

        public IContentWriter GetContentWriter(IContext context)
        {
            var selection = _textDocument.Selection;
            selection.EndOfDocument();
            selection.StartOfDocument(true);
            selection.Text = "";
            return new TextSelectionContentWriter( selection );
        }

        public object GetContentWriterDynamicParameters(IContext context)
        {
            return null;
        }
    }
}