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
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Paths.Nodes.ProjectModel;
using EnvDTE;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.StudioShell.Paths.Nodes.DTE
{
    internal class SelectedProjectsNodeFactory : CollectionNodeFactoryBase
    {
        private readonly SelectedItems _items;

        public SelectedProjectsNodeFactory(SelectedItems items)
        {
            _items = items;
        }

        #region Overrides of NodeFactoryBase

        public override string Name
        {
            get { return "Projects"; }
        }

        public override IEnumerable<INodeFactory> GetNodeChildren()
        {
            List<INodeFactory> factories = new List<INodeFactory>();
            foreach (SelectedItem item in _items)
            {
                if (null == item.Project)
                {
                    continue;
                }

                factories.Add(new ProjectNodeFactory(item.Project));
            }
            return factories;
        }

        #endregion
    }
}