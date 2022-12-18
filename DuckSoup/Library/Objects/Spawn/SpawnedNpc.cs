using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedNpc : SpawnedBionic
{
    public NpcTalk Talk { get; } = new NpcTalk();
    public SpawnedNpc(uint objId) 
        : base(objId) { }
    internal virtual void Deserialize(Packet packet)
    {
        Talk.Deserialize(packet);
    }
}