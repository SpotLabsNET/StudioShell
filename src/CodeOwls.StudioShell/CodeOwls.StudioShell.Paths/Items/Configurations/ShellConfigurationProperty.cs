using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Items.Configurations
{
    public class ShellConfigurationProperty
    {
        private readonly Property _property;

        public ShellConfigurationProperty(Property property)
        {
            _property = property;
        }
        
        public object Value
        {
            get { return _property.Value; }
            set { _property.Value = value; }
        }

        public string Name
        {
            get { return _property.Name; }
        }

        public object Object
        {
            get { return _property.Object; }
            set { _property.Object = value; }
        }        
    }
}