namespace SilkroadSecurityAPI;

public interface IDefaultList
{
    HashSet<ushort> ClientGlobalWhitelist();
    HashSet<ushort> ClientDownloadWhitelist();
    HashSet<ushort> ClientGatewayWhitelist();
    HashSet<ushort> ClientAgentWhitelist();
    HashSet<ushort> ClientGlobalBlacklist();
    HashSet<ushort> ClientDownloadBlacklist();
    HashSet<ushort> ClientGatewayBlacklist();
    HashSet<ushort> ClientAgentBlacklist();
}