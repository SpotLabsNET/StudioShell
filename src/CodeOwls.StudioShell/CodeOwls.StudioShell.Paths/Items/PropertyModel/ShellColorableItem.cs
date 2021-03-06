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


using System.Drawing;
using CodeOwls.StudioShell.Common.Utility;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Items.PropertyModel
{
    public class ShellColorableItem
    {
        private readonly EnvDTE.ColorableItems _items;

        internal ShellColorableItem(ColorableItems items)
        {
            _items = items;
        }

        public string ItemName
        {
            get { return _items.Name; }
        }

        public Color Foreground
        {
            get { return _items.Foreground.ToColor(); }
            set { _items.Foreground = value.ToUInt32(); }
        }

        public Color Background
        {
            get { return _items.Background.ToColor(); }
            set { _items.Background = value.ToUInt32(); }
        }

        public bool Bold
        {
            get { return _items.Bold; }
            set { _items.Bold = value; }
        }
    }
}