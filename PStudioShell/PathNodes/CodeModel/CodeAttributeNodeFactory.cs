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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeOwls.StudioShell.Utility;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.PathNodes
{
    public class CodeAttributeNodeFactory : CodeElementWithChildrenNodeFactory
    {
        private readonly CodeAttribute2 _attribute;
        public CodeAttributeNodeFactory(CodeAttribute2 element) : base(element as CodeElement)
        {
            _attribute = element;
        }

        protected override string CodeItemTypeName
        {
            get { return CodeItemTypes.Attribute; }
        }

        public override IEnumerable<string> NewItemTypeNames
        {
            get { return CodeItemTypes.AttributeNewItemTypeNames; }
        }

        protected override object NewParameter(NewCodeElementItemParams newItemParams, string path, object newValue)
        {
            return _attribute.AddArgument(newValue.ToString(), path, newItemParams.Position);
        }

    }
}
