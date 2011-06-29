using System;
using System.Management.Automation;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.StudioShell.Paths.Items.Commands;
using CodeOwls.StudioShell.Paths.Nodes.Commands;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Utility
{
    internal class CommandUtilities
    {
        internal static ShellCommand GetOrCreateCommand(IContext context, DTE2 dte, string caption,
                                                        object commandPathOrScript)
        {
            var stringValue = commandPathOrScript as string;
            var script = commandPathOrScript as ScriptBlock;

            ShellCommand cmd = null;
            if (null != stringValue)
            {
                // locate an existing command by path
                try
                {
                    var command = context.PathProcessor.ResolvePath(stringValue);
                    if (null != command)
                    {
                        var value = command.GetNodeValue();
                        if (null != value)
                        {
                            cmd = value.Item as ShellCommand;
                        }
                    }
                }
                catch
                {
                }

                // locate an existing command by name
                if (null == cmd)
                {
                    var node = context.PathProcessor.ResolvePath("dte:/commands");
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
                        new Context(context, pm),
                        "anonymousCommand_" + Guid.NewGuid().ToString("N"),
                        null, script
                        ).Item as ShellCommand;
            }
            return cmd;
        }
    }
}