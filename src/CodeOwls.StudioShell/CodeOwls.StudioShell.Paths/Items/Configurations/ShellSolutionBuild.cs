using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Items.Configurations
{
    public class ShellSolutionBuild
    {
        private readonly SolutionBuild _build;

        public ShellSolutionBuild(SolutionBuild build)
        {
            _build = build;
        }

        public void Build(bool WaitForBuildToFinish = false)
        {
            _build.Build(WaitForBuildToFinish);
        }

        public void Debug()
        {
            _build.Debug();
        }

        public void Deploy(bool WaitForDeployToFinish = false)
        {
            _build.Deploy(WaitForDeployToFinish);
        }

        public void Clean(bool WaitForCleanToFinish = false)
        {
            _build.Clean(WaitForCleanToFinish);
        }

        public void Run()
        {
            _build.Run();
        }

        public void BuildProject(string SolutionConfiguration, string ProjectUniqueName, bool WaitForBuildToFinish = false)
        {
            _build.BuildProject(SolutionConfiguration, ProjectUniqueName, WaitForBuildToFinish);
        }

        public Solution Parent
        {
            get { return _build.Parent; }
        }

        public SolutionConfiguration ActiveConfiguration
        {
            get { return _build.ActiveConfiguration; }
        }

        public vsBuildState BuildState
        {
            get { return _build.BuildState; }
        }

        public int LastBuildInfo
        {
            get { return _build.LastBuildInfo; }
        }
    }
}
