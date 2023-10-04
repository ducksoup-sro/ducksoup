using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Cos;

// https://github.com/SDClowen/RSBot/
public class Growth : Cos
{
    public ushort CurrentHungerPoints;


    public override void Deserialize(Packet packet)
    {
        packet.TryRead(out Experience)
            .TryRead(out Level)
            .TryRead(out CurrentHungerPoints)
            .TryRead(out Settings)
            .TryRead(out Name)
            .TryRead<byte>(out var unk1)
            .TryRead(out OwnerUniqueId)
            .TryRead<byte>(out var inventorySlot);
    }
}