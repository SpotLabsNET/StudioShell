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
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell.Interop;
using CodeOwls.StudioShell.Exceptions;
using VSLangProj80;
using Constants = EnvDTE.Constants;

namespace CodeOwls.StudioShell.PathNodes
{
    [Utility.CmdletHelpPathID( "Project")]
	public class ProjectNodeFactory : NodeFactoryBase , INewItem, IRenameItem, IRemoveItem
	{
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
		private readonly Project _project;

		public ProjectNodeFactory(Project project)
		{
			_project = project;
		    
		}

        public override string Name
        {
            get { return _project.Name; }
        }

		public override IPathNode GetNodeValue()
		{
		    object value = DTE.ShellObjectFactory.CreateFromProject(_project);
			return new PathNode( value, _project.Name, true );
		}

        internal static INodeFactory Create(object item)
        {
            if (item is Project)
            {
                return new ProjectNodeFactory(item as Project);
            }
            var projectItem = item as ProjectItem;

            System.Diagnostics.Debug.Assert(null != projectItem);

            if (null != projectItem.SubProject)
            {
                return new ProjectNodeFactory(projectItem.SubProject);
            }

            return new ProjectItemNodeFactory(projectItem);                        
        }

		public override IEnumerable<INodeFactory> GetNodeChildren()
		{            
			foreach( ProjectItem item in _project.ProjectItems )
			{
                yield return ProjectNodeFactory.Create(item);
			}

		    var vsproj = _project.Object as VSLangProj.VSProject;
            if (null != vsproj)
            {
                yield return new ProjectModel.ReferenceCollectionNodeFactory(vsproj.References);
            }
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

	    public IPathNode NewItem(Context context, string path, string itemTypeName, object newItemValue)
	    {
	        var p = context.DynamicParameters as NewItemDynamicParameters;

	        Solution2 sln = _project.DTE.Solution as Solution2;
	        ProjectItem item = null;
	        Events2 events2 = _project.DTE.Events as Events2;
            var callback = (_dispProjectItemsEvents_ItemAddedEventHandler)((a) => item = a);
	        events2.ProjectItemsEvents.ItemAdded += callback;
            try
            {
                if (!String.IsNullOrEmpty(itemTypeName))
                {
                    if ("folder" == itemTypeName.ToLowerInvariant())
                    {
                        _project.ProjectItems.AddFolder(path, Constants.vsProjectItemKindPhysicalFolder);
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
                            var language = _project.CodeModel.Language;
                            p.Language = map.ContainsKey(language) ? map[language] : "csharp";
                        }

                        var t = sln.GetProjectItemTemplate(itemTypeName, p.Language);
                        _project.ProjectItems.AddFromTemplate(t, path);
                    }
                }
                else if (!String.IsNullOrEmpty(p.ItemFilePath))
                {
                    _project.ProjectItems.AddFromFileCopy(p.ItemFilePath);
                }
            }
            finally
            {
                events2.ProjectItemsEvents.ItemAdded -= callback;
            }
            if( null == item )
            {
                return null;
            }
	        var factory = new ProjectItemNodeFactory(item);
	        return factory.GetNodeValue();
	    }

	    #endregion

	    #region Implementation of IRenameItem

	    public object RenameItemParameters
	    {
	        get { return null; }
	    }

	    public void RenameItem(Context context, string path, string newName)
	    {
	        _project.Name = newName;
	    }

	    #endregion

	    #region Implementation of IRemoveItem

	    public object RemoveItemParameters
	    {
	        get { return null; }
	    }

	    public void RemoveItem(Context context, string path, bool recurse)
	    {
            if( _project.Kind == Constants.vsProjectKindMisc )
            {
                context.Provider.WriteWarning( 
                    String.Format(
                        "Project {0} cannot be removed since it's of the 'Miscellaneous Files' type",
                        Name
                    ));
                return;
            }

            if( context.Provider.Force )
            {
                _project.Delete();
                
                return;
            }

	        var solutionService = context.ServiceProvider.GetService<SVsSolution>() as IVsSolution;
            if( null == solutionService)
            {
                context.Provider.WriteError(
                    new ErrorRecord(
                            new ServiceUnavailableException(typeof (IVsSolution)),
                            "StudioShell.ServiceUnavailable",
                            ErrorCategory.ResourceUnavailable,
                            GetNodeValue()
                        )
                    );
                return;
            }

	        IVsHierarchy heirarchy;
	        solutionService.GetProjectOfUniqueName(_project.UniqueName, out heirarchy);
            if (null == heirarchy)
            {
                context.Provider.WriteWarning( "The project " + _project.Name + " could not be removed: the IVsSolution service failed to locate the project by its unique name. ");
                return;
            }

	        solutionService.CloseSolutionElement((uint) __VSSLNCLOSEOPTIONS.SLNCLOSEOPT_UnloadProject, heirarchy, 0);
	    }

	    #endregion

	    internal Project Project
	    {
	        get { return _project; }
	    }
	}
}
