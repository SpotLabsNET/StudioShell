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
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.StudioShell.Paths.Nodes.CodeModel
{
    internal static class CodeItemTypes
    {
        public const string Parameter = "parameter";
        public const string Attribute = "attribute";
        public const string Class = "class";
        public const string Delegate = "delegate";
        public const string Enum = "enum";
        public const string Event = "event";
        public const string Method = "method";
        public const string Property = "property";
        public const string Interface = "interface";
        public const string Namespace = "namespace";
        public const string Struct = "struct";
        public const string Variable = "variable";
        public const string Import = "import";

        public static IEnumerable<string> ClassNewItemTypeNames
        {
            get
            {
                return new[]
                           {
                               Attribute,
                               Class,
                               Delegate,
                               Enum,
                               Event,
                               Method,
                               Interface,
                               Property,
                               Struct,
                               Variable,
                           };
            }
        }

        public static IEnumerable<string> NamespaceNewItemTypeNames
        {
            get
            {
                return new[]
                           {
                               Class,
                               Delegate,
                               Enum,
                               Interface,
                               Namespace,
                               Struct,
                           };
            }
        }

        public static IEnumerable<string> StructNewItemTypeNames
        {
            get { return ClassNewItemTypeNames; }
        }

        public static IEnumerable<string> InterfaceNewItemTypeNames
        {
            get
            {
                return new[]
                           {
                               Attribute,
                               Event,
                               Method,
                               Property,
                           };
            }
        }

        public static IEnumerable<string> EnumNewItemTypeNames
        {
            get
            {
                return new[]
                           {
                               Attribute,
                               Variable,
                           };
            }
        }

        public static IEnumerable<string> ParameterNewItemTypeNames
        {
            get
            {
                return new[]
                           {
                               Attribute,
                           };
            }
        }

        public static IEnumerable<string> PropertyNewItemTypeNames
        {
            get
            {
                return new[]
                           {
                               Parameter,
                               Attribute,
                           };
            }
        }

        public static IEnumerable<string> MethodNewItemTypeNames
        {
            get
            {
                return new[]
                           {
                               Parameter,
                               Attribute,
                           };
            }
        }

        public static IEnumerable<string> DelegateNewItemTypeNames
        {
            get
            {
                return new[]
                           {
                               Parameter,
                               Attribute,
                           };
            }
        }

        public static IEnumerable<string> EventNewItemTypeNames
        {
            get
            {
                return new[]
                           {
                               Attribute,
                           };
            }
        }

        public static IEnumerable<string> AttributeNewItemTypeNames
        {
            get
            {
                return new[]
                           {
                               Parameter,
                           };
            }
        }

        public static IEnumerable<string> VariableNewItemTypeNames
        {
            get
            {
                return new[]
                           {
                               Attribute,
                           };
            }
        }

        public static IEnumerable<string> AttributeArgumentNewItemTypeNames
        {
            get { return new string[] {}; }
        }

        public static IEnumerable<string> FileCodeModelItemTypes
        {
            get
            {
                return new[]
                           {
                               Namespace,
                               Class,
                               Import
                           };
            }
        }

        public static IEnumerable<string> GetNewItemTypeNames(string codeItemTypeName)
        {
            switch (codeItemTypeName)
            {
                case (Attribute):
                    return AttributeNewItemTypeNames;
                case (Class):
                    return ClassNewItemTypeNames;
                case (Delegate):
                    return DelegateNewItemTypeNames;
                case (Enum):
                    return EnumNewItemTypeNames;
                case (Event):
                    return EventNewItemTypeNames;
                case (Method):
                    return MethodNewItemTypeNames;
                case (Property):
                    return PropertyNewItemTypeNames;
                case (Interface):
                    return InterfaceNewItemTypeNames;
                case (Namespace):
                    return NamespaceNewItemTypeNames;
                case (Struct):
                    return StructNewItemTypeNames;
                case (Variable):
                    return VariableNewItemTypeNames;
            }

            return null;
        }
    }
}