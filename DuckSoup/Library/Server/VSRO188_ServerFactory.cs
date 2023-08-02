using System;
using API;
using API.Database.DuckSoup;
using DuckSoup.Agent;
using DuckSoup.Download;
using DuckSoup.Gateway;

namespace DuckSoup.Library.Server;

public class VSRO188_ServerFactory : IServerFactory
{
    public FakeServer Create(Service service, ServerType serverType)
    {
        return serverType switch
        {
            ServerType.GatewayServer => new VSRO188_GatewayServer(service),
            ServerType.DownloadServer => new VSRO188_DownloadServer(service),
            ServerType.AgentServer => new VSRO188_AgentServer(service),
            ServerType.None => null,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}
