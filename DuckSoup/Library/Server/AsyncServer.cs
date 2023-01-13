#region

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using API;
using API.Database.DuckSoup;
using API.Plugin;
using API.Server;
using API.ServiceFactory;
using API.ServiceFactory.Exceptions;
using API.Session;

#endregion

namespace DuckSoup.Library.Server;

public class AsyncServer : IAsyncServer
{
    protected AsyncServer(Service service)
    {
        Service = service;
    }

    public Service Service { get; init; }
    public bool Exit { get; set; }

    public bool Started { get; set; }
    public TcpListener _tcpServer { get; set; }

    public IPacketHandler PacketHandler { get; set; }
    public IPEndPoint RemoteEndPoint { get; set; }

    public async Task Start()
    {
        if (SharedObjects.DebugLevel >= DebugLevel.Info)
        {
            Global.Logger.InfoFormat("{0} - Debuglevel: {1}", Service.Name,
                SharedObjects.DebugLevel);
            Global.Logger.InfoFormat("{0} - Servertype: {1}", Service.Name,
                Service.ServerType);
            Global.Logger.InfoFormat("{0} - Setting up Socket..", Service.Name);
        }

        // defines a binding endpoint
        var bindEndPoint = new IPEndPoint(IPAddress.Parse(Service.LocalMachine_Machine.Address), Service.BindPort);
        RemoteEndPoint = new IPEndPoint(IPAddress.Parse(Service.LocalMachine_Machine.Address), Service.RemotePort);

        // starts the listener socket for the incoming connections
        _tcpServer = new TcpListener(bindEndPoint);
        _tcpServer.Start();

        if (SharedObjects.DebugLevel >= DebugLevel.Info)
        {
            Global.Logger.InfoFormat("{0} - Server bound to {1}", Service.Name,
                bindEndPoint);
            Global.Logger.InfoFormat("{0} - Redirecting Sessions to {1}", Service.Name,
                RemoteEndPoint);
        }

        try
        {
            var tempPluginManager = ServiceFactory.Load<IPluginManager>(typeof(IPluginManager));
            if (tempPluginManager != null)
            {
                foreach (var (key, value) in tempPluginManager.Loaders)
                {
                    if (value.ServerType == Service.ServerType)
                    {
                        value.OnServerStart(this);
                    }
                }
            }
        }
        catch (ServiceNotRegisteredException e)
        {
        }
        catch (Exception e)
        {
            Global.Logger.InfoFormat("{0}", e.Message);
        }

        Started = true;
        // accepts client connections
        while (!Exit)
        {
            await _tcpServer.AcceptTcpClientAsync().ContinueWith(OnAccept, TaskScheduler.Default);
            await Task.Delay(3);
        }
    }

    public virtual void Dispose()
    {
        Exit = true;
        _tcpServer?.Stop();
    }

    public async Task OnAccept(Task<TcpClient> task)
    {
        var tcpClient = await task;

        if (SharedObjects.DebugLevel >= DebugLevel.Connections)
            Global.Logger.InfoFormat("{0} - Got new TCP client from {1}", Service.Name,
                tcpClient.Client.RemoteEndPoint as IPEndPoint);

        // creates a new session and starts it
        var clientSession = new Session.Session(tcpClient, this);
        AddSession(clientSession);
        await clientSession.Start();
    }

    public virtual void RemoveSession(ISession session)
    {
    }

    public virtual void AddSession(ISession session)
    {
    }
}