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
using System.Management.Automation.Runspaces;
using System.Text.RegularExpressions;
using EnvDTE;
using EnvDTE80;
using CodeOwls.StudioShell.DTE.Commands;
using CodeOwls.StudioShell.Utility;
using Command = EnvDTE.Command;

namespace CodeOwls.StudioShell.PathNodes
{
    [CmdletHelpPathID("CommandCollection")]
    public class CommandCollectionPathNodeFactory : CollectionNodeFactoryBase, INewItem
    {
        public enum CommandUIType
        {
            Picture,
            Text,
            BothPictureAndText
        }

        public class NewItemDynamicParameters
        {
            [Parameter(
                HelpMessage = "The name of the command, as shown in UI",
                Mandatory = false
                )]
            public string Label { get; set; }

            [Parameter(
                HelpMessage = "The tooltip for the command",
                Mandatory = false
                )]
            public string Tooltip { get; set; }

            [Parameter(
                HelpMessage = "The key bindings for the command",
                Mandatory = false
                )]
            public object[] Bindings{ get; set; }
            
            [Parameter(
                HelpMessage = "If specified, the command is currently enabled"              
                )]
            public SwitchParameter Enabled { get; set; }
            [Parameter(
                HelpMessage = "If specified, the command is currently invisible"
                )]
            public SwitchParameter Invisible { get; set; }
            [Parameter(
                HelpMessage = "If specified, the command is currently supported"
                )]
            public SwitchParameter Supported { get; set; }
            [Parameter(
                HelpMessage = "If specified, the command is currently unsupported"
                )]
            public SwitchParameter Unsupported { get; set; }

            [Parameter(
                HelpMessage = "The UI type for this command; can be Text, Picture, or BothPictureAndText"
                )]
            public CommandUIType UI{ get; set; }
            
            public SwitchParameter ComboBox { get; set; }
            public SwitchParameter Button { get; set; }
            public SwitchParameter MRUComboBox { get; set; }
            public SwitchParameter MRUButton { get; set; }
        }

        private readonly Commands2 _commands;

        public CommandCollectionPathNodeFactory( Commands2 commands )
        {
            _commands = commands;
        }

        public override INodeFactory Resolve(string nodeName)
        {
            Command command = null;
            try
            {
                command = _commands.Item(nodeName);
            }
            catch
            {                
            }

            if( null == command )
            {
                return null;
            }

            return new CommandNodeFactory(command);
        }

        public override IEnumerable<INodeFactory> GetNodeChildren()
        {
            foreach( Command command in _commands )
            {
                yield return new CommandNodeFactory( command );
            }
        }

        public override string Name
        {
            get { return "commands";  }
        }

        #region Implementation of INewItem

        public IEnumerable<string> NewItemTypeNames
        {
            get { return null; }
        }

        public object NewItemParameters
        {
            get { return new NewItemDynamicParameters(); }
        }

        public IPathNode NewItem(Context context, string path, string itemTypeName, object value)
        {
            var validValueTypes = new Type[] { typeof(ScriptBlock), typeof(string) };
            if (!validValueTypes.Contains(value.GetType()))
            {
                var validNames = String.Join(", ", validValueTypes.ToList().ConvertAll(t => t.FullName).ToArray());
                throw new ArgumentException("new item values must be one of the following types: " + validNames);
            }

            var p = context.DynamicParameters as NewItemDynamicParameters ?? new NewItemDynamicParameters();
            object[] contextGuids = new object[] { };

            string functionName = FunctionUtilities.GetFunctionNameFromPath(path);
            
            var cmd = _commands.AddNamedCommand2(
                Connect.AddInInstance,
                path,
                p.Label ?? path,
                p.Tooltip ?? String.Empty,
                true,
                null,
                ref contextGuids,
                (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled,
                (int)vsCommandStyle.vsCommandStylePictAndText,
                vsCommandControlType.vsCommandControlTypeButton
                );

            if( null != p.Bindings )
            {
                cmd.Bindings = p.Bindings;
            }

            string command = "new-item -path function:" + functionName + " -value {" + value.ToString() + "} ";
            
            ExecuteScript(context, command);

            var factory = new CommandNodeFactory(cmd);
            return factory.GetNodeValue();
        }

        #endregion
    }
}
