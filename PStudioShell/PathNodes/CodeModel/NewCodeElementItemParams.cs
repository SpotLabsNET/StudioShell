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
using System.Linq;
using System.Management.Automation;
using System.Text;
using CodeOwls.StudioShell.DTE;
using CodeOwls.StudioShell.DTE.CodeModel;
using CodeOwls.StudioShell.Utility;
using EnvDTE;

namespace CodeOwls.StudioShell.PathNodes
{
    public class NewCodeElementItemParams
    {
        public NewCodeElementItemParams()
        {
            Position = -1;
            Access = AccessLevel.Default;
        }

        [Parameter(ParameterSetName = "nameSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "pathSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "Attribute")]
        [Parameter(ParameterSetName = "Class")]
        [Parameter(ParameterSetName = "Delegate")]
        [Parameter(ParameterSetName = "Enum")]
        [Parameter(ParameterSetName = "Event")]
        [Parameter(ParameterSetName = "Method")]
        [Parameter(ParameterSetName = "Property")]
        [Parameter(ParameterSetName = "Interface")]
        [Parameter(ParameterSetName = "Namespace")]
        [Parameter(ParameterSetName = "Variable")]
        public int Position { get; set; }

        [Parameter(ParameterSetName = "nameSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "pathSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "Class")]
        [Parameter(ParameterSetName = "Enum")]
        [Parameter(ParameterSetName = "Interface")]
        public string[] Bases { get; set; }

        [Parameter(ParameterSetName = "nameSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "pathSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "Class")]
        public string[] ImplementedInterfaces { get; set; }

        [Parameter(ParameterSetName = "nameSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "pathSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "Class")]
        [Parameter(ParameterSetName = "Delegate")]
        [Parameter(ParameterSetName = "Enum")]
        [Parameter(ParameterSetName = "Event")]
        [Parameter(ParameterSetName = "Method")]
        [Parameter(ParameterSetName = "Property")]
        [Parameter(ParameterSetName = "Interface")]
        [Parameter(ParameterSetName = "Variable")]
        public AccessLevel Access { get; set; }

        [Parameter(ParameterSetName = "nameSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "pathSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "Delegate")]
        [Parameter(ParameterSetName = "Event")]
        [Parameter(ParameterSetName = "Method")]
        [Parameter(ParameterSetName = "Property")]
        [Parameter(ParameterSetName = "Variable")]
        [Alias( "PropertyType", "ReturnType" )]
        public string MemberType { get; set; }

        [Parameter(ParameterSetName = "nameSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "pathSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "Method")]
        public MethodType MethodType { get; set; }

        [Parameter(ParameterSetName = "nameSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "pathSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "Property")]
        public SwitchParameter Set { get; set; }

        [Parameter(ParameterSetName = "nameSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "pathSet", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "Property")]
        public SwitchParameter Get { get; set; }

        internal vsCMFunction FunctionKind
        {
            get { return this.MethodType.ToCMFunction(); }
        }

        internal vsCMAccess AccessKind
        {
            get { return this.Access.ToCMAccess();  }
        }
    }


}
