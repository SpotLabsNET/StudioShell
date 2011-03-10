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
using System.Management.Automation;
using System.Text;
using EnvDTE;
using CodeOwls.StudioShell.DTE.Commands;
using CodeOwls.StudioShell.Utility;

namespace CodeOwls.StudioShell.PathNodes
{
    [CmdletHelpPathID("Command")]
    public class CommandNodeFactory : NodeFactoryBase, IRemoveItem, IInvokeItem, ISetItem
    {
        public class SetItemDynamicParameters
        {
            [Parameter(
                HelpMessage = "The key bindings for the command"
                )]
            public string[] Bindings { get; set; }            
        }

        private readonly Command _command;

        public CommandNodeFactory(Command command)
        {
            _command = command;
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode( new ShellCommand( _command ), Name, false);
        }

        public override string Name
        {
            get { return _command.Name.MakeSafeForPath(); }
        }

        public object RemoveItemParameters
        {
            get { return null; }
        }

        public void RemoveItem(Context context, string path, bool recurse)
        {
            _command.Delete();

            string functionName = FunctionUtilities.GetFunctionNameFromPath(path);
            string script = "remove-item -path function:" + functionName;
            ExecuteScript( context, script );
        }

        #region Implementation of IInvokeItem

        public object InvokeItemParameters
        {
            get { return null; }
        }

        public IEnumerable<object> InvokeItem(Context provider, string path)
        {
            object ino = null;
            object outo = null;
            if (!_command.IsAvailable)
            {
                throw new InvalidOperationException("the specified command is not available at this time");
            }

            Connect.ApplicationObject.Commands.Raise( _command.Guid, _command.ID, ref ino, ref outo );
            return null == outo ? null : new[] {outo};
        }

        #endregion

        #region Implementation of ISetItem

        public object SetItemParameters
        {
            get { return new SetItemDynamicParameters(); }
        }

        public IPathNode SetItem(Context context, string path, object value)
        {            
            var p = context.DynamicParameters as SetItemDynamicParameters;
            if (null != p && null != p.Bindings)
            {
                _command.Bindings = p.Bindings;
            }

            if (null != value)
            {
                string functionName = FunctionUtilities.GetFunctionNameFromPath(path);
                var fpath = "function:" + functionName;
                string command = String.Format(
                    @"if( test-path ""{0}"" ) 
{{ 
    remove-item -path ""{0}""; 
}} 

new-item -path ""{0}"" -value {{ {1} }} -options Constant,AllScope;",
                    fpath,
                    value.ToString()
                    );
                ExecuteScript(context, command);
            }
            return GetNodeValue();
        }

        #endregion
    }
}
