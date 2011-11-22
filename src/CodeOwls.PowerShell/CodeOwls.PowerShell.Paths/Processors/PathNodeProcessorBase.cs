using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.PowerShell.Paths.Processors
{
    public abstract class PathNodeProcessorBase : IPathNodeProcessor
    {
        protected abstract INodeFactory Root { get; }

        public IEnumerable<INodeFactory> ResolvePath(IContext context, string path)
        {
            Regex re = new Regex(@"^[-_a-z0-9:]+:/?");
            path = path.ToLowerInvariant().Replace('\\', '/');
            path = re.Replace(path, "");

            var factory = Root;

            var nodeMonikers = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            IEnumerable<INodeFactory> factories = null;
            for (var m = 0; m < nodeMonikers.Count(); ++m )
            {
                var nodeMoniker = nodeMonikers[m];

                factories = factory.Resolve(context, nodeMoniker);
                if (null == factories || !factories.Any())
                {
                    return null;
                }

                factory = factories.First();
            }

            return factories;
        }
    }
}
