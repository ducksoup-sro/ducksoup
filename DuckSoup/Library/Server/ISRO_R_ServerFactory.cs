using System;
using API;
using API.Database.DuckSoup;
using DuckSoup.Agent;
using DuckSoup.Download;
using DuckSoup.Gateway;

namespace DuckSoup.Library.Server;

public class ISRO_R_ServerFactory : IServerFactory
{
    public FakeServer Create(Service service, ServerType serverType)
    {
        return serverType switch
        {
            ServerType.GatewayServer => new ISRO_R_GatewayServer(service),
            ServerType.DownloadServer => new ISRO_R_DownloadServer(service),
            ServerType.AgentServer => new ISRO_R_AgentServer(service),
            ServerType.None => null,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}