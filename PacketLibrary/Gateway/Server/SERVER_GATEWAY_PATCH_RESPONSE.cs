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
                    // TODO
                    // 1	bool hasEntries
                    // if(!hasEntries)
                    //     break;
			// 
                    // 4	uint	file.ID
                    // 2	ushort	file.Name.Length			
                    //     *	string	file.Name
                    // 2	ushort	file.Path.Length
                    //     *	string	file.Path
                    // 4	uint	file.Length //in bytes
                    // 1	bool	file.ToBePacked //into pk2
                }		
            }
        }

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        throw new NotImplementedException();
    }

    public static Packet of()
    {
        throw new NotImplementedException();
    }
}

