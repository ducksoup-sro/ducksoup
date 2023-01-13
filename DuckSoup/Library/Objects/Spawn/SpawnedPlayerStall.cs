using System.Linq;
using API;
using API.Database.SRO_VT_SHARD;
using API.ServiceFactory;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedPlayerStall
{
    public string Name { get; set; }
    public uint DecorationId { get; set; }
    public _RefObjItem Decoration => ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjItem[(int) DecorationId];

    internal static SpawnedPlayerStall FromPacket(Packet packet)
    {
        return new SpawnedPlayerStall
        {
            Name = packet.ReadAscii(),
            DecorationId = packet.ReadUInt32(),
        };
    }
}