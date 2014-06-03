using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Items.Configurations
{
    public class ShellBuildDependency
    {
        private readonly BuildDependency _dependency;

        public ShellBuildDependency(BuildDependency dependency)
        {
            _dependency = dependency;
        }

        public void AddProject(string ProjectUniqueName)
        {
            _dependency.AddProject(ProjectUniqueName);
        }

        public void RemoveProject(string ProjectUniqueName)
        {
            _dependency.RemoveProject(ProjectUniqueName);
        }

        public void RemoveAllProjects()
        {
            _dependency.RemoveAllProjects();
        }

        public Project Project
        {
            get { return _dependency.Project; }
        }

        public string Name
        {
            get { return Project.Name; }
        }

        public object RequiredProjects
        {
            get { return _dependency.RequiredProjects; }
        }
    }
}