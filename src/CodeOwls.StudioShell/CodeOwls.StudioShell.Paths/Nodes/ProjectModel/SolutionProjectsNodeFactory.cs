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
using System.Management.Automation;
using CodeOwls.PowerShell.Provider.Attributes;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Paths.Items;
using EnvDTE;
using EnvDTE80;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.StudioShell.Paths.Nodes.ProjectModel
{
    [CmdletHelpPathID("SolutionProjects")]
    public class SolutionProjectsNodeFactory : NodeFactoryBase, INewItem
    {
        protected readonly DTE2 _dte;

        public SolutionProjectsNodeFactory(DTE2 dte)
        {
            _dte = dte;
        }

        public override string Name
        {
            get { return "projects"; }
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

        public IPathNode NewItem(IContext context, string path, string itemTypeName, object newItemValue)
        {
            var p = context.DynamicParameters as NewItemDynamicParameters ?? new NewItemDynamicParameters();

            Solution2 sln = _dte.Solution as Solution2;
            Project item = null;
            Events2 events2 = _dte.Events as Events2;
            var callback = (_dispSolutionEvents_ProjectAddedEventHandler) ((a) => item = a);
            events2.SolutionEvents.ProjectAdded += callback;

            try
            {
                if (!String.IsNullOrEmpty(itemTypeName))
                {
                    if ("folder" == itemTypeName.ToLowerInvariant())
                    {
                        sln.AddSolutionFolder(path);
                    }
                    else
                    {
                        if (!itemTypeName.ToLowerInvariant().EndsWith(".zip"))
                        {
                            itemTypeName += ".zip";
                        }
                        if (String.IsNullOrEmpty(p.Language))
                        {
                            p.Language = "csharp";
                        }

                        var projectName = Path.GetFileNameWithoutExtension(path);

                        var destinationPath = Path.Combine(
                            Path.GetDirectoryName(sln.FullName),
                            projectName
                            );
                        var projectFileName = path;
                        if (String.IsNullOrEmpty(Path.GetExtension(path)))
                        {
                            projectFileName += GetProjectFileExtension(p.Language);
                        }

                        var t = sln.GetProjectTemplate(itemTypeName, p.Language);
                        _dte.Solution.AddFromTemplate(t, destinationPath, projectFileName, false);
                    }
                }
                else if (!String.IsNullOrEmpty(p.ItemFilePath))
                {
                    sln.AddFromFile(p.ItemFilePath, false);
                }
            }
            finally
            {
                events2.SolutionEvents.ProjectAdded -= callback;
            }
            if (null == item)
            {
                return null;
            }

            var factory = new ProjectNodeFactory(item);
            return factory.GetNodeValue();
        }

        internal Project ResolveProjectFromName(string name)
        {
            foreach (Project project in _dte.Solution.Projects)
            {
                if (StringComparer.InvariantCultureIgnoreCase.Equals(project.Name, name))
                {
                    return project;
                }
            }

            return null;
        }

        private string GetProjectFileExtension(string language)
        {
            switch (language.ToLowerInvariant())
            {
                case ("vb"):
                case ("visualbasic"):
                    return ".vbproj";

                case ("c++"):
                case ("cpp"):
                case ("visualcpp"):
                    return ".vcproj";

                case ("c#"):
                case ("cs"):
                case ("csharp"):
                default:
                    return ".csproj";
            }
        }

        public class NewItemDynamicParameters
        {
            [Parameter(ParameterSetName = "FromTemplate", ValueFromPipelineByPropertyName = true)]
            //[Parameter(ParameterSetName = "FromFile", ValueFromPipelineByPropertyName = true)]
            [Parameter(ParameterSetName = "nameSet", ValueFromPipelineByPropertyName = true)]
            [Parameter(ParameterSetName = "pathSet", ValueFromPipelineByPropertyName = true)]
            public string Language { get; set; }

            [Parameter(ParameterSetName = "FromFile", ValueFromPipelineByPropertyName = true)]
            //[Parameter(ParameterSetName = "nameSet", ValueFromPipelineByPropertyName = true)]
            [Alias("FilePath")]
            public string ItemFilePath { get; set; }
        }

        #endregion

        public override IPathNode GetNodeValue()
        {
            return new PathNode(new ShellContainer(this), Name, true);
        }

        public override IEnumerable<INodeFactory>  GetNodeChildren( IContext context )
        {
            var factories = new List<INodeFactory>();
            foreach (Project project in _dte.Solution.Projects)
            {
                factories.Add(new ProjectNodeFactory(project));
            }
            return factories;
        }
    }
}