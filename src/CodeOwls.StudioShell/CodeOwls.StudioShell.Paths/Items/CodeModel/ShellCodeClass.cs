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
using System.Linq;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Items.CodeModel
{
    public class ShellCodeClass : ShellCodeModelElement2
    {
        private readonly CodeClass2 _codeClass;

        internal ShellCodeClass(CodeClass2 codeClass) : base(codeClass as CodeElement2)
        {
            _codeClass = codeClass;
        }


        public ShellCodeNamespace Namespace
        {
            get { return new ShellCodeNamespace(_codeClass.Namespace); }
        }

        public IEnumerable<IShellCodeModelElement2> Bases
        {
            get
            {
                return from CodeElement ce in _codeClass.Bases
                       select ShellObjectFactory.CreateFromCodeElement(ce);
            }
        }

        public IEnumerable<IShellCodeModelElement2> Members
        {
            get
            {
                return from CodeElement ce in _codeClass.Members
                       select ShellObjectFactory.CreateFromCodeElement(ce);
            }
        }

        public vsCMAccess Access
        {
            get { return _codeClass.Access; }
            set { _codeClass.Access = value; }
        }

        public IEnumerable<ShellCodeAttribute> Attributes
        {
            get
            {
                return from CodeElement ce in _codeClass.Attributes
                       select new ShellCodeAttribute(ce as CodeAttribute2);
            }
        }

        public string DocComment
        {
            get { return _codeClass.DocComment; }
            set { _codeClass.DocComment = value; }
        }

        public string Comment
        {
            get { return _codeClass.Comment; }
            set { _codeClass.Comment = value; }
        }

        public IEnumerable<IShellCodeModelElement2> DerivedTypes
        {
            get
            {
                return from CodeElement ce in _codeClass.DerivedTypes
                       select ShellObjectFactory.CreateFromCodeElement(ce);
            }
        }

        public IEnumerable<IShellCodeModelElement2> ImplementedInterfaces
        {
            get
            {
                return from CodeElement ce in _codeClass.ImplementedInterfaces
                       select ShellObjectFactory.CreateFromCodeElement(ce);
            }
        }

        public bool IsAbstract
        {
            get { return _codeClass.IsAbstract; }
            set { _codeClass.IsAbstract = value; }
        }

        public vsCMClassKind ClassKind
        {
            get { return _codeClass.ClassKind; }
            set { _codeClass.ClassKind = value; }
        }

        public IEnumerable<IShellCodeModelElement2> PartialClasses
        {
            get
            {
                return from CodeElement ce in _codeClass.PartialClasses
                       select ShellObjectFactory.CreateFromCodeElement(ce);
            }
        }

        public vsCMDataTypeKind DataTypeKind
        {
            get { return _codeClass.DataTypeKind; }
            set { _codeClass.DataTypeKind = value; }
        }

        public IEnumerable<IShellCodeModelElement2> Parts
        {
            get
            {
                return from CodeElement ce in _codeClass.Parts
                       select ShellObjectFactory.CreateFromCodeElement(ce);
            }
        }

        public vsCMInheritanceKind InheritanceKind
        {
            get { return _codeClass.InheritanceKind; }
            set { _codeClass.InheritanceKind = value; }
        }

        public bool IsGeneric
        {
            get { return _codeClass.IsGeneric; }
        }

        public bool IsShared
        {
            get { return _codeClass.IsShared; }
            set { _codeClass.IsShared = value; }
        }

        public IShellCodeModelElement2 AddBase(string Base, int Position)
        {
            CodeElement ce = _codeClass.AddBase(Base, Position);
            return ShellObjectFactory.CreateFromCodeElement(ce);
        }

        public ShellCodeAttribute AddAttribute(string Name, string Value, object Position)
        {
            return new ShellCodeAttribute(_codeClass.AddAttribute(Name, Value, Position) as CodeAttribute2);
        }

        public void RemoveBase(object Element)
        {
            _codeClass.RemoveBase(Element);
        }

        public void RemoveMember(object Element)
        {
            _codeClass.RemoveMember(Element);
        }

        public ShellCodeInterface AddImplementedInterface(object Base, object Position)
        {
            return new ShellCodeInterface(_codeClass.AddImplementedInterface(Base, Position) as CodeInterface2);
        }

        public ShellCodeMethod AddFunction(string Name, vsCMFunction Kind, object Type, object Position,
                                           vsCMAccess Access, object Location)
        {
            return
                new ShellCodeMethod(
                    _codeClass.AddFunction(Name, Kind, Type, Position, Access, Location) as CodeFunction2);
        }

        public ShellCodeVariable AddVariable(string Name, object Type, object Position, vsCMAccess Access,
                                             object Location)
        {
            return new ShellCodeVariable(_codeClass.AddVariable(Name, Type, Position, Access, Location) as CodeVariable2);
        }

        public ShellCodeProperty AddProperty(string GetterName, string PutterName, object Type, object Position,
                                             vsCMAccess Access, object Location)
        {
            return
                new ShellCodeProperty(_codeClass.AddProperty(GetterName, PutterName, Type, Position, Access, Location));
        }

        public ShellCodeClass AddClass(string Name, object Position, object Bases, object ImplementedInterfaces,
                                       vsCMAccess Access)
        {
            return
                new ShellCodeClass(
                    _codeClass.AddClass(Name, Position, Bases, ImplementedInterfaces, Access) as CodeClass2);
        }

        public ShellCodeStruct AddStruct(string Name, object Position, object Bases, object ImplementedInterfaces,
                                         vsCMAccess Access)
        {
            return
                new ShellCodeStruct(
                    _codeClass.AddStruct(Name, Position, Bases, ImplementedInterfaces, Access) as CodeStruct2);
        }

        public ShellCodeEnum AddEnum(string Name, object Position, object Bases, vsCMAccess Access)
        {
            return new ShellCodeEnum(_codeClass.AddEnum(Name, Position, Bases, Access));
        }

        public ShellCodeDelegate AddDelegate(string Name, object Type, object Position, vsCMAccess Access)
        {
            return new ShellCodeDelegate(_codeClass.AddDelegate(Name, Type, Position, Access) as CodeDelegate2);
        }

        public void RemoveInterface(object Element)
        {
            _codeClass.RemoveInterface(Element);
        }

        public ShellCodeEvent AddEvent(string Name, string FullDelegateName, bool CreatePropertyStyleEvent,
                                       object Location, vsCMAccess Access)
        {
            return
                new ShellCodeEvent(_codeClass.AddEvent(Name, FullDelegateName, CreatePropertyStyleEvent, Location,
                                                       Access));
        }

        public bool IsDerivedFrom(string FullName)
        {
            return _codeClass.get_IsDerivedFrom(FullName);
        }
    }
}