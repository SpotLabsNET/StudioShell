using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Paths.Items.Configurations;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes
{
    public class PropertyNodeFactory : NodeFactoryBase, ISetItem
    {
        private readonly Property _property;

        public PropertyNodeFactory(Property property)
        {
            _property = property;
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode( new ShellConfigurationProperty(_property), Name, false );
        }

        public override string Name
        {
            get { return _property.Name; }
        }

        public object SetItemParameters { get; private set; }
        public IPathNode SetItem(IContext context, string path, object value)
        {
            _property.Value = value;

            return GetNodeValue();
        }
    }
}