using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Items.Configurations
{
    public class ShellSolutionConfiguration
    {
        private readonly SolutionConfiguration _configuration;

        public ShellSolutionConfiguration(SolutionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Delete()
        {
            _configuration.Delete();
        }

        public void Activate()
        {
            _configuration.Activate();
        }

        public string Name
        {
            get { return _configuration.Name; }
        }
    }
}