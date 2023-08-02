using SilkroadSecurityAPI.Message;

namespace PacketLibrary.ISRO_R.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_LOGIN#response
public class SERVER_GATEWAY_LOGIN_RESPONSE : Packet
{
    public SERVER_GATEWAY_LOGIN_RESPONSE() : base(0xA10A, true, false)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;
    
    public async override Task Read()
    {
    
        // 0000000000   01 05 00 00 00 0B 00 31 30 2E 33 2E 31 30 2E 32   .......10.3.10.2
        // 0000000016   30 30 0C 3E 01                                    00.>............

        // 01 - result
        // 05 00 00 00 - uint token
        // 0B 00 - ushort length 
        // 31 30 2E 33 2E 31 30 2E 32 30 30 - string host
        // 0C 3E - ushort port
        // 01 - byte unk
        TryRead<byte>(out Result);
        if(Result == 0x01) {
            TryRead<uint>(out Token);
            TryRead(out Host);
            TryRead<ushort>(out Port);
            TryRead<byte>(out Channel);
        }
    }
    public byte Channel;
    public ushort Port;
    public string Host;
    public uint Token ;
    public byte Result;

    public async override Task<Packet> Build()
    {
        if(Result == 0x01) {
            Reset();
            
            TryWrite<byte>(Result);
            TryWrite<uint>(Token);
            TryWrite(Host);
            TryWrite<ushort>(Port);
            TryWrite<byte>(Channel);      
        }
        return this;
    }
}