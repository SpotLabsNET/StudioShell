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
using System.Linq;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.StudioShell.Common.Utility;
using CodeOwls.StudioShell.Paths.Items.UI;
using EnvDTE;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.StudioShell.Paths.Nodes.UI
{
    internal class WindowConfigurationCollectionNodeFactory : CollectionNodeFactoryBase, INewItem
    {
        private readonly WindowConfigurations _configurations;

        public WindowConfigurationCollectionNodeFactory(WindowConfigurations configurations)
        {
            _configurations = configurations;
        }

        public override string Name
        {
            get { return NodeNames.WindowConfigurations; }
        }

        #region Implementation of INewItem

        public IEnumerable<string> NewItemTypeNames
        {
            get { return null; }
        }

        public object NewItemParameters
        {
            get { return null; }
        }

        public IPathNode NewItem(IContext context, string path, string itemTypeName, object newItemValue)
        {
            var newConfig = _configurations.Add(path);
            newConfig.Apply( true ); 
            
            return new PathNode(new ShellWindowConfiguration(newConfig), path, false);
        }

        #endregion

        public override IEnumerable<INodeFactory>  GetNodeChildren( IContext context )
        {
            List<INodeFactory> factories = new List<INodeFactory>();
            var en = _configurations.GetEnumerator();
            if (!TryMoveNext(en))
            {
                return factories;
            }
            do
            {
                try
                {
                    factories.Add(new WindowConfigurationNodeFactory(en.Current as WindowConfiguration));
                }
                catch
                {
                }
            } while (TryMoveNext(en));

            return from factory in factories
                   orderby factory.Name
                   select factory;
        }

        private bool TryMoveNext(System.Collections.IEnumerator en)
        {
            try
            {
                return en.MoveNext();
            }
            catch
            {
                return false;
            }
        }
    }
}