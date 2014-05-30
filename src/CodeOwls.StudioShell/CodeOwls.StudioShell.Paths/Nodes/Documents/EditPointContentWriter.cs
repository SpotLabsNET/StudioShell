using System.Collections;
using System.IO;
using System.Management.Automation.Provider;
using System.Text;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes
{
    class EditPointContentWriter : IContentWriter
    {
        private readonly EditPoint _editPoint;
        private readonly TextPoint _endPoint;
        private readonly StringBuilder _builder;

        public EditPointContentWriter(EditPoint editPoint, TextPoint endPoint)
        {
            _editPoint = editPoint;
            _endPoint = endPoint;
            _builder = new StringBuilder();
        }

        public void Dispose()
        {
        }

        public IList Write(IList content)
        {
            foreach (string line in content)
            {
                _builder.AppendLine(line);
            }
            return content;
        }

        public void Seek(long offset, SeekOrigin origin)
        {
        }

        public void Close()
        {
            _editPoint.ReplaceText(_endPoint, _builder.ToString().TrimEnd('\r','\n'), (int)vsEPReplaceTextOptions.vsEPReplaceTextAutoformat);   
        }
    }
}