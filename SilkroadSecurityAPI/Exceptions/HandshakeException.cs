using System;

namespace SilkroadSecurityAPI.Exceptions;

public class HandshakeException : Exception
{
    public HandshakeException(string message) : base(string.Format(message))
    {
    }

    public HandshakeException(string message, Exception innerException) : base(message, innerException)
    {
    }
}