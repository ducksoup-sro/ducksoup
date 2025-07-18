#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;
using API.Database.DuckSoup;
using API.Server;
using API.ServiceFactory;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;
using PacketLibrary.Handler;
using SilkroadSecurityAPI;
using SilkroadSecurityAPI.Message;
using Void = LanguageExt.Pipes.Void;

#endregion

namespace DuckSoup.Library.Server;

public class ServerManager : IServerManager
{
    private readonly Dictionary<SecurityType, IServerFactory> serverFactories = new Dictionary<SecurityType, IServerFactory>
    {
        {
            SecurityType.VSRO188, new VSRO188_ServerFactory()
        },
        {
            SecurityType.ISRO_R, new ISRO_R_ServerFactory()
        }
    };

    public ServerManager()
    {
        ServiceFactory.Register<IServerManager>(typeof(IServerManager), this);
        Servers = new List<IFakeServer>();
        using API.Database.Context.DuckSoup context = new API.Database.Context.DuckSoup();
        foreach (Service contextService in context.Services.Include(b => b.LocalMachine_Machine)
                     .Include(b => b.RemoteMachine_Machine).Include(b => b.SpoofMachine_Machine))
        {
            AddServer(contextService);
        }

        Start(true);
    }

    public List<IFakeServer> Servers { get; private set; }

    public IServerFactory GetServiceFactory(SecurityType securityType)
    {
        serverFactories.TryGetValue(securityType, out IServerFactory? result);
        return result;
    }


    public void Start()
    {
        Start(false);
    }

    public void Start(bool firstStart)
    {
        foreach (IFakeServer asyncServer in Servers.Where(asyncServer =>
                     firstStart && asyncServer.Service.AutoStart || !firstStart))
        {
            asyncServer.Start();
        }
    }

    public void Start(string name)
    {
        Start(name, false);
    }

    public void Start(string name, bool firstStart)
    {
        foreach (IFakeServer asyncServer in Servers
                     .Where(asyncServer => asyncServer.Service.Name.ToLower().Equals(name.ToLower()))
                     .Where(asyncServer => firstStart && asyncServer.Service.AutoStart || !firstStart))
        {
            asyncServer.Start();
        }
    }

    public void Start(Service service)
    {
        Start(service, false);
    }

    public void Start(Service service, bool firstStart)
    {
        foreach (IFakeServer asyncServer in Servers.Where(asyncServer => asyncServer.Service.Equals(service))
                     .Where(asyncServer => firstStart && asyncServer.Service.AutoStart || !firstStart))
        {
            asyncServer.Start();
        }
    }

    public void Stop(string name)
    {
        IFakeServer temp = null;
        foreach (IFakeServer asyncServer in Servers.Where(asyncServer =>
                     asyncServer.Service.Name.ToLower().Equals(name.ToLower())))
        {
            temp = asyncServer;
        }

        if (temp == null) return;

        temp.Dispose();
        Servers.Remove(temp);
    }

    public void Stop(Service service)
    {
        IFakeServer temp = null;
        foreach (IFakeServer asyncServer in Servers.Where(asyncServer => asyncServer.Service.Equals(service)))
        {
            temp = asyncServer;
        }

        if (temp == null) return;

        temp.Dispose();
        Servers.Remove(temp);
    }

    public Task RegisterModuleHandler<T>(ServerType serverType, Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new()
    {
        foreach (IFakeServer asyncServer in Servers.Where(asyncServer => asyncServer.Service.ServerType == serverType))
        {
            asyncServer.PacketHandler.RegisterModuleHandler(handler);
        }

        return Task.CompletedTask;
    }

    public Task RegisterModuleHandler<T>(ServerType serverType, int priority, Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new()
    {
        foreach (IFakeServer asyncServer in Servers.Where(asyncServer => asyncServer.Service.ServerType == serverType))
        {
            asyncServer.PacketHandler.RegisterModuleHandler(priority, handler);
        }

        return Task.CompletedTask;
    }

    public Task RegisterClientHandler<T>(ServerType serverType, Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new()
    {
        foreach (IFakeServer asyncServer in Servers.Where(asyncServer => asyncServer.Service.ServerType == serverType))
        {
            asyncServer.PacketHandler.RegisterClientHandler(handler);
        }

        return Task.CompletedTask;
    }

    public Task RegisterClientHandler<T>(ServerType serverType, int priority, Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new()
    {
        foreach (IFakeServer asyncServer in Servers.Where(asyncServer => asyncServer.Service.ServerType == serverType))
        {
            asyncServer.PacketHandler.RegisterClientHandler(priority, handler);
        }

        return Task.CompletedTask;
    }

    public Task UnregisterModuleHandler<T>(ServerType serverType, Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new()
    {
        foreach (IFakeServer asyncServer in Servers.Where(asyncServer => asyncServer.Service.ServerType == serverType))
        {
            asyncServer.PacketHandler.UnregisterModuleHandler(handler);
        }

        return Task.CompletedTask;
    }

    public Task UnregisterClientHandler<T>(ServerType serverType, Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new()
    {
        foreach (IFakeServer asyncServer in Servers.Where(asyncServer => asyncServer.Service.ServerType == serverType))
        {
            asyncServer.PacketHandler.UnregisterClientHandler(handler);
        }

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        if (Servers != null)
            foreach (IFakeServer asyncServer in Servers)
            {
                asyncServer.Dispose();
            }

        Servers = null;
    }

    public Result<Void> AddServer(Service service)
    {
        if (!serverFactories.TryGetValue(service.SecurityType, out IServerFactory? serverFactory))
            return new Result<Void>(new ArgumentOutOfRangeException());

        IFakeServer? server = serverFactory.Create(service, service.ServerType);

        if (server != null) Servers.Add(server);

        return new Result<Void>();
    }
}