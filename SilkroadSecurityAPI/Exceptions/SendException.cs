using System;

namespace SilkroadSecurityAPI.Exceptions;

public class SendException : Exception
{
    
    public SendException(string message) : base(string.Format(message))
    {
    }

    public SendException(string message, Exception innerException) : base(message, innerException)
    {
    }
}