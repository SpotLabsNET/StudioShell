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


using System.Collections.Generic;
using System.Management.Automation;
using CodeOwls.StudioShell.DTE.ProjectModel;
using EnvDTE;
using EnvDTE80;
using VSLangProj;

namespace CodeOwls.StudioShell.PathNodes.ProjectModel
{
    [Utility.CmdletHelpPathID( "ReferenceCollection" )]
    class ReferenceCollectionNodeFactory : CollectionNodeFactoryBase, INewItem
    {
        private References _references;

        public ReferenceCollectionNodeFactory(References references)
        {
            _references = references;
        }

        #region Overrides of NodeFactoryBase

        public override IEnumerable<INodeFactory> GetNodeChildren()
        {
            foreach( Reference reference in _references)
            {
                yield return new ReferenceNodeFactory(reference);
            }
        }

        public override string Name
        {
            get { return "References"; }
        }

        #endregion

        #region Implementation of INewItem

        public enum WrapperTool
        {
            Default,
            AxImp,
            TlbImp,
        }

        class NewItemParams
        {
            public NewItemParams()
            {
                MajorVersion = 0;
                MinorVersion = 0;
                LocaleID = 0;
                Wrapper = WrapperTool.Default;
            }

            [Parameter(Mandatory = false)]
            public int MajorVersion { get; set; }
            [Parameter(Mandatory = false)]
            public int MinorVersion { get; set; }
            [Parameter(Mandatory = false)]
            public int LocaleID { get; set; }
            [Parameter(Mandatory = false)]
            public WrapperTool Wrapper { get; set; }

        }
        
        public IEnumerable<string> NewItemTypeNames
        {
            get { return new[] { "project", "assembly", "com" }; }
        }

        public object NewItemParameters
        {
            get { return new NewItemParams(); }
        }

        public IPathNode NewItem(Context context, string path, string itemTypeName, object newItemValue)
        {
            Reference reference = null;
            var p = context.DynamicParameters as NewItemParams;
            switch( itemTypeName.ToLowerInvariant() )
            {
                case( "project"):
                    {
                        if (null != newItemValue)
                        {
                            reference = AddFromProjectReference(context, path, newItemValue);
                        }
                        else
                        {
                            reference = AddFromProjectName(context, path);
                        }
                        break;
                    }
                case( "com"):
                    {
                        reference = AddFromActiveX(p, path);
                        break;
                    }

                
                case ("assembly"):
                default:
                    {
                        reference = AddFromAssemblyName(path);
                        break;
                    }
            }

            if( null == reference )
            {
                return null;
            }

            return new ReferenceNodeFactory( reference ).GetNodeValue();
        }

        private Reference AddFromActiveX(NewItemParams p, string comGuid)
        {
            string toolName = GetToolName(p.Wrapper);
            return _references.AddActiveX(comGuid, p.MajorVersion, p.MinorVersion, p.LocaleID, toolName);
        }

        private string GetToolName(WrapperTool wrapper)
        {
            switch(wrapper)
            {
                case (WrapperTool.TlbImp):
                    return "tlbimp";
                case(WrapperTool.AxImp):
                    return "aximp";
                case (WrapperTool.Default):
                default:
                    return "";

            }
        }

        private Reference AddFromAssemblyName(string assemblyName)
        {
            return _references.Add(assemblyName);
        }

        Reference AddFromProjectReference( Context context, string path, object project)
        {
            Project dteProject = null;
            ShellProject shellProject = project as ShellProject;
            if( null != shellProject )
            {
                dteProject = shellProject.AsProject();
            }

            if( null == dteProject )
            {
                dteProject = project as Project;
            }

            if( null == dteProject )
            {
                dteProject = ResolveProject(context, project.ToString());
            }

            if( null == dteProject && ! string.IsNullOrEmpty( path ))
            {
                dteProject = ResolveProject(context, path);
            }

            if( null == dteProject )
            {
                return null;
            }

            return _references.AddProject(dteProject);            
        }

        private Reference AddFromProjectName(Context context, string projectName)
        {
            var project = ResolveProject(context, projectName);
            if( null == project )
            {
                return null;
            }
            return _references.AddProject( project );
        }

        private Project ResolveProject(Context context, string projectName)
        {
            Project project = null;
            var nodeFactory = new SolutionProjectsNodeFactory( _references.DTE as DTE2 );
            project = nodeFactory.ResolveProjectFromName(projectName);
            if( null != project )
            {
                return project;
            }

            ProjectNodeFactory projectNodeFactory = context.Provider.Drive.GetNodeFromPath(projectName) as ProjectNodeFactory;
            if( null != projectNodeFactory )
            {
                project = projectNodeFactory.Project;
            }
            
            return project;
        }

        #endregion
    }
}
