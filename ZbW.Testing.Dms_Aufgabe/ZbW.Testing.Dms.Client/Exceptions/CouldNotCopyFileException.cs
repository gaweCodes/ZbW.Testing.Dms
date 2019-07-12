using System;

namespace ZbW.Testing.Dms.Client.Exceptions
{
    public class CouldNotCopyFileException : Exception
    {
        public CouldNotCopyFileException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
