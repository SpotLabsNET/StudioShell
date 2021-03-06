using System.Management.Automation.Provider;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;

namespace CodeOwls.PowerShell.Provider.PathNodes
{
    public interface IGetItemContent
    {
        IContentReader GetContentReader(IContext context);
        object GetContentReaderDynamicParameters(IContext context);
    }
}