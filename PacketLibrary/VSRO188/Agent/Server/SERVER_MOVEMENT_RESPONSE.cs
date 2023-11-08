using PacketLibrary.VSRO188.Agent.Objects;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_ENTITY_MOVEMENT
// https://github.com/SDClowen/RSBot/blob/master/Library/RSBot.Core/Network/Handler/Agent/Entity/EntityUpdateMovementResponse.cs
public class SERVER_MOVEMENT_RESPONSE : Packet
{
    public uint TargetId;
    public Movement Movement;
    
    public SERVER_MOVEMENT_RESPONSE() : base(0xB021)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead(out TargetId);
        Movement = Movement.MotionFromPacket(this);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(TargetId);
        Movement.MotionToPacket(this);
        return this;
    }

    public static Packet of()
    {
        return new SERVER_MOVEMENT_RESPONSE();
    }
}