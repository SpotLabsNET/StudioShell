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

namespace CodeOwls.PowerShell.Paths.Exceptions
{
    [Serializable]
    public class CopyOrMoveToNonexistentContainerException : ProviderException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CopyOrMoveToNonexistentContainerException()
        {           
        }

        public CopyOrMoveToNonexistentContainerException(string copyPath)
            : base("No item container exists at [" + copyPath + "], you cannot copy or move items there.")
        {
        }

        protected CopyOrMoveToNonexistentContainerException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
