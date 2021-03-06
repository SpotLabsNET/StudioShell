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
using CodeOwls.PowerShell.Provider.Attributes;
using CodeOwls.StudioShell.Paths.Utility;
using EnvDTE;
using EnvDTE80;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.StudioShell.Paths.Nodes.CodeModel
{
    [CmdletHelpPathID("CodeEvent")]
    public class CodeVariableNodeFactory : CodeElementWithChildrenNodeFactory
    {
        private readonly CodeVariable2 _element;

        public CodeVariableNodeFactory(CodeVariable2 element) : base(element as CodeElement)
        {
            _element = element;
        }

        protected override string CodeItemTypeName
        {
            get { return CodeItemTypes.Variable; }
        }

        public override IEnumerable<string> NewItemTypeNames
        {
            get { return CodeItemTypes.VariableNewItemTypeNames; }
        }

        protected override object NewAttribute(NewCodeElementItemParams p, string path, object newItemValue)
        {
            var value = null == newItemValue ? null : newItemValue.ToString();
            return _element.AddAttribute(path,
                                         value,
                                         p.Position.ToDTEParameter());
        }
    }
}