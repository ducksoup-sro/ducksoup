using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Handler;

public interface ISession
{
    Guid Guid { get; set; }
    Task SendToClient(Packet packet);
    Task SendToServer(Packet packet);
    Task QueueToClient(Packet packet);
    Task QueueToServer(Packet packet);
    Task TransferToClient();
    Task TransferToServer();
    Task Disconnect();
    Task Disconnect(string reason);
}