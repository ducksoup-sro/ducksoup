using PacketLibrary.Enums;
using PacketLibrary.Enums.Agent;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent;

public class SERVER_JOB_UPDATE_EXP : IPacketStructure
{
    public static ushort MsgId => 0x30E6;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public TrijobType TrijobType { get; set; } 
    public byte JobLevel { get; set; }
    public uint JobExp { get; set; } 
    
    public Task Read(Packet packet)
    {
        TrijobType = (TrijobType) packet.ReadUInt8();
        JobLevel = packet.ReadUInt8();
        JobExp = packet.ReadUInt32();
        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteByte((byte) TrijobType);
        response.WriteByte(JobLevel);
        response.WriteUInt32(JobExp);
        
        return response;
    }
    
    public static async Task<Packet> of()
    {
        throw new NotImplementedException();
    }
}