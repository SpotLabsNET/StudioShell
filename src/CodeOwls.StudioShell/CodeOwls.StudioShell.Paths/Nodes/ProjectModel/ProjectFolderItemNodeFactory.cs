using System.Collections.Generic;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Nodes.ProjectModel
{
    class ProjectFolderItemNodeFactory : ProjectItemNodeFactoryBase, INewItem
    {
        public ProjectFolderItemNodeFactory(ProjectItem item) : base(item)
        {
        }

        #region Implementation of INewItem

        public IEnumerable<string> NewItemTypeNames
        {
            get { return NewProjectItemManager.NewItemTypeNames; }
        }

        public object NewItemParameters
        {
            get { return NewProjectItemManager.NewItemParameters; }
        }

        public IPathNode NewItem(IContext context, string path, string itemTypeName, object newItemValue)
        {
            return NewProjectItemManager.NewItem(
                _item.ContainingProject,
                _item.ProjectItems,
                context,
                path,
                itemTypeName,
                newItemValue);
        }

        #endregion
    }
}