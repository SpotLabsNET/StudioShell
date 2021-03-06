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
using System.Runtime.Serialization;

namespace CodeOwls.StudioShell.Common.Exceptions
{
    [Serializable]
    public class CodeModelNodeDoesNotSupportItemTypeException : StudioShellException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CodeModelNodeDoesNotSupportItemTypeException()
        {
        }

        public CodeModelNodeDoesNotSupportItemTypeException(string elementType, string newElementType) 
            : base( String.Format( "The code element type [{0}] does not support the new-item cmdlet item type [{1}]", elementType,newElementType))
        {
        }

        protected CodeModelNodeDoesNotSupportItemTypeException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class PropertyDoesNotSupportParametersException : StudioShellException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public PropertyDoesNotSupportParametersException()
        {
        }

        public PropertyDoesNotSupportParametersException(string propertyName)
            : base(String.Format("The property [{0}] does not support parameters", propertyName))
        {
        }

        protected PropertyDoesNotSupportParametersException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
