using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.StudioShell.Paths.Nodes
{
    class RenamedNodeFactoryDecorator : INodeFactory
    {
        private readonly INodeFactory _factory;
        private readonly string _name;

        public RenamedNodeFactoryDecorator(INodeFactory factory, string name )
        {
            _factory = factory;
            _name = name;
        }

        public IEnumerable<INodeFactory> Resolve(IContext context, string name)
        {
            return _factory.Resolve(context, name);
        }

        public IPathNode GetNodeValue()
        {
            return _factory.GetNodeValue();
        }

        public IEnumerable<INodeFactory> GetNodeChildren(IContext context)
        {
            return _factory.GetNodeChildren(context);
        }

        public object GetNodeChildrenParameters
        {
            get { return _factory.GetNodeChildrenParameters; }
        }

        public string Name
        {
            get { return _name ?? _factory.Name; }
        }

        public string ItemMode
        {
            get { return _factory.ItemMode; }
        }
    }
}
