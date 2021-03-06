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
using CodeOwls.PowerShell.Provider.Attributes;
using CodeOwls.StudioShell.Paths.Utility;
using EnvDTE;
using EnvDTE80;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.StudioShell.Paths.Nodes.CodeModel
{
    [CmdletHelpPathID("CodeClass")]
    public class CodeStructNodeFactory : CodeElementWithChildrenNodeFactory
    {
        private readonly CodeStruct2 _struct;

        public CodeStructNodeFactory(CodeStruct2 element) : base(element as CodeElement)
        {
            _struct = element;
        }

        protected override string CodeItemTypeName
        {
            get { return CodeItemTypes.Struct; }
        }

        public override IEnumerable<string> NewItemTypeNames
        {
            get { return CodeItemTypes.StructNewItemTypeNames; }
        }

        protected override object NewEvent(NewCodeElementItemParams newCodeElementItemParams, string path)
        {
            return _struct.AddEvent(
                path,
                newCodeElementItemParams.MemberType,
                false,
                Type.Missing,
                newCodeElementItemParams.Access.ToCMAccess()
                );
        }

        protected override object NewVariable(NewCodeElementItemParams newItemParams, string path, object value)
        {
            return _struct.AddVariable(path,
                                       newItemParams.MemberType,
                                       newItemParams.Position,
                                       newItemParams.AccessKind,
                                       Type.Missing);
        }

        protected override object NewProperty(NewCodeElementItemParams newItemParams, string path)
        {
            return _struct.AddProperty(newItemParams.Get ? path : null,
                                       newItemParams.Set ? path : null,
                                       newItemParams.MemberType,
                                       newItemParams.Position,
                                       newItemParams.AccessKind,
                                       Type.Missing);
        }

        protected override object NewStruct(NewCodeElementItemParams newItemParams, string path)
        {
            return _struct.AddStruct(path,
                                     newItemParams.Position,
                                     newItemParams.Bases.ToCSVDTEParameter(),
                                     newItemParams.ImplementedInterfaces.ToCSVDTEParameter(),
                                     newItemParams.AccessKind);
        }

        protected override object NewMethod(NewCodeElementItemParams newItemParams, string path)
        {
            return _struct.AddFunction(path,
                                       newItemParams.FunctionKind,
                                       newItemParams.MemberType,
                                       newItemParams.Position,
                                       newItemParams.AccessKind,
                                       Type.Missing);
        }

        protected override object NewEnum(NewCodeElementItemParams newItemParams, string path)
        {
            return _struct.AddEnum(path,
                                   newItemParams.Position,
                                   newItemParams.Bases.ToCSVDTEParameter(),
                                   newItemParams.AccessKind);
        }

        protected override object NewDelegate(NewCodeElementItemParams newItemParams, string path)
        {
            return _struct.AddDelegate(path,
                                       newItemParams.MemberType,
                                       newItemParams.Position,
                                       newItemParams.AccessKind
                );
        }

        protected override object NewClass(NewCodeElementItemParams newItemParams, string path)
        {
            return _struct.AddClass(path,
                                    newItemParams.Position,
                                    newItemParams.Bases.ToCSVDTEParameter(),
                                    newItemParams.ImplementedInterfaces.ToCSVDTEParameter(),
                                    newItemParams.AccessKind
                );
        }

        protected override object NewAttribute(NewCodeElementItemParams p, string path, object newItemValue)
        {
            var value = null == newItemValue ? null : newItemValue.ToString();
            return _struct.AddAttribute(path,
                                        value,
                                        p.Position.ToDTEParameter());
        }
    }
}