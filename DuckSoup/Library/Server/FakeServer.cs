using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using API;
using API.Database.DuckSoup;
using Microsoft.IdentityModel.Tokens;
using NetCoreServer;
using PacketLibrary.Handler;
using SilkroadSecurityAPI;
using Utility = SilkroadSecurityAPI.Utility;

namespace DuckSoup.Library.Server;

public class FakeServer : TcpServer
{
    public Service Service { get; }

    public FakeServer(Service service) : base(service.LocalMachine_Machine.Address, service.BindPort)
    {
        Service = service;
        
        var defaultList = Utility.GetDefaultList(service.SecurityType);

        switch (service.ServerType)
        {
            case ServerType.None:
                break;
            case ServerType.DownloadServer:
                break;
            case ServerType.GatewayServer:
                break;
            case ServerType.AgentServer:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        PacketHandler = new PacketHandler(
            new HashSet<ushort>(defaultList.ClientGlobalWhitelist().Concat(defaultList.ClientAgentWhitelist())),
            new HashSet<ushort>(defaultList.ClientGlobalBlacklist().Concat(defaultList.ClientAgentBlacklist()))
        );
    }

    public PacketHandler? PacketHandler { get; set; }

    protected override TcpSession CreateSession()
    {
        return new FakeSession(this, Service);
    }

    protected override void OnError(SocketError error)
    {
        Console.WriteLine($"FakeServer caught an error with code {error}");
    }
}