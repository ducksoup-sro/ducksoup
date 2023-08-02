using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace API.Session;

public interface ISpawnInfo
{
    void Read(Packet packet);
    void Clear();
    SpawnInfoType? GetSpawnInfoType();
    ushort? GetAmount();
    Packet? GetPacket();
}