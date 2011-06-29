using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeOwls.StudioShell.Common.Utility
{
    public class EventArgs<T> : System.EventArgs
    {
        public EventArgs( T t )
        {
            Data = t;
        }

        public T Data { get; private set; }
    }
}
