using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation.Provider;

namespace CodeOwls.StudioShell.Paths.Nodes
{
    class StringContentReader : IContentReader
    {
        private readonly Queue<string> _text;

        public StringContentReader(string text )
        {
            var lines = text.Split(new[]{"\r\n"}, StringSplitOptions.None);
            _text = new Queue<string>(lines);
        }

        public void Dispose()
        {
        }

        public IList Read(long readCount)
        {
            ArrayList lines = new ArrayList();
            while (0 <= --readCount && _text.Any())
            {
                lines.Add(_text.Dequeue());
            }
            return lines;
        }

        public void Seek(long offset, SeekOrigin origin)
        {            
        }

        public void Close()
        {         
        }
    }
}