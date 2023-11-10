using PacketLibrary.VSRO188.Agent.Enums.Character;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHARACTER_EXP_UPDATE
public class SERVER_CHARACTER_EXP_UPDATE : Packet
{
    public uint SourceUniqueId; // where particles come from
    public ulong GainedExpPoint;
    public ulong GainedSExpPoint;
    public TCBuffUpdateMask TCBuffUpdateFlag;
    public uint CumulatedSize;
    public uint SourceCharID;
    public uint AccumulatedSize;
    public ushort STP; // This will be calculated based on the experience and level data.
    
    public SERVER_CHARACTER_EXP_UPDATE() : base(0x3056)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        /*TryRead(out SourceUniqueId);
        TryRead(out GainedExpPoint);
        TryRead(out GainedSExpPoint);
        TryRead(out TCBuffUpdateFlag);

        if((TCBuffUpdateFlag & TCBuffUpdateMask.Cumulated) == (TCBuffUpdateMask)1)
        {
            TryRead(out CumulatedSize);
        }

        if((TCBuffUpdateFlag & TCBuffUpdateMask.Accumulated) == (TCBuffUpdateMask)(1 << 4))
        {
            TryRead(out SourceCharID);
            TryRead(out AccumulatedSize);
        }

        if (Character.CurrentExp + gainedExpPoint > requiredExpForCurrentLevel)
        {
            
        }*/
    }

    public override async Task<Packet> Build()
    {
        // Reset();
        /*TryWrite(DwGID);
        TryWrite(GainedExpPoint);
        TryWrite(GainedSExpPoint);
        TryWrite(TCBuffUpdateFlag);

        if (CumulatedSize.HasValue)
        {
            TryWrite(CumulatedSize.Value);
        }

        if (AccumulatedSize.HasValue)
        {
            TryWrite(SourceCharID.Value);
            TryWrite(AccumulatedSize.Value);
        }

        // The STP field should only be written if it's calculated and relevant.
        if (STP.HasValue)
        {
            TryWrite(STP.Value);
        }*/

        return this;
    }

    public static Task<Packet> of()
    {
        return new SERVER_CHARACTER_EXP_UPDATE
                { }
            .Build();
    }
}