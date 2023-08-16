using API.Database.DuckSoup;
using PacketLibrary.Handler;

namespace API.Server;

public interface IFakeServer : IDisposable
{
    Service Service { get; }
    IPacketHandler PacketHandler { get; }

    Task Start();
}