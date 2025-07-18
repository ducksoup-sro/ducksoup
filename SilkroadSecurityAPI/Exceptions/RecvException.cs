using System;

namespace SilkroadSecurityAPI.Exceptions;

public class RecvException : Exception
{
    public RecvException(string message) : base(string.Format(message))
    {
    }

    public RecvException(string message, Exception innerException) : base(message, innerException)
    {
    }
}