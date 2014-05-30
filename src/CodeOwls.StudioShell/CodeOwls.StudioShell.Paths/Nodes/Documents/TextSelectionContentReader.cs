using System.Collections;
using System.IO;
using System.Management.Automation.Provider;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes
{
    class TextSelectionContentReader : IContentReader
    {        
        private readonly TextSelection _selection;
        private int _lineIndex;
        private readonly int _currentEditPoint;

        public TextSelectionContentReader(TextSelection selection) : this(selection, selection.AnchorPoint.LineCharOffset)
        {
        }

        public TextSelectionContentReader(TextSelection selection, int currentEditPoint)
        {
            _selection = selection;
            _currentEditPoint = currentEditPoint;
            _lineIndex = 0;
        }

        public void Dispose()
        {
        }

        public IList Read(long readCount)
        {
            var lines = new ArrayList();
            while (0 <= --readCount && !_selection.AnchorPoint.AtEndOfDocument)
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
            _selection.MoveToLineAndOffset((int)lineNumber, 0, false);
        }

        public void Close()
        {
            _selection.MoveToAbsoluteOffset(_currentEditPoint, false);
        }
    }
}
