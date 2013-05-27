using System;
using System.Runtime.Serialization;

namespace CodeOwls.PowerShell.Host.Exceptions
{
    [Serializable]
    public class InvalidUnsupportedConsoleConfigurationException : HostException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public InvalidUnsupportedConsoleConfigurationException()
        {
        }

        public InvalidUnsupportedConsoleConfigurationException(string message) : base(message)
        {
        }

        public InvalidUnsupportedConsoleConfigurationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidUnsupportedConsoleConfigurationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
