using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Nodes.ProjectModel
{
    /// <summary>
    /// 
    /// </summary>
    static class NewProjectItemManager
    {
        #region Nested type: NewItemDynamicParameters

        public class NewItemDynamicParameters
        {
            [Parameter(ParameterSetName = "FromTemplate", ValueFromPipelineByPropertyName = true)]
            [Parameter(ParameterSetName = "FromFile", ValueFromPipelineByPropertyName = true)]
            [Parameter(ParameterSetName = "nameSet", ValueFromPipelineByPropertyName = true)]
            [Parameter(ParameterSetName = "pathSet", ValueFromPipelineByPropertyName = true)]
            public string Language { get; set; }

            [Parameter(ParameterSetName = "FromFile", ValueFromPipelineByPropertyName = true)]
            [Parameter(ParameterSetName = "nameSet", ValueFromPipelineByPropertyName = true)]
            [Parameter(ParameterSetName = "pathSet", ValueFromPipelineByPropertyName = true)]
            [Alias("FilePath")]
            public string ItemFilePath { get; set; }
        }

        #endregion

        #region Implementation of INewItem

        public static IEnumerable<string> NewItemTypeNames
        {
            get { return null; }
        }

        public static object NewItemParameters
        {
            get { return new NewItemDynamicParameters(); }
        }

        public static IPathNode NewItem(Project project, ProjectItems items, IContext context, string path, string itemTypeName, object newItemValue)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var p = context.DynamicParameters as NewItemDynamicParameters;

            Solution2 sln = project.DTE.Solution as Solution2;
            ProjectItem item = null;
            Events2 events2 = project.DTE.Events as Events2;
            var callback = (_dispProjectItemsEvents_ItemAddedEventHandler)((a) => item = a);
            events2.ProjectItemsEvents.ItemAdded += callback;
            try
            {
                if (!String.IsNullOrEmpty(itemTypeName))
                {
                    if ("folder" == itemTypeName.ToLowerInvariant())
                    {
                        items.AddFolder(path, Constants.vsProjectItemKindPhysicalFolder);
                    }
                    else
                    {
                        if (!itemTypeName.ToLowerInvariant().EndsWith(".zip"))
                        {
                            itemTypeName += ".zip";
                        }
                        if (String.IsNullOrEmpty(p.Language))
                        {
                            var map = new Dictionary<string, string>
                                          {
                                              {CodeModelLanguageConstants.vsCMLanguageCSharp, "csharp"},
                                              {CodeModelLanguageConstants.vsCMLanguageVB, "visualbasic"},
                                              {CodeModelLanguageConstants.vsCMLanguageVC, "visualc++"},
                                              {CodeModelLanguageConstants.vsCMLanguageMC, "visualc++"},
                                              {CodeModelLanguageConstants2.vsCMLanguageJSharp, "jsharp"},
                                          };
                            var language = project.CodeModel.Language;
                            p.Language = map.ContainsKey(language) ? map[language] : "csharp";
                        }

                        var t = sln.GetProjectItemTemplate(itemTypeName, p.Language);
                        items.AddFromTemplate(t, path);
                    }
                }
                else if (!String.IsNullOrEmpty(p.ItemFilePath))
                {
                    items.AddFromFileCopy(p.ItemFilePath);
                }
            }
            finally
            {
                events2.ProjectItemsEvents.ItemAdded -= callback;
            }
            if (null == item)
            {
                return null;
            }
            var factory = ProjectItemNodeFactory.Create(item);
            return factory.GetNodeValue();
        }

        #endregion

    }
}
