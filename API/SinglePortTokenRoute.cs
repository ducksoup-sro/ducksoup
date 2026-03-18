using System;

namespace API;

public sealed class SinglePortTokenRoute
{
    public SinglePortTokenRoute(string host, ushort port, DateTime createdAtUtc)
    {
        Host = host;
        Port = port;
        CreatedAtUtc = createdAtUtc;
    }

    public string Host { get; }
    public ushort Port { get; }
    public DateTime CreatedAtUtc { get; }
}
