using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeOwls.StudioShell.Common.IoC
{
    public static class Locator
    {
        static Dictionary< string, object > _map = new Dictionary<string, object>();

        public static T Get<T>()
        {
            if( ! _map.ContainsKey( typeof(T).FullName ))
            {
                return default(T);
            }

            return (T) _map[typeof (T).FullName];
        }

        public static void Set<T>( T impl )
        {
            _map[typeof (T).FullName] = impl;
        }

        public static T GetService<T>()
        {
            IServiceProvider sp = Get<IServiceProvider>();
            if( null == sp )
            {
                return default(T);
            }
            return (T) sp.GetService(typeof (T));
        }
    }
}
