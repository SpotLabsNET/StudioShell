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
using System.Management.Automation;
using System.Text;
using Microsoft.VisualStudio.CommandBars;
using CodeOwls.StudioShell.DTE.CommandBars;

namespace CodeOwls.StudioShell.PathNodes
{
    [Utility.CmdletHelpPathID( "CommandBarCollection")]
    public class CommandBarCollectionNodeFactory : CollectionNodeFactoryBase, INewItem
    {
        public class NewItemDynamicParameters
        {
            public NewItemDynamicParameters()
            {
                Position = MsoBarPosition.msoBarFloating;
            }

            [Parameter]
            public MsoBarPosition Position { get; set; }
            [Parameter]
            public SwitchParameter Temporary { get; set; }
        }

        private readonly CommandBars _commandBars;

        public CommandBarCollectionNodeFactory( CommandBars commandBars )
        {
            this._commandBars = commandBars;
        }

        #region Overrides of NodeFactoryBase

        public override INodeFactory Resolve(string nodeName)
        {
            CommandBar cmdbar = null;
            
            try
            {
                cmdbar =_commandBars[nodeName];
            }
            catch
            {                
            }

            if( null == cmdbar )
            {
                return base.Resolve(nodeName);
            }

            return new CommandBarNodeFactory(cmdbar);
        }

        public override IEnumerable<INodeFactory> GetNodeChildren()
        {
            List<INodeFactory> factories = new List<INodeFactory>();
            foreach( CommandBar commandBar in _commandBars)
            {
                factories.Add( new CommandBarNodeFactory( commandBar ) );
            }
            return factories;
        }

        public override string Name
        {
            get { return "commandBars"; }
        }

        #endregion

        #region Implementation of INewItem

        public IEnumerable<string> NewItemTypeNames
        {
            get { return null; }
        }

        public object NewItemParameters
        {
            get { return new NewItemDynamicParameters(); }
        }

        public IPathNode NewItem(Context context, string path, string itemTypeName, object newItemValue)
        {
            var p = context.DynamicParameters as NewItemDynamicParameters;
            var bar = _commandBars.Add(path, p.Position, System.Type.Missing, p.Temporary.IsPresent);
            bar.Visible = true;
            return new PathNode( new ShellCommandBar( bar ), path, true );
        }

        #endregion
    }
}
