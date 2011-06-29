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
using System.IO;
using CodeOwls.StudioShell.Paths.Items.Debugger;
using EnvDTE;
using EnvDTE80;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.StudioShell.Paths.Nodes.Debugger
{
    public class ProcessNodeFactory : NodeFactoryBase
    {
        private readonly Process2 _process;

        public ProcessNodeFactory(Process2 process)
        {
            _process = process;
        }

        #region Overrides of NodeFactoryBase

        public override string Name
        {
            get { return Path.GetFileName(_process.Name); }
        }

        public override IEnumerable<INodeFactory> GetNodeChildren()
        {
            List<INodeFactory> factories = new List<INodeFactory>();
            foreach (Thread thread in _process.Threads)
            {
                factories.Add(new ThreadNodeFactory(thread));
            }
            return factories;
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode(new ShellProcess(_process), Name, true);
        }

        #endregion
    }
}