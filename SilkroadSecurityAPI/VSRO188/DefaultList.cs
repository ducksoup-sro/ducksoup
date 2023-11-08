using System.Collections.Generic;

namespace SilkroadSecurityAPI.VSRO188;

public class DefaultList : IDefaultList
{
    private readonly HashSet<ushort> _clientAgentBlacklist = new()
    {
        0x3510 // GS Crash Exploit - 0x3510 - https://www.elitepvpers.com/forum/sro-pserver-guides-releases/4383384-release-fix-gameserver-crash-runtime-error-exploit.html
    };

    private readonly HashSet<ushort> _clientAgentWhitelist = new();

    private readonly HashSet<ushort> _clientDownloadBlacklist = new();

    private readonly HashSet<ushort> _clientDownloadWhitelist = new()
    {
        0x6004 // CLIENT_DOWNLOAD_FILE_REQUEST 
    };

    private readonly HashSet<ushort> _clientGatewayBlacklist = new();

    private readonly HashSet<ushort> _clientGatewayWhitelist = new()
    {
        0x6100, // CLIENT_GATEWAY_PATCH_REQUEST 
        0x6101, // CLIENT_GATEWAY_SHARD_LIST_REQUEST 
        0x6102, // CLIENT_GATEWAY_LOGIN_REQUEST 
        0x6104, // CLIENT_GATEWAY_NOTICE_REQUEST
        0x6106, // CLIENT_GATEWAY_SHARD_LIST_PING_REQUEST
        0x6323 // CLIENT_GATEWAY_LOGIN_IBUV_CONFIRM_REQUEST
    };

    private readonly HashSet<ushort> _clientGlobalBlacklist = new();

    private readonly HashSet<ushort> _clientGlobalWhitelist = new()
    {
        0x2001, // CLIENT_GLOBAL_MODULE_IDENTIFICATION 
        0x2002, // CLIENT_GLOBAL_MODULE_KEEP_ALIVE (Empty)
        0x5000, // CLIENT_GLOBAL_HANDSHAKE_RESPONSE
        0x6003, // CLIENT_GLOBAL_MODULE_CERTIFICATION_REQUEST
        0x6008, // CLIENT_GLOBAL_MODULE_RELAY_REQUEST
        0x9000, // CLIENT_GLOBAL_HANDSHAKE_ACCEPT
        0xA003, // CLIENT_GLOBAL_MODULE_CERTIFICATION_RESPONSE
        0xA008, // CLIENT_GLOBAL_MODULE_RELAY_RESPONSE
        0xA00D // CLIENT_GLOBAL_MASSIVE_MESSAGE
    };

    public HashSet<ushort> ClientGlobalWhitelist()
    {
        return _clientGlobalWhitelist;
    }

    public HashSet<ushort> ClientDownloadWhitelist()
    {
        return _clientDownloadWhitelist;
    }

    public HashSet<ushort> ClientGatewayWhitelist()
    {
        return _clientGatewayWhitelist;
    }

    public HashSet<ushort> ClientAgentWhitelist()
    {
        return _clientAgentWhitelist;
    }

    public HashSet<ushort> ClientGlobalBlacklist()
    {
        return _clientGlobalBlacklist;
    }

    public HashSet<ushort> ClientDownloadBlacklist()
    {
        return _clientDownloadBlacklist;
    }

    public HashSet<ushort> ClientGatewayBlacklist()
    {
        return _clientGatewayBlacklist;
    }

    public HashSet<ushort> ClientAgentBlacklist()
    {
        return _clientAgentBlacklist;
    }
}