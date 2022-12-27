using API.Server;
using SilkroadSecurityAPI;

namespace API.Session;

public interface ISession
{
    IAsyncServer AsyncServer { get; init; }
    Guid ClientGuid { get; set; }
    string ClientIp { get; set; }

    Task SendToClient(Packet packet);
    Task SendToServer(Packet packet);
    Task SendNotice(string message);
    Task Start();
    void Stop();
    void Stop(string reason);
    
    #region Features

    ITimerManager TimerManager { get; set; }
    ICountdownManager CountdownManager { get; set; }
    ISpawnInfo SpawnInfo { get; init; }
    string Hwid { get; set; }
    bool CharacterGameReady { get; set; }
    bool FirstSpawn { get; set; }
    ISessionData SessionData { get; init; }

    #endregion

    #region Protection

    // Packet Modification
    int PacketLength { get; set; }
    // False Packets
    bool CharnameSent { get; set; }
    bool CharScreen { get; set; }
    bool UserLoggedIn { get; set; }
    
    DateTime LastPing { get; set; }

    #endregion
}