using System.Collections;
using System.IO;
using System.Management.Automation.Provider;
using System.Text;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes
{
    class TextSelectionContentWriter : IContentWriter
    {
        private readonly StringBuilder _builder;
        private readonly TextSelection _selection;

        public TextSelectionContentWriter(TextSelection selection)
        {
            _selection = selection;
            _builder = new StringBuilder();
        }

        public void Dispose()
        {
        }

        public IList Write(IList content)
        {
            foreach (string o in content)
            {
                _builder.AppendLine(o);
            }
            return content;
        }

        public void Seek(long offset, SeekOrigin origin)
        {
        }

        public void Close()
        {
            _selection.Text = _builder.ToString();
        }
    }
}