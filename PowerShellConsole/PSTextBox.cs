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


// Copyright (C) Microsoft Corporation. All rights reserved.

using System;
using System.Drawing;
using System.Linq;
using System.Management.Automation.Host;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CodeOwls.PowerShell.WinForms.AutoComplete;
using CodeOwls.PowerShell.WinForms.Configuration;
using CodeOwls.PowerShell.WinForms.History;
using Size = System.Drawing.Size;

namespace CodeOwls.PowerShell.Host
{
    [Guid("e9ce9b2a-88d1-48aa-843d-efded9cb8056")]
    [ComVisible(true)]
    public sealed class PSTextBox : RichTextBox 
    {
        private AutoResetEvent _commandEnteredEvent;
        private int _inputLength;

        private int _promptPosition;
        private string _tabExpansionInput;
        private bool _doInputEntryMode;

        public PSTextBox()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            _commandEnteredEvent = new AutoResetEvent(false);
            IsInputEntryModeEnabled = true;
        }

        internal IAutoCompleteWalker AutoCompleteWalker { get; set; }               
        internal IHistoryStackWalker HistoryStackWalker { get; set; }

        public WaitHandle CommandEnteredEvent
        {
            get { return _commandEnteredEvent; }
        }

        public int EndOfLinePosition
        {
            get { return _promptPosition + _inputLength + 1; }
        }

        public Size ConsoleSizeInCharacters
        {
            get
            {
                Size size = GetConsoleSizeInCharacters();
                return size;
            }
        }

        public bool IsInputEntryModeEnabled
        {
            get { return _doInputEntryMode; }
            set { _doInputEntryMode = value; }
        }

        public bool KeyAvailable
        {
            get { return (_promptPosition < SelectionStart); }
        }

        public void Apply(UISettings settings)
        {
            MethodInvoker mi = () =>
                                   {
                                       Color fg = settings.ForegroundColor;
                                       Color bg = settings.BackgroundColor;
                                       Font = new Font(settings.FontName, settings.FontSize,
                                                       settings.FontStyle);
                                       ForeColor = Color.FromArgb(fg.R, fg.G, fg.B);
                                       BackColor = Color.FromArgb(bg.R, bg.G, bg.B);
                                   };
            if (InvokeRequired)
            {
                Invoke(mi);
                return;
            }
            mi.Invoke();
        }

        private bool _disposed;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposed = true;
                if (null != _commandEnteredEvent)
                {
                    _commandEnteredEvent.Close();
                    _commandEnteredEvent = null;
                }
            }
            base.Dispose(disposing);
        }

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //Size = new Size(538, 350); 
            Dock = DockStyle.Fill;
            AcceptsTab = true;
            Location = new Point(0, 0);
            Multiline = true;
            Name = "psTextBox";
            TabIndex = 0;
            ReadOnly = true;
            
            Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            KeyDown += HandleKeyDown;
            KeyPress += HandleKeyPress;
        }

        Size GetConsoleSizeInCharacters()
        {
            Size size = new Size();
            if (_disposed)
            {
                return size;
            } 
            
            if (InvokeRequired)
            {
                MethodInvoker inv = () => size = GetConsoleSizeInCharacters();
                Invoke(inv);
                return size;
            }
            
            using (Graphics g = CreateGraphics())
            {
                Size charSize1 = TextRenderer.MeasureText(g, "<W>", Font);
                Size charSize2 = TextRenderer.MeasureText(g, "<>", Font);
                Size charSize = charSize1 - charSize2;

                Size border = SystemInformation.Border3DSize;

                int scrollbar = SystemInformation.VerticalScrollBarWidth;

                size = new Size(
                    Convert.ToInt32(
                        Math.Floor(
                            (float) (ClientSize.Width - border.Width - scrollbar)/
                            charSize.Width)
                        ),
                    Convert.ToInt32(
                        Math.Floor((float) (ClientSize.Height - border.Height)/
                                   charSize1.Height)
                        )
                    );
                size.Width -= 1;
            }

            return size;
        }

        private void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
            if (Char.IsLetterOrDigit(e.KeyChar) ||
                Char.IsPunctuation(e.KeyChar) ||
                Char.IsSeparator(e.KeyChar) ||
                Char.IsSymbol(e.KeyChar))
            {
                if (IsInputEntryModeEnabled)
                {
                    InsertUserInput(e.KeyChar.ToString());
                    e.Handled = true;
                }
            }
            else if (char.IsControl(e.KeyChar))
            {
                if ((new[] {'\r', '\n'}).Contains(e.KeyChar))
                {
                    if (0 == SelectionLength)
                    {
                        Select(EndOfLinePosition, 0);
                    }
                    InsertText(e.KeyChar.ToString());
                }
                e.Handled = true;
            }
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && !( e.Shift || e.Alt ) )
            {
                HandleControlKeyDown(sender, e);
                return;
            }

            e.Handled = true;
            if (Keys.Escape == e.KeyCode)
            {
                Select(_promptPosition, EndOfLinePosition);
                UpdateCountsAndDeleteSelection();
                FlushInputBuffer();
            }
            else if (Keys.Enter == e.KeyCode)
            {
                NotifyCommandEntered();
            }
            else if (Keys.Tab == e.KeyCode)
            {
                if (String.IsNullOrEmpty(_tabExpansionInput))
                {
                    Select(_promptPosition, SelectionStart);
                    _tabExpansionInput = SelectedText;
                }

                string cmd = String.Empty;
                if (!e.Shift)
                {
                    cmd = AutoCompleteWalker.NextUp(_tabExpansionInput);
                }
                else
                {
                    cmd = AutoCompleteWalker.NextDown(_tabExpansionInput);
                }

                if (String.IsNullOrEmpty(cmd))
                {
                    return;
                }

                Select(_promptPosition, EndOfLinePosition);
                InsertText(cmd);
            }
            else if (Keys.PageUp == e.KeyCode)
            {
                string cmd = HistoryStackWalker.Oldest();
                if (String.IsNullOrEmpty(cmd))
                {
                    return;
                }
                InsertHistoryItem(cmd.Trim());
            }
            else if (Keys.PageDown == e.KeyCode)
            {
                string cmd = HistoryStackWalker.Newest();
                if (String.IsNullOrEmpty(cmd))
                {
                    return;
                }
                InsertHistoryItem(cmd.Trim());
            }
            else if (Keys.Up == e.KeyCode)
            {
                string cmd = HistoryStackWalker.NextUp();
                if (String.IsNullOrEmpty(cmd))
                {
                    return;
                }
                InsertHistoryItem(cmd.Trim());
            }
            else if (Keys.Down == e.KeyCode)
            {
                string cmd = HistoryStackWalker.NextDown();
                if (String.IsNullOrEmpty(cmd))
                {
                    return;
                }
                InsertHistoryItem(cmd.Trim());
            }
            else if (Keys.Back == e.KeyCode)
            {
                if (SelectionStart > _promptPosition)
                {
                    if (SelectionLength == 0)
                    {
                        int index = SelectionStart - 1;
                        Select(index, 1);
                    }
                    UpdateCountsAndDeleteSelection();
                }
            }
            else if (Keys.Delete == e.KeyCode)
            {
                if (EndOfLinePosition > SelectionStart)
                {
                    if (SelectionLength == 0)
                    {
                        int index = SelectionStart;
                        Select(index, 1);
                    }
                    UpdateCountsAndDeleteSelection();
                }
            }
            else if (Keys.Home == e.KeyCode)
            {
                MoveCaretHome( e.Shift );
            }
            else if (Keys.End == e.KeyCode)
            {
                MoveCaretEOL( e.Shift );
            }
            else
            {
                e.Handled = false;
            }
        }

        private void HandleControlKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if (Keys.V == e.KeyCode)
            {
                VerifySelectionForTextInsert();
                
                string input = Clipboard.GetText(TextDataFormat.Text);
                InsertUserInput(input);
            }
            else if (Keys.C == e.KeyCode)
            {
                Copy();
            }
            else if (Keys.X == e.KeyCode)
            {
                Cut();
                if ((SelectionStart + SelectionLength) > _promptPosition)
                {
                    FlushInputBuffer();
                }
            }
            else if (Keys.Home == e.KeyCode)
            {
                SelectionStart = 0;
                ScrollToCaret();
            }
            else if (Keys.End == e.KeyCode)
            {
                SelectionStart = EndOfLinePosition;
                ScrollToCaret();
            }
            else if (Keys.Up == e.KeyCode)
            {
                int lineIndex = GetLineFromCharIndex(SelectionStart);
                lineIndex = Math.Max(0, lineIndex - 1);
                int charIndex = GetFirstCharIndexFromLine(lineIndex);
                Select(charIndex, 0);
                ScrollToCaret();
            }
            else if (Keys.Down == e.KeyCode)
            {
                int lineIndex = GetLineFromCharIndex(SelectionStart);
                lineIndex = Math.Min(Lines.Count() - 1, lineIndex + 1);
                int charIndex = GetFirstCharIndexFromLine(lineIndex);
                Select(charIndex, 0);
                ScrollToCaret();
            }
            else
            {
                e.Handled = false;
            }
        }

        private void VerifySelectionForTextInsert()
        {
            if (SelectionStart < _promptPosition)
            {
                Select(EndOfLinePosition, 1);
            }
        }

        private void InsertHistoryItem(string cmd)
        {
            Select(_promptPosition, _inputLength);

            ResetCountsAndInsertText(cmd);
        }

        private void MoveCaretEOL( bool extendSelection )
        {
            if (!extendSelection)
            {
                Select(EndOfLinePosition, 0);
            }
            else
            {
                Select( SelectionStart, EndOfLinePosition - SelectionStart);
            }
        }

        private void MoveCaretHome(bool extendSelection)
        {
            if (!extendSelection)
            {
                Select(_promptPosition, 0);
            }
            else
            {
                Select(_promptPosition, SelectionStart - _promptPosition );
            }
        }

        private void ResetCountsAndInsertText(string s)
        {
            _inputLength = 0;
            InsertText(s);
        }

        private void InsertText(string s)
        {
            if( !IsInputEntryModeEnabled)
            {
                return;
            }

            if (SelectionStart >= _promptPosition)
            {
                ReadOnly = false;
                SelectedText = s;
                ReadOnly = true;

                _inputLength += s.Length;
            }
        }

        private void InsertUserInput(string s)
        {
            if (SelectionStart < _promptPosition)
            {
                SelectionStart = _promptPosition;
            }
            
            ReadOnly = false;
            SelectedText = s;
            ReadOnly = true;
            _inputLength += s.Length;
            _tabExpansionInput = null;
        }

        private void NotifyCommandEntered()
        {
            if (IsInputEntryModeEnabled)
            {
                _commandEnteredEvent.Set();
            }
        }

        private void UpdateCountsAndDeleteSelection()
        {
            _inputLength -= SelectionLength;
            DeleteSelection();
        }

        private void DeleteSelection()
        {
            InsertText(String.Empty);
        }

        public KeyInfo ReadNextKey()
        {
            var info = new KeyInfo();
            if (_disposed)
            {
                return info;
            } 
            
            if (!InvokeRequired)
            {
                throw new InvalidOperationException("you cannot use ReadNextKey from the UI thread");
            }

            var hold = new ManualResetEvent(false);
            try
            {
                KeyEventHandler handler = (s, a) =>
                                              {
                                                  info.VirtualKeyCode = a.KeyValue;
                                                  info.Character =
                                                      (char)a.KeyValue;
                                                  hold.Set();
                                              };

                KeyDown += handler;
                hold.WaitOne();
                KeyDown -= handler;
            }
            finally
            {
                hold.Close();
            }
            return info;
        }

        public void FlushInputBuffer()
        {
            if (_disposed)
            {
                return;
            }

            if (InvokeRequired)
            {
                MethodInvoker mi = FlushInputBuffer;
                Invoke(mi, null);
                return;
            }

            Select(_promptPosition, _inputLength);
            UpdateCountsAndDeleteSelection();
        }

        public void WritePrompt(string str)
        {
            if (_disposed)
            {
                return;
            }
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) (() => WritePrompt(str)));
                return;
            }

            AppendText(str);
            _promptPosition = SelectionStart;
        }

        public void WritePrompt(string str, Color foreColor, Color backColor)
        {
            if (_disposed)
            {
                return;
            }
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) (() => WritePrompt(str, foreColor, backColor)));
                return;
            }

            Write(str, foreColor, backColor);
            _promptPosition = SelectionStart;
        }

        public void Write(string str)
        {
            if (_disposed)
            {
                return;
            }
            if (String.IsNullOrEmpty(str))
            {
                return;
            }

            if (InvokeRequired)
            {
                Invoke((MethodInvoker) (() => Write(str)));
                return;
            }

            AppendText(str);
            _promptPosition = SelectionStart;
        }

        public void WriteLine(string value)
        {
            if (_disposed)
            {
                return;
            }
            Write(value + "\r\n");
        }

        public void Write(string value, FontStyle style, Color color, Color backgroundColor)
        {
            if (_disposed)
            {
                return;
            }

            if (InvokeRequired)
            {
                MethodInvoker mi = () => Write(value, style, color, backgroundColor);
                Invoke(mi, null);
                return;
            }

            Font existingFont = SelectionFont;
            Color existingColor = SelectionColor;
            Color existingBackColor = SelectionBackColor;
            SelectionColor = color;
            SelectionBackColor = backgroundColor;
            using (SelectionFont = new Font(Font, style))
            {
                Write(value);
            }
            SelectionColor = existingColor;
            SelectionBackColor = existingBackColor;
            SelectionFont = existingFont;
        }

        public void WriteLine(string value, FontStyle style, Color color, Color backgroundColor)
        {
            if (_disposed)
            {
                return;
            }

            if (InvokeRequired)
            {
                MethodInvoker mi = () => WriteLine(value, style, color, backgroundColor);
                Invoke(mi, null);
                return;
            }

            Font existingFont = SelectionFont;
            Color existingColor = SelectionColor;
            SelectionColor = color;
            using (SelectionFont = new Font(Font, style))
            {
                Write(value + "\r\n");
            }
            SelectionColor = existingColor;
            SelectionFont = existingFont;
        }

        public string ReadLine()
        {
            string input = null;
            if (InvokeRequired)
            {
                MethodInvoker mi = () => input = ReadLine();
                Invoke(mi, null);
                return input;
            }
            int pos = SelectionStart;
            int len = SelectionLength;
            Select(_promptPosition, _inputLength);
            input = SelectedText;
            Select(pos, len);
            return Regex.Replace( input, "[\r\n]+", String.Empty );
        }

        public void Write(string value, Color foregroundColor, Color backgroundColor)
        {
            if (_disposed)
            {
                return;
            }
            if (InvokeRequired)
            {
                MethodInvoker mi = () => Write(value, foregroundColor, backgroundColor);
                Invoke(mi);
                return;
            }

            Color existingFg = SelectionColor;
            Color existingBg = SelectionBackColor;

            SelectionColor = foregroundColor;
            SelectionBackColor = backgroundColor;
            Write(value);

            SelectionColor = existingFg;
            SelectionBackColor = existingBg;
        }

        public IntPtr GetSafeWindowHandle()
        {
            if (_disposed)
            {
                return IntPtr.Zero;
            }
            if( InvokeRequired )
            {
                IntPtr value = IntPtr.Zero;
                MethodInvoker mi = () => value = GetSafeWindowHandle();
                Invoke(mi);
                return value;
            }

            return Handle;
        }


        public void ClearBuffer()
        {
            if( InvokeRequired )
            {
                MethodInvoker mi = () => ClearBuffer();
                Invoke(mi);
                return;
            }

            Clear();
        }
    }
}
