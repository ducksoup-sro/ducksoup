using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Cos;

// https://github.com/SDClowen/RSBot/
public class Growth : Cos
{
    public ushort CurrentHungerPoints;


    public override void Deserialize(Packet packet)
    {
        packet.TryRead<long>(out Experience)
            .TryRead<byte>(out Level)
            .TryRead<ushort>(out CurrentHungerPoints)
            .TryRead<int>(out Settings)
            .TryRead(out Name)
            .TryRead<byte>(out var unk1)
            .TryRead<uint>(out OwnerUniqueId)
            .TryRead<byte>(out var inventorySlot);
        
    }
}