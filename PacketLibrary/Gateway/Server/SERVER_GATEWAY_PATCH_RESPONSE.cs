using PacketLibrary.Enums;
using PacketLibrary.Enums.Gateway;
using PacketLibrary.Objects.Gateway;
using SilkroadSecurityAPI;

namespace PacketLibrary.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_PATCH#response
public class SERVER_GATEWAY_PATCH_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xA100;
    public static bool Encrypted => false;
    public static bool Massive => true;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result { get; set; }
    public PatchErrorCode ErrorCode { get; set; }
    public HostAndPort DownloadServer { get; set; }
    public uint CurVersion { get; set; }
    public List<DownloadFile> Files = new();

    public Task Read(Packet packet)
    {
        Result = packet.ReadUInt8(); // 1	byte	result
        if(Result == 0x02)
        {
            ErrorCode = (PatchErrorCode) packet.ReadUInt8(); // 1	byte	errorCode
            if(ErrorCode == PatchErrorCode.Update)
            {
                DownloadServer = new HostAndPort(packet);
                CurVersion = packet.ReadUInt32(); // 4	uint	DownloadServer.CurVersion
		
                while(true)
                {
                    var hasEntries = packet.ReadBool(); // 1	bool hasEntries
                    if(!hasEntries)
                        break;
                    Files.Add(new DownloadFile(packet));
                }		
            }
        }

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Result); 
        if(Result == 0x02)
        {
            response.WriteUInt8(ErrorCode); 
            if(ErrorCode == PatchErrorCode.Update)
            {
                DownloadServer.build(response);
                response.WriteUInt32(CurVersion); 
		
                foreach (var downloadFile in Files)
                {
                    response.WriteBool(true);
                    downloadFile.build(response);
                }
                response.WriteBool(false);
            }
        }
        
        return response;
    }

    public static Packet of()
    {
        throw new NotImplementedException();
    }
}

