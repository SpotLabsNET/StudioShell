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
using System.Collections;
using System.Collections.Generic;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Paths.Items;
using CodeOwls.StudioShell.Paths.Items.CodeModel;
using EnvDTE;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.StudioShell.Paths.Nodes.CodeModel
{
    public class CodeElementNodeFactory : NodeFactoryBase, IInvokeItem
    {
        private readonly CodeElement _element;

        public CodeElementNodeFactory(CodeElement element)
        {
            _element = element;
        }

        public override string ItemMode
        {
            get { return base.EncodedItemMode; }
        }

        protected virtual bool IsCollection
        {
            get { return false; }
        }

        public override string Name
        {
            get
            {
                try
                {
                    return ((IShellCodeModelElement2) GetNodeValue().Item).Name;
                }
                catch (Exception e)
                {
                    return "????????";
                }
            }
        }

        public override IPathNode GetNodeValue()
        {
            var shellObject = ShellObjectFactory.CreateFromCodeElement(_element);

            return new PathNode(shellObject, shellObject.Name, IsCollection);
        }

        public override IEnumerable<INodeFactory> GetNodeChildren()
        {
            List<INodeFactory> factories = new List<INodeFactory>();

            IEnumerable echildren = null;

            foreach (CodeElement e in _element.Children)
            {
                factories.Add(FileCodeModelNodeFactory.CreateNodeFactoryFromCodeElement(e));
            }
            return factories;
        }

        public object InvokeItemParameters
        {
            get { return null; }
        }

        public IEnumerable<object> InvokeItem(IContext context, string path)
        {
            var e = new ShellCodeModelElement2(_element);
            e.Activate();
            return null;
        }
    }
}