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
using EnvDTE;
using EnvDTE80;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.StudioShell.Paths.Nodes.Debugger
{
    public class ProcessCollectionNodeFactory : CollectionNodeFactoryBase
    {
        private readonly string _name;
        private readonly Processes _processes;

        public ProcessCollectionNodeFactory(Processes processes, string name)
        {
            _processes = processes;
            _name = name;
        }

        #region Overrides of NodeFactoryBase

        public override string Name
        {
            get { return _name; }
        }

        public override IEnumerable<INodeFactory> GetNodeChildren()
        {
            if (null != _processes)
            {
                foreach (Process2 process in _processes)
                {
                    yield return new ProcessNodeFactory(process);
                }
            }
        }

        #endregion
    }
}