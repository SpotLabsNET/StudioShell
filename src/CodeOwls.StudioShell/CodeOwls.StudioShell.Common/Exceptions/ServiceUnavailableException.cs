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
    public class ServiceUnavailableException : StudioShellException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ServiceUnavailableException()
        {
        }

        public ServiceUnavailableException(Type missingServiceType) : 
            base( "The Visual Studio service type [" + missingServiceType.FullName + "] was not available from the service provider.")
        {
        }

        public ServiceUnavailableException(Type missingServiceType, string message ) :
            base( "The Visual Studio service type [" + missingServiceType.FullName + "] was not available from the service provider.  " + message )
        {
        }

        protected ServiceUnavailableException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
