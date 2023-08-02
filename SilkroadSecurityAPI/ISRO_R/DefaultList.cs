using System.Collections.Generic;

namespace SilkroadSecurityAPI.ISRO_R;

public class DefaultList : IDefaultList
{
    private readonly HashSet<ushort> _clientGlobalWhitelist = new HashSet<ushort>()
    {
        0x2001, // CLIENT_GLOBAL_MODULE_IDENTIFICATION 
        0x2002, // CLIENT_GLOBAL_MODULE_KEEP_ALIVE (Empty)
        0x5000, // CLIENT_GLOBAL_HANDSHAKE_RESPONSE
        0x6003, // CLIENT_GLOBAL_MODULE_CERTIFICATION_REQUEST
        0x6008, // CLIENT_GLOBAL_MODULE_RELAY_REQUEST
        0x9000, // CLIENT_GLOBAL_HANDSHAKE_ACCEPT
        0xA003, // CLIENT_GLOBAL_MODULE_CERTIFICATION_RESPONSE
        0xA008, // CLIENT_GLOBAL_MODULE_RELAY_RESPONSE
        0xA00D, // CLIENT_GLOBAL_MASSIVE_MESSAGE
    };

    private readonly HashSet<ushort> _clientDownloadWhitelist = new HashSet<ushort>()
    {
        0x6004 // CLIENT_DOWNLOAD_FILE_REQUEST 
    };

    private readonly HashSet<ushort> _clientGatewayWhitelist = new HashSet<ushort>()
    {
        0x6100, // CLIENT_GATEWAY_PATCH_REQUEST 
        0x6101, // CLIENT_GATEWAY_SHARD_LIST_REQUEST 
        // TODO :: Perhaps this one is outdated?
        0x6102, // CLIENT_GATEWAY_LOGIN_REQUEST 
        0x6104, // CLIENT_GATEWAY_NOTICE_REQUEST
        0x6106, // CLIENT_GATEWAY_SHARD_LIST_PING_REQUEST
        0x6107, // SERVER_GATEWAY_PING_LIST_REQUEST
        0x610A, // CLIENT_GATEWAY_LOGIN_REQUEST_GLOBAL
        0x6117, // CLIENT_GATEWAY_PIN_RESPONSE
        0x6323, // CLIENT_GATEWAY_LOGIN_IBUV_CONFIRM_REQUEST
    };
    
    private readonly HashSet<ushort> _clientAgentWhitelist = new HashSet<ushort>()
    {

    };
    
    private readonly HashSet<ushort> _clientGlobalBlacklist = new HashSet<ushort>()
    {

    };
    
    private readonly HashSet<ushort> _clientDownloadBlacklist = new HashSet<ushort>()
    {

    };
    
    private readonly HashSet<ushort> _clientGatewayBlacklist = new HashSet<ushort>()
    {

    };
    
    private readonly HashSet<ushort> _clientAgentBlacklist = new HashSet<ushort>()
    {

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