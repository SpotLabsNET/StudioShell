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
    public class DocumentNodeFactory : NodeFactoryBase, IInvokeItem, IRemoveItem, IClearItem, IGetItemContent
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
            return new DocumentContentReader( selection );
        }

        public object GetContentReaderDynamicParameters(IContext context)
        {
            return null;
        }

        class DocumentContentReader : IContentReader
        {
            struct Point
            {
                public int Line;
                public int Char;
            }
            private readonly TextSelection _selection;
            private int _lineIndex;
            private readonly int _currentEditPoint;

            public DocumentContentReader(TextSelection selection)
            {
                _selection = selection;
                _currentEditPoint = _selection.AnchorPoint.AbsoluteCharOffset;
                _selection.StartOfDocument();
                _lineIndex = 0;
                
            }

            public void Dispose()
            {                
            }

            public IList Read(long readCount)
            {
                var lines = new ArrayList();
                while (0 <= --readCount && ! _selection.AnchorPoint.AtEndOfDocument)
                {
                    _selection.GotoLine(++_lineIndex, true); 
                    var text = _selection.Text;
                    lines.Add(text);
                }
                return lines;
            }

            public void Seek(long offset, SeekOrigin origin)
            {
                long lineNumber = offset;
                if (origin == SeekOrigin.Current)
                {
                    lineNumber += _selection.CurrentLine;
                }
                _selection.MoveToLineAndOffset( (int) lineNumber, 0, false );       
            }

            public void Close()
            {
                _selection.MoveToAbsoluteOffset(_currentEditPoint, false);
            }
        }
    }
}