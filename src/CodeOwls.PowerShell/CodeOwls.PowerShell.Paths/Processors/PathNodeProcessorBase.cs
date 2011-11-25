/*
   Copyright (c) 2011 Code Owls LLC, All Rights Reserved.

   Licensed under the Microsoft Reciprocal License (Ms-RL) (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.opensource.org/licenses/ms-rl

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
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

            IEnumerable<INodeFactory> factories = new[] {factory};

            foreach (var nodeMoniker in nodeMonikers )
            {
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
