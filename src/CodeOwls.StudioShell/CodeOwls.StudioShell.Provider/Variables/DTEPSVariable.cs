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


using System.Management.Automation;
using EnvDTE80;

namespace CodeOwls.StudioShell.Provider.Variables
{
    public abstract class DTEPSVariable : PSVariable
    {
        protected readonly DTE2 _dte;
        protected DTEPSVariable(DTE2 dte, string name) : base(name)
        {
            _dte = dte;
            this.Visibility = SessionStateEntryVisibility.Public;
            //this.Options = ScopedItemOptions.AllScope;
        }

        public override string ToString()
        {
            return (Value ?? "").ToString();
        }

    }
}
