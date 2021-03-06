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
using CodeOwls.StudioShell.Paths.Utility;
using EnvDTE;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.StudioShell.Paths.Nodes.CodeModel
{
    public class CodeEnumNodeFactory : CodeElementWithChildrenNodeFactory
    {
        private readonly CodeEnum _enum;

        public CodeEnumNodeFactory(CodeEnum element) : base(element as CodeElement)
        {
            _enum = element;
        }

        protected override string CodeItemTypeName
        {
            get { return CodeItemTypes.Enum; }
        }

        public override IEnumerable<string> NewItemTypeNames
        {
            get { return CodeItemTypes.EnumNewItemTypeNames; }
        }

        protected override object NewVariable(NewCodeElementItemParams newItemParams, string path, object newItemValue)
        {
            return _enum.AddMember(
                path,
                newItemValue.ToDTEParameter(),
                newItemParams.Position);
        }

        protected override object NewAttribute(NewCodeElementItemParams p, string path, object newItemValue)
        {
            var value = null == newItemValue ? null : newItemValue.ToString();
            return _enum.AddAttribute(path,
                                      value,
                                      p.Position.ToDTEParameter());
        }
    }
}