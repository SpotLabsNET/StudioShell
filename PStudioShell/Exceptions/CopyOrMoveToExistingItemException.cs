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
using System.Runtime.Serialization;
using System.Text;

namespace CodeOwls.StudioShell.Exceptions
{
    [Serializable]
    public class CopyOrMoveToExistingItemException : StudioShellException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CopyOrMoveToExistingItemException()
        {
            
        }

        public CopyOrMoveToExistingItemException(string copyPath) 
            : base("An item exists at [" + copyPath + "], you must use the -Force parameter to copy or move an item to this location.")
        {
        }

        protected CopyOrMoveToExistingItemException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class CopyOrMoveItemInternalException : StudioShellException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CopyOrMoveItemInternalException()
        {

        }

        public CopyOrMoveItemInternalException(string path, string copyPath, Exception e)
            : base( String.Format("An internal error occurred attempting to copy or move the item at [{0}] to [{1}].", path, copyPath), e )
        {
        }

        protected CopyOrMoveItemInternalException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }

    [Serializable]
    public class CopyOrMoveToNonexistentContainerException : StudioShellException
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

    [Serializable]
    public class CopyOrMoveToDifferentContainerTypeException : StudioShellException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CopyOrMoveToDifferentContainerTypeException()
        {
        }

        public CopyOrMoveToDifferentContainerTypeException(string copy, string copyPath)
            : base("The item at [" + copy + "] cannot be copied to the specified location ["+copyPath+"] because the destination contains different types of items.")
        {
        }

        protected CopyOrMoveToDifferentContainerTypeException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }

}
