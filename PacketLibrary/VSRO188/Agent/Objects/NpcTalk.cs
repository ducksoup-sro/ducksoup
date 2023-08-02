using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects;

// https://github.com/SDClowen/RSBot/
public class NpcTalk
{
    public byte Flag;
    public byte[] Options;
    public void Deserialize(Packet packet)
    {
        packet.TryRead<byte>(out Flag);

        if (Flag == 2)
        {
            packet.TryRead<byte>(out var count);
            for (int i = 0; i < count; i++)
            {
                packet.TryRead<byte>(out Options[i]);
            }
        }
    }
}