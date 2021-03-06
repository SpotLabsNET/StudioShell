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
using CodeOwls.StudioShell.Paths.Items.PropertyModel;
using CodeOwls.StudioShell.Paths.Items.UI;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Items.ProjectModel
{
    public class ShellProjectItem
    {
        private readonly ProjectItem _item;

        internal ShellProjectItem(ProjectItem item)
        {
            _item = item;
        }

        public bool IsDirty
        {
            get { return _item.IsDirty; }
            set { _item.IsDirty = value; }
        }

        public string FileName
        {
            get
            {
                if (0 < FileCount)
                {
                    return get_FileNames(0);
                }
                return null;
            }
        }

        public string[] FileNames
        {
            get
            {
                if (0 == FileCount)
                {
                    return new string[] {};
                }

                string[] files = new string[FileCount];
                for (short c = 0; c < FileCount; ++c)
                {
                    files[c] = get_FileNames(c);
                }

                return files;
            }
        }

        public short FileCount
        {
            get { return _item.FileCount; }
        }

        public string Name
        {
            get { return _item.Name; }
            set { _item.Name = value; }
        }

        public IEnumerable<ShellProperty> Properties
        {
            get
            {
                return from Property prop in _item.Properties
                       select new ShellProperty(prop);
            }
        }

        public string Kind
        {
            get { return _item.Kind; }
        }

        public string ItemType
        {
            get
            {
                var d = new Dictionary<string, string>
                            {
                                {Constants.vsProjectItemKindMisc, "Misc"},
                                {Constants.vsProjectItemKindPhysicalFile, "File"},
                                {Constants.vsProjectItemKindPhysicalFolder, "Folder"},
                                {Constants.vsProjectItemKindSolutionItems, "Solution Items"},
                                {Constants.vsProjectItemKindSubProject, "SubProject"},
                                {Constants.vsProjectItemKindVirtualFolder, "Virtual Folder"},
                                {Constants.vsProjectItemsKindMisc, "Misc"},
                                {Constants.vsProjectItemsKindSolutionItems, "Solution Items"},
                            };

                string value = null;
                if (d.TryGetValue(Kind, out value))
                {
                    return value;
                }
                return String.Empty;
            }
        }


        public object Object
        {
            get { return _item.Object; }
        }

        public bool Saved
        {
            get { return _item.Saved; }
            set { _item.Saved = value; }
        }

        public ConfigurationManager ConfigurationManager
        {
            get { return _item.ConfigurationManager; }
        }

        public FileCodeModel FileCodeModel
        {
            get { return _item.FileCodeModel; }
        }

        public Document Document
        {
            get { return _item.Document; }
        }

        public ShellProject SubProject
        {
            get { return new ShellProject(_item.SubProject); }
        }

        public ShellProject ContainingProject
        {
            get { return new ShellProject(_item.ContainingProject); }
        }

        public bool SaveAs(string NewFileName)
        {
            return _item.SaveAs(NewFileName);
        }

        public ShellWindow Open(string ViewKind)
        {
            return new ShellWindow(_item.Open(ViewKind) as Window2);
        }

        public void Remove()
        {
            _item.Remove();
        }

        public void ExpandView()
        {
            _item.ExpandView();
        }

        public void Save(string FileName)
        {
            _item.Save(FileName);
        }

        public void Delete()
        {
            _item.Delete();
        }

        private string get_FileNames(int index)
        {
            return _item.get_FileNames((short) (index + 1));
        }

        public bool get_IsOpen(string ViewKind)
        {
            return _item.get_IsOpen(ViewKind);
        }

        internal ProjectItem AsProjectItem()
        {
            return _item;
        }
    }
}