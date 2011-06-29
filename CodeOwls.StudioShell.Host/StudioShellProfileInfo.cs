using CodeOwls.PowerShell.Host.Utility;

namespace CodeOwls.StudioShell.Host
{
    public class StudioShellProfileInfo : ProfileInfo
    {
        public StudioShellProfileInfo() : base(StudioShellInfo.ShellId, StudioShellInfo.InstallationPath)
        {
        }
    }
}