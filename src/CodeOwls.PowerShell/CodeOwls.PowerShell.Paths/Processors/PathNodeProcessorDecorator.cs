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

using System.Collections.Generic;
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

        public virtual IEnumerable<INodeFactory> ResolvePath( IContext context, string path)
        {
            return _basePathNodeProcessor.ResolvePath( context, path);
        }

        #endregion
    }
}
