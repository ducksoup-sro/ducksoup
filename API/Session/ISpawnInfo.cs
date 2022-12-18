using SilkroadSecurityAPI;

namespace API.Session;

public interface ISpawnInfo
{
    void Read(Packet packet);
    void Clear();
    SpawnInfoType? GetSpawnInfoType();
    ushort? GetAmount();
    Packet? GetPacket();
}