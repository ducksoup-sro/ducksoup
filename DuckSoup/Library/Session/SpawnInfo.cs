using API;
using API.Session;
using PacketLibrary.Agent.Server;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Session;

public class SpawnInfo : ISpawnInfo
{
    private SERVER_AGENT_ENTITY_GROUPSPAWN_BEGIN serverAgentEntity;
    private Packet _packet;
    
    public void Read(Packet packet)
    {
        serverAgentEntity = new SERVER_AGENT_ENTITY_GROUPSPAWN_BEGIN();
        serverAgentEntity.Read(packet);
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