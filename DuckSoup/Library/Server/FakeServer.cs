using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using API.Database.DuckSoup;
using API.Server;
using API.ServiceFactory;
using NetCoreServer;
using PacketLibrary.Handler;
using Serilog;

namespace DuckSoup.Library.Server;

public class FakeServer : TcpServer, IFakeServer
{
    public FakeServer(Service service) : base(service.LocalMachine_Machine.Address, service.BindPort)
    {
        Service = service;
        var factory = ServiceFactory.Load<IServerManager>(typeof(IServerManager))
            .GetServiceFactory(service.SecurityType);

        PacketHandler = new PacketHandler(
            factory.GetWhitelist(service.ServerType),
            factory.GetBlacklist(service.ServerType)
        );

        Log.Information("{0} - Debuglevel: {1}", Service.Name,
            SharedObjects.DebugLevel);
        Log.Information("{0} - Servertype: {1}", Service.Name,
            Service.ServerType);
        Log.Information("{0} - SecurityType: {1}", Service.Name,
            Service.SecurityType);
        Log.Information("{0} - Setting up Socket..", Service.Name);
        Log.Information("{0} - Server bound to {1}", Service.Name,
            Service.BindPort);
        Log.Information("{0} - Redirecting Sessions to {1}", Service.Name,
            Service.RemoteMachine_Machine.Address);
    }

    public Service Service { get; }
    public IPacketHandler PacketHandler { get; }

    public Task Start()
    {
        base.Start();
        return Task.CompletedTask;
    }


    protected override TcpSession CreateSession()
    {
        return new FakeSession(this, Service);
    }

    protected override void OnError(SocketError error)
    {
        Console.WriteLine($"FakeServer caught an error with code {error}");
    }

    public virtual void RemoveSession(ISession session)
    {
    }

    public virtual void AddSession(ISession session)
    {
    }
}