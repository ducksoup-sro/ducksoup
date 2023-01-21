using API;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public sealed class SpawnedFortressStructure : SpawnedNpc
{
    public uint HP { get; set; }
    public uint RefEventStructID { get; set; }
    public ushort CurrentState { get; set; }
    public uint GuildId { get; set; }
    public string GuildName { get; set; }
    public SpawnedFortressStructure(uint objId) :
        base(objId) { }
    internal override void Deserialize(Packet packet)
    {
        HP = packet.ReadUInt32();
        RefEventStructID = packet.ReadUInt32();
        CurrentState = packet.ReadUInt16();

        ParseBionicDetails(packet);

        base.Deserialize(packet);

        GuildId = packet.ReadUInt32();
        if (GuildId != 0)
        {
            GuildName = packet.ReadAscii();
        }
    }
}