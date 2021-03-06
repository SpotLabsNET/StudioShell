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

namespace CodeOwls.StudioShell.Paths.Items.CodeModel
{
    public class ShellCodeTypeReference : NullShellCodeModelElement2
    {
        private readonly CodeTypeRef2 _typeRef;

        internal ShellCodeTypeReference(CodeTypeRef2 typeRef)
        {
            _typeRef = typeRef;
        }

        public vsCMTypeRef TypeKind
        {
            get { return _typeRef.TypeKind; }
        }

        public ShellCodeType CodeType
        {
            get { return new ShellCodeType(_typeRef.CodeType); }
            set { _typeRef.CodeType = value.AsCodeType(); }
        }

        public ShellCodeTypeReference ElementType
        {
            get { return new ShellCodeTypeReference(_typeRef.ElementType as CodeTypeRef2); }
            set { _typeRef.ElementType = value.AsCodeTypeRef(); }
        }

        public string AsString
        {
            get { return _typeRef.AsString; }
        }

        public string AsFullName
        {
            get { return _typeRef.AsFullName; }
        }

        public int Rank
        {
            get { return _typeRef.Rank; }
            set { _typeRef.Rank = value; }
        }

        public bool IsGeneric
        {
            get { return _typeRef.IsGeneric; }
        }

        public ShellCodeTypeReference CreateArrayType(int Rank)
        {
            return new ShellCodeTypeReference(_typeRef.CreateArrayType(Rank) as CodeTypeRef2);
        }

        internal CodeTypeRef AsCodeTypeRef()
        {
            return _typeRef;
        }
    }
}