using System.Net;
using System.Net.Sockets;
using API.Database.DuckSoup;
using API.Session;

namespace API.Server;

public interface IAsyncServer : IDisposable
{
    Service Service { get; init; }
    bool Exit { get; set; }

    bool Started { get; }
    TcpListener _tcpServer { get; set; }

    IPacketHandler PacketHandler { get; set; }
    IPEndPoint RemoteEndPoint { get; set; }

    void AddSession(ISession session);
    void RemoveSession(ISession session);
    Task Start();
    Task OnAccept(Task<TcpClient> task);
}