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
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Common.IoC;
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
            if (null == context)
            {
                throw new ArgumentNullException("context");
            }
            if (null == project)
            {
                throw new ArgumentNullException("project");
            }

            var p = context.DynamicParameters as NewItemDynamicParameters;

            DTE2 dte = project.DTE as DTE2;
            Solution2 sln = dte.Solution as Solution2;
            ProjectItem item = null;
            Events2 events2 = dte.Events as Events2;
            var callback = (_dispProjectItemsEvents_ItemAddedEventHandler)((a) => item = a);
            events2.ProjectItemsEvents.ItemAdded += callback;
            try
            {
                if (!String.IsNullOrEmpty(itemTypeName))
                {
                    if ("folder" == itemTypeName.ToLowerInvariant())
                    {
                        if (project.Object is SolutionFolder)
                        {
                            var folder = project.Object as SolutionFolder;
                            folder.AddSolutionFolder(path);
                        }
                        else
                        {
                            items.AddFolder(path, Constants.vsProjectItemKindPhysicalFolder);
                        }
                    }
                    else
                    {
                        if (!itemTypeName.ToLowerInvariant().EndsWith(".zip"))
                        {
                            itemTypeName += ".zip";
                        }
                        if (String.IsNullOrEmpty(p.Language))
                        {
                            const string csharp = "csharp";
                            const string vb = "visualbasic";
                            const string vcpp = "visualc++";
                            const string jsharp = "jsharp";
                            var map = new Dictionary<string, string>
                                          {
                                              {"cs", csharp},
                                              {"vb", vb},
                                              {"c#", csharp},
                                              {"c++", vcpp},
                                              {"c+", vcpp},
                                              {"cpp", vcpp},
                                              {csharp, csharp},
                                              {vcpp, vcpp},
                                              {vb,vb},
                                              {jsharp,jsharp},
                                              {CodeModelLanguageConstants.vsCMLanguageCSharp, csharp},
                                              {CodeModelLanguageConstants.vsCMLanguageVB, vb},
                                              {CodeModelLanguageConstants.vsCMLanguageVC, vcpp},
                                              {CodeModelLanguageConstants.vsCMLanguageMC, vcpp},
                                              {CodeModelLanguageConstants2.vsCMLanguageJSharp, jsharp},
                                          };

                            string language = String.Empty;
                            if (null != project.CodeModel && null != project.CodeModel.Language)
                            {
                                language = project.CodeModel.Language;
                            }
                            p.Language = map.ContainsKey(language) ? map[language] : "csharp";
                        }

                        if (project.Object is SolutionFolder)
                        {
                            SolutionFolder folder = project.Object as SolutionFolder;
                            var destinationPath = Path.Combine(
                                Path.GetDirectoryName(sln.FullName),
                                path
                                );

                            var n = sln.GetProjectTemplate(itemTypeName, p.Language);
                            folder.AddFromTemplate(n, destinationPath, path);                            
                        }
                        else
                        {
                            var t = sln.GetProjectItemTemplate(itemTypeName, p.Language);
                            items.AddFromTemplate(t, path);
                        }
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
