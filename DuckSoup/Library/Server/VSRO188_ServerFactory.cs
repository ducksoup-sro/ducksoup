using System;
using System.Collections.Generic;
using System.Linq;
using API;
using API.Database.DuckSoup;
using API.Server;
using DuckSoup.Agent;
using DuckSoup.Download;
using DuckSoup.Gateway;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Server;

public class VSRO188_ServerFactory : IServerFactory
{
    public IFakeServer Create(Service service, ServerType serverType)
    {
        return serverType switch
        {
            ServerType.GatewayServer => new VSRO188_GatewayServer(service),
            ServerType.DownloadServer => new VSRO188_DownloadServer(service),
            ServerType.AgentServer => new VSRO188_AgentServer(service),
            ServerType.None => null,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public HashSet<ushort> GetWhitelist(ServerType serverType)
    {
        var defaultList = Utility.GetDefaultList(SecurityType.VSRO188);

        return serverType switch
        {
            ServerType.DownloadServer => defaultList.ClientGlobalWhitelist()
                .Concat(defaultList.ClientDownloadWhitelist()).ToHashSet(),
            ServerType.GatewayServer => defaultList.ClientGlobalWhitelist()
                .Concat(defaultList.ClientGatewayWhitelist()).ToHashSet(),
            ServerType.AgentServer => defaultList.ClientGlobalWhitelist()
                .Concat(defaultList.ClientAgentWhitelist())
                .ToHashSet(),
            ServerType.None => throw new ArgumentOutOfRangeException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public HashSet<ushort> GetBlacklist(ServerType serverType)
    {
        var defaultList = Utility.GetDefaultList(SecurityType.VSRO188);

        return serverType switch
        {
            ServerType.DownloadServer => defaultList.ClientGlobalBlacklist()
                .Concat(defaultList.ClientDownloadBlacklist()).ToHashSet(),
            ServerType.GatewayServer => defaultList.ClientGlobalBlacklist()
                .Concat(defaultList.ClientGatewayBlacklist()).ToHashSet(),
            ServerType.AgentServer => defaultList.ClientGlobalBlacklist()
                .Concat(defaultList.ClientAgentBlacklist())
                .ToHashSet(),
            ServerType.None => throw new ArgumentOutOfRangeException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}