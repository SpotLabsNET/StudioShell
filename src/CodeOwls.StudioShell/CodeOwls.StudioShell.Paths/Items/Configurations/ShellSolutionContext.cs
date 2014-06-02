using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Items.Configurations
{
    public class ShellSolutionContext
    {
        private readonly SolutionContext _context;

        public ShellSolutionContext(SolutionContext context)
        {
            _context = context;
        }

        public string ProjectName
        {
            get { return _context.ProjectName; }
        }

        public string ConfigurationName
        {
            get { return _context.ConfigurationName; }
            set { _context.ConfigurationName = value; }
        }

        public string PlatformName
        {
            get { return _context.PlatformName; }
        }

        public bool ShouldBuild
        {
            get { return _context.ShouldBuild; }
            set { _context.ShouldBuild = value; }
        }

        public bool ShouldDeploy
        {
            get { return _context.ShouldDeploy; }
            set { _context.ShouldDeploy = value; }
        }
    }
}