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
    internal class ShellCommandBarButton
    {
        private readonly CommandBarButton _button;

        internal ShellCommandBarButton(CommandBarButton button)
        {
            _button = button;
        }

        public int Creator
        {
            get { return _button.Creator; }
        }

        public bool BeginGroup
        {
            get { return _button.BeginGroup; }
            set { _button.BeginGroup = value; }
        }

        public bool BuiltIn
        {
            get { return _button.BuiltIn; }
        }

        public string Caption
        {
            get { return _button.Caption; }
            set { _button.Caption = value; }
        }

        public string DescriptionText
        {
            get { return _button.DescriptionText; }
            set { _button.DescriptionText = value; }
        }

        public bool Enabled
        {
            get { return _button.Enabled; }
            set { _button.Enabled = value; }
        }

        public int Height
        {
            get { return _button.Height; }
            set { _button.Height = value; }
        }

        public int Id
        {
            get { return _button.Id; }
        }

        public int Index
        {
            get { return _button.Index; }
        }

        public int InstanceId
        {
            get { return _button.InstanceId; }
        }

        public ShellCommandBar Parent
        {
            get { return new ShellCommandBar(_button.Parent); }
        }

        public string Parameter
        {
            get { return _button.Parameter; }
            set { _button.Parameter = value; }
        }

        public string TooltipText
        {
            get { return _button.TooltipText; }
            set { _button.TooltipText = value; }
        }

        public MsoControlType Type
        {
            get { return _button.Type; }
        }

        public bool Visible
        {
            get { return _button.Visible; }
            set { _button.Visible = value; }
        }

        public int Width
        {
            get { return _button.Width; }
            set { _button.Width = value; }
        }

        public MsoButtonStyle Style
        {
            get { return _button.Style; }
            set { _button.Style = value; }
        }

        public ShellCommandBarButton Copy(object Bar, object Before)
        {
            return new ShellCommandBarButton((CommandBarButton) _button.Copy(Bar, Before));
        }

        public void Delete(object Temporary)
        {
            _button.Delete(Temporary);
        }

        public void Execute()
        {
            _button.Execute();
        }

        public ShellCommandBarButton Move(object Bar, object Before)
        {
            return new ShellCommandBarButton((CommandBarButton) _button.Move(Bar, Before));
        }

        public void Reset()
        {
            _button.Reset();
        }

        public void SetFocus()
        {
            _button.SetFocus();
        }

        /*public StdPicture Picture
        {
            get { return _button.Picture; }
            set { _button.Picture = value; }
        }

        public StdPicture Mask
        {
            get { return _button.Mask; }
            set { _button.Mask = value; }
        }*/

        public event _CommandBarButtonEvents_ClickEventHandler Click
        {
            add { _button.Click += value; }
            remove { _button.Click -= value; }
        }
    }
}