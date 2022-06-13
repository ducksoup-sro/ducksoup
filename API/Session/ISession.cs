using API.Server;
using SilkroadSecurityAPI;

namespace API.Session;

public interface ISession : IDisposable
{
    IAsyncServer AsyncServer { get; init; }
    int ClientId { get; set; }
    string ClientIp { get; set; }

    Task SendToClient(Packet packet);
    Task SendToServer(Packet packet);
    Task SendNotice(string message);
    Task Start();

    #region Features

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

    #endregion
}