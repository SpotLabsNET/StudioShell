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


using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Items.ProjectModel
{
    internal class ShellSolutionFolder
    {
        private readonly SolutionFolder _folder;
        private readonly Project _project;

        internal ShellSolutionFolder(Project projectItem)
        {
            _project = projectItem;
            _folder = projectItem.Object as SolutionFolder;
        }

        public string Name
        {
            get { return _project.Name; }
            set { _project.Name = value; }
        }

        public string FileName
        {
            get { return _project.FileName; }
        }

        public string Kind
        {
            get { return _project.Kind; }
        }

        public string UniqueName
        {
            get { return _project.UniqueName; }
        }

        public string FullName
        {
            get { return _project.FullName; }
        }

        public bool IsDirty
        {
            get { return _project.IsDirty; }
            set { _project.IsDirty = value; }
        }

        public bool Saved
        {
            get { return _project.Saved; }
            set { _project.Saved = value; }
        }

        public ShellProject AddSolutionFolder(string Name)
        {
            return new ShellProject(_folder.AddSolutionFolder(Name));
        }

        public ShellProject AddFromFile(string FileName)
        {
            return new ShellProject(_folder.AddFromFile(FileName));
        }

        public ShellProject AddFromTemplate(string FileName, string Destination, string ProjectName)
        {
            return new ShellProject(_folder.AddFromTemplate(FileName, Destination, ProjectName));
        }
    }
}