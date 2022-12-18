using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects;

// https://github.com/SDClowen/RSBot/
public class NpcTalk
{
    public byte Flag { get; set; }
    public byte[] Options { get; set; }
    public void Deserialize(Packet packet)
    {
        Flag = packet.ReadUInt8();

        if (Flag == 2)
        {
            int count = packet.ReadUInt8();
                
            Options = packet.ReadUInt8Array(count);
        }
    }
}