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


using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Items.UI
{
    internal class ShellErrorListItem
    {
        private readonly ErrorItem _item;

        internal ShellErrorListItem(ErrorItem item)
        {
            _item = item;
        }

        public vsBuildErrorLevel ErrorLevel
        {
            get { return _item.ErrorLevel; }
        }

        public string Description
        {
            get { return _item.Description; }
        }

        public string FileName
        {
            get { return _item.FileName; }
        }

        public int Line
        {
            get { return _item.Line; }
        }

        public int Column
        {
            get { return _item.Column; }
        }

        public string Project
        {
            get { return _item.Project; }
        }

        public void Navigate()
        {
            _item.Navigate();
        }
    }
}