using System;

namespace SilkroadSecurityAPI.Exceptions;

public class PacketFormatException : Exception
{
    
    public PacketFormatException(string message) : base(string.Format(message))
    {
    }

    public PacketFormatException(string message, Exception innerException) : base(message, innerException)
    {
    }
}