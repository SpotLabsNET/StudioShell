using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using CodeOwls.StudioShell.DTE.Commands;
using CodeOwls.StudioShell.PathNodes;
using EnvDTE80;

namespace CodeOwls.StudioShell.Utility
{
    class CommandUtilities
    {
        internal static ShellCommand GetOrCreateCommand( Context context, DTE2 dte, string caption, object commandPathOrScript )
        {
            var stringValue = commandPathOrScript as string;
            var script = commandPathOrScript as ScriptBlock;

            ShellCommand cmd = null;
            if (null != stringValue)
            {
                // locate an existing command by path
                try
                {
                    var command = context.Provider.Drive.GetNodeFromPath(stringValue);
                    if (null != command)
                    {
                        var value = command.GetNodeValue();
                        if (null != value)
                        {
                            cmd = value as ShellCommand;
                        }
                    }
                }
                catch
                {
                }

                // locate an existing command by name
                if (null == cmd)
                {
                    var node = context.Provider.Drive.GetNodeFromPath("dte:/commands");
                    var factory = node.Resolve(stringValue);
                    if (null != factory)
                    {
                        var value = factory.GetNodeValue();
                        if (null != value)
                        {
                            cmd = value.Item as ShellCommand;
                        }
                    }

                }

                // assume the string is script;
                if (null == cmd)
                {
                    script = ScriptBlock.Create(stringValue);
                }
            }

            if (null == cmd && null != script)
            {
                var coll =
                    new CommandCollectionPathNodeFactory(dte.Commands as Commands2);
                var pm = new CommandCollectionPathNodeFactory.NewItemDynamicParameters
                {
                    Button = true,
                    Label = caption,
                    Supported = true,
                    Enabled = true
                };
                cmd =
                    coll.NewItem(
                        new Context { DynamicParameters = pm, Provider = context.Provider },
                        "anonymousCommand_" + Guid.NewGuid().ToString("N"),
                        null, script
                    ).Item as ShellCommand;
            }
            return cmd;
        }
    }
}
