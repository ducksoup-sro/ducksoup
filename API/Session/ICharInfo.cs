using SilkroadSecurityAPI;

namespace API.Session;

public interface ICharInfo
{
    void Read(Packet packet);
    void Process();
    void Clear();
    Packet? GetPacket();
}