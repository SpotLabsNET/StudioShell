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
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.StudioShell.Common.Utility;
using CodeOwls.StudioShell.Paths.Items;
using CodeOwls.StudioShell.Paths.Utility;
using EnvDTE80;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.StudioShell.Paths.Nodes.UI
{
    internal class WindowCollectionNodeFactory : NodeFactoryBase //, INewItem
    {
        private readonly Windows2 _windows;

        public WindowCollectionNodeFactory(Windows2 windows)
        {
            _windows = windows;
        }

        public override string Name
        {
            get { return NodeNames.Windows; }
        }

        #region Implementation of INewItem

        public IEnumerable<string> NewItemTypeNames
        {
            get { return new[] {String.Empty, "Tool", "Linked"}; }
        }

        public object NewItemParameters
        {
            get { return null; }
        }

        public IPathNode NewItem(IContext context, string path, string itemTypeName, object newItemValue)
        {
            if (itemTypeName.ToLowerInvariant() == "linked")
            {
                return CreateNewLinkedWindow(context, path, newItemValue);
            }

            return CreateToolWindow(context, path, newItemValue);
        }

        private IPathNode CreateToolWindow(IContext context, string path, object newItemValue)
        {
            throw new NotImplementedException();
        }

        private IPathNode CreateNewLinkedWindow(IContext context, string path, object newItemValue)
        {
            throw new NotImplementedException();
        }

        #endregion

        public override IPathNode GetNodeValue()
        {
            return new PathNode(new ShellContainer(this), Name, true);
        }

        public override IEnumerable<INodeFactory>  GetNodeChildren( IContext context )
        {
            var windows = new List<Window2>();
            var factories = new List<INodeFactory>();
            foreach (string name in VSWindowKinds.All)
            {
                try
                {
                    if (name != VSWindowKinds.WebBrowser)
                    {
                        var w = _windows.Item(name) as Window2;
                        windows.Add(w);
                    }
                }
                catch
                {
                }
            }

            windows.AddRange(from Window2 w in _windows select w);

            factories.AddRange(windows.Distinct().ToList().ConvertAll(w => (INodeFactory) new WindowNodeFactory(w)));
            factories.OrderBy(a => a.Name);
            return factories;
        }
    }
}