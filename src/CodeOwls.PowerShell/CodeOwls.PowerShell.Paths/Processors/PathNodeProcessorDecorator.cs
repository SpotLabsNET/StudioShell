using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.PowerShell.Paths.Processors
{
    public abstract class PathNodeProcessorDecorator : IPathNodeProcessor
    {
        private readonly IPathNodeProcessor _basePathNodeProcessor;

        public PathNodeProcessorDecorator(IPathNodeProcessor basePathNodeProcessor)
        {
            _basePathNodeProcessor = basePathNodeProcessor;
        }

        #region Implementation of IPathNodeProcessor

        public virtual INodeFactory ResolvePath( IContext context, string path)
        {
            return _basePathNodeProcessor.ResolvePath( context, path);
        }

        #endregion
    }
}