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
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.PathNodes
{
    class WindowNodeFactory : NodeFactoryBase, IInvokeItem
    {
        private readonly Window2 _window;
        private string _name;

        public WindowNodeFactory( Window2 window )
            :this(window,null)
        {
            
        }
        public WindowNodeFactory( Window2 window, string name)
        {
            _window = window;
            _name = name;
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode(new DTE.UI.ShellWindow(_window), Name, true);
        }

        public override IEnumerable<INodeFactory> GetNodeChildren()
        {
            if (null == _window.CommandBars)
            {
                return null;
            }

            var commandBars = (Microsoft.VisualStudio.CommandBars.CommandBars)_window.CommandBars;

            return new INodeFactory[]
                       {
                           new CommandBarCollectionNodeFactory(commandBars)
                       };
        }

        public override string Name
        {
            get { return _name ?? _window.Caption; }
        }

        #region Implementation of IInvokeItem

        public object InvokeItemParameters
        {
            get { return null; }
        }

        public IEnumerable<object> InvokeItem(Context context, string path)
        {
            _window.Activate();
            return null;
        }

        #endregion
    }
}
