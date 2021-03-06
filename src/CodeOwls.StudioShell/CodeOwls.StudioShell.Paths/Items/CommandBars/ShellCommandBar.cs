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


using Microsoft.VisualStudio.CommandBars;

namespace CodeOwls.StudioShell.Paths.Items.CommandBars
{
    public class ShellCommandBar
    {
        private readonly CommandBar _bar;

        internal ShellCommandBar(CommandBar bar)
        {
            _bar = bar;
        }

        public int Creator
        {
            get { return _bar.Creator; }
        }

        public bool BuiltIn
        {
            get { return _bar.BuiltIn; }
        }

        public string Context
        {
            get { return _bar.Context; }
            set { _bar.Context = value; }
        }

        public bool Enabled
        {
            get { return _bar.Enabled; }
            set { _bar.Enabled = value; }
        }

        public int Height
        {
            get { return _bar.Height; }
            set { _bar.Height = value; }
        }

        public int Index
        {
            get { return _bar.Index; }
        }

        public int InstanceId
        {
            get { return _bar.InstanceId; }
        }

        public int Left
        {
            get { return _bar.Left; }
            set { _bar.Left = value; }
        }

        public string Name
        {
            get { return _bar.Name; }
            set { _bar.Name = value; }
        }

        public string NameLocal
        {
            get { return _bar.NameLocal; }
            set { _bar.NameLocal = value; }
        }

        public MsoBarPosition Position
        {
            get { return _bar.Position; }
            set { _bar.Position = value; }
        }

        public int RowIndex
        {
            get { return _bar.RowIndex; }
            set { _bar.RowIndex = value; }
        }

        public MsoBarProtection Protection
        {
            get { return _bar.Protection; }
            set { _bar.Protection = value; }
        }

        public int Top
        {
            get { return _bar.Top; }
            set { _bar.Top = value; }
        }

        public MsoBarType Type
        {
            get { return _bar.Type; }
        }

        public bool Visible
        {
            get { return _bar.Visible; }
            set { _bar.Visible = value; }
        }

        public int Width
        {
            get { return _bar.Width; }
            set { _bar.Width = value; }
        }

        public bool AdaptiveMenu
        {
            get { return _bar.AdaptiveMenu; }
            set { _bar.AdaptiveMenu = value; }
        }

        public int Id
        {
            get { return _bar.Id; }
        }

        public void Delete()
        {
            _bar.Delete();
        }

        public object FindControl(object Type, object Id, object Tag, object Visible, object Recursive)
        {
            var o = _bar.FindControl(Type, Id, Tag, Visible, Recursive);
            if (null == o)
            {
                return null;
            }

            return ShellObjectFactory.CreateFromCommandBarControl(o);
        }

        public void Reset()
        {
            _bar.Reset();
        }

        public void ShowPopup(object x, object y)
        {
            _bar.ShowPopup(x, y);
        }
    }
}