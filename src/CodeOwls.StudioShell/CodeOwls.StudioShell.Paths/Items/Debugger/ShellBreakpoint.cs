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

namespace CodeOwls.StudioShell.Paths.Items.Debugger
{
    public class ShellBreakpoint
    {
        private readonly Breakpoint2 _breakpoint;

        internal ShellBreakpoint(Breakpoint2 breakpoint)
        {
            _breakpoint = breakpoint;
        }

        public dbgBreakpointType Type
        {
            get { return _breakpoint.Type; }
        }

        public string Name
        {
            get { return _breakpoint.Name; }
            set { _breakpoint.Name = value; }
        }

        public dbgBreakpointLocationType LocationType
        {
            get { return _breakpoint.LocationType; }
        }

        public string FunctionName
        {
            get { return _breakpoint.FunctionName; }
        }

        public int FunctionLineOffset
        {
            get { return _breakpoint.FunctionLineOffset; }
        }

        public int FunctionColumnOffset
        {
            get { return _breakpoint.FunctionColumnOffset; }
        }

        public string File
        {
            get { return _breakpoint.File; }
        }

        public int FileLine
        {
            get { return _breakpoint.FileLine; }
        }

        public int FileColumn
        {
            get { return _breakpoint.FileColumn; }
        }

        public dbgBreakpointConditionType ConditionType
        {
            get { return _breakpoint.ConditionType; }
        }

        public string Condition
        {
            get { return _breakpoint.Condition; }
        }

        public string Language
        {
            get { return _breakpoint.Language; }
        }

        public dbgHitCountType HitCountType
        {
            get { return _breakpoint.HitCountType; }
        }

        public int HitCountTarget
        {
            get { return _breakpoint.HitCountTarget; }
        }

        public bool Enabled
        {
            get { return _breakpoint.Enabled; }
            set { _breakpoint.Enabled = value; }
        }

        public string Tag
        {
            get { return _breakpoint.Tag; }
            set { _breakpoint.Tag = value; }
        }

        public int CurrentHits
        {
            get { return _breakpoint.CurrentHits; }
        }

        public ShellBreakpoint Parent
        {
            get
            {
                var p = _breakpoint.Parent as Breakpoint2;
                if (null == p)
                {
                    return null;
                }
                return new ShellBreakpoint(p);
            }
        }

        public ShellProcess Process
        {
            get { return new ShellProcess(_breakpoint.Process); }
        }

        public bool BreakWhenHit
        {
            get { return _breakpoint.BreakWhenHit; }
            set { _breakpoint.BreakWhenHit = value; }
        }

        public string Message
        {
            get { return _breakpoint.Message; }
            set { _breakpoint.Message = value; }
        }

        public string Macro
        {
            get { return _breakpoint.Macro; }
            set { _breakpoint.Macro = value; }
        }

        public string FilterBy
        {
            get { return _breakpoint.FilterBy; }
            set { _breakpoint.FilterBy = value; }
        }

        public void Delete()
        {
            _breakpoint.Delete();
        }

        public void ResetHitCount()
        {
            _breakpoint.ResetHitCount();
        }
    }
}