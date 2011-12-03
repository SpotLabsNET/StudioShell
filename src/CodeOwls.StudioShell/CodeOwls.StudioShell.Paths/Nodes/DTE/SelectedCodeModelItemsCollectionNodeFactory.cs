using System.Collections.Generic;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Nodes.DTE
{
    internal class SelectedCodeModelItemsCollectionNodeFactory : CollectionNodeFactoryBase
    {
        private readonly DTE2 _dte;

        public SelectedCodeModelItemsCollectionNodeFactory( DTE2 dte )
        {
            _dte = dte;
        }

        public override string Name
        {
            get { return "CodeModel"; }
        }

        public override IEnumerable<PowerShell.Provider.PathNodes.INodeFactory> GetNodeChildren(IContext context)
        {
            return new INodeFactory[]
                       {
                           new SelectedCodeModelItemNodeFactory(_dte, vsCMElement.vsCMElementNamespace, "Namespace"),
                           new SelectedCodeModelItemNodeFactory(_dte, vsCMElement.vsCMElementClass, "Class"),
                           new SelectedCodeModelItemNodeFactory(_dte, vsCMElement.vsCMElementProperty, "Property"),
                           new SelectedCodeModelItemNodeFactory(_dte, vsCMElement.vsCMElementStruct, "Struct"),
                           new SelectedCodeModelItemNodeFactory(_dte, vsCMElement.vsCMElementInterface, "Interface"),
                           new SelectedCodeModelItemNodeFactory(_dte, vsCMElement.vsCMElementFunction, "Method"),
                           new SelectedCodeModelItemNodeFactory(_dte, vsCMElement.vsCMElementEnum, "Enum"),
                       };            
        }
    }
}