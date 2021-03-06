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
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Items.CodeModel
{
    public class ShellCodeParameter : ShellCodeModelElement2
    {
        private readonly CodeParameter2 _parameter;

        internal ShellCodeParameter(CodeParameter2 parameter) : base(parameter as CodeElement2)
        {
            _parameter = parameter;
        }

        public ShellCodeTypeReference Type
        {
            get { return new ShellCodeTypeReference(_parameter.Type as CodeTypeRef2); }
            set { _parameter.Type = value.AsCodeTypeRef(); }
        }

        public IEnumerable<IShellCodeModelElement2> Attributes
        {
            get { return GetEnumerator(_parameter.Attributes); }
        }

        public string DocComment
        {
            get { return _parameter.DocComment; }
            set { _parameter.DocComment = value; }
        }

        public vsCMParameterKind ParameterKind
        {
            get { return _parameter.ParameterKind; }
            set { _parameter.ParameterKind = value; }
        }

        public string DefaultValue
        {
            get { return _parameter.DefaultValue; }
            set { _parameter.DefaultValue = value; }
        }

        public ShellCodeAttribute AddAttribute(string Name, string Value, object Position)
        {
            return new ShellCodeAttribute(_parameter.AddAttribute(Name, Value, Position) as CodeAttribute2);
        }
    }
}