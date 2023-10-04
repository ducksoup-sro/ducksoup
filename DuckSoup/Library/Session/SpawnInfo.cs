using API.Session;
using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Server;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Library.Session;

public class SpawnInfo : ISpawnInfo
{
    private Packet _packet;
    private SERVER_ENTITY_GROUPSPAWN_BEGIN serverAgentEntity;

    public void Read(Packet packet)
    {
        serverAgentEntity = new SERVER_ENTITY_GROUPSPAWN_BEGIN(packet);
        serverAgentEntity.Read().Wait();
        _packet = new Packet(0x3019);
    }

    public void Clear()
    {
        serverAgentEntity = null;
        _packet = null;
    }

    public SpawnInfoType? GetSpawnInfoType()
    {
        return serverAgentEntity?.SpawnInfoType;
    }

    public ushort? GetAmount()
    {
        return serverAgentEntity?.Amount;
    }

    public Packet? GetPacket()
    {
        return _packet;
    }
}