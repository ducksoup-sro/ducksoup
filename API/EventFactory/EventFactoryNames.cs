namespace API.EventFactory;

public static class EventFactoryNames
{
    // Session Stuff
    public const string OnSessionStart = "OnSessionStart"; // ISession
    public const string OnSessionEnd = "OnSessionEnd"; // ISession

    public const string OnClientReceivePacket = "OnClientReceivePacket"; // DateTime, FakeServer.Service.ServerType, ISession, Packet
    public const string OnClientTransferPacket = "OnClientTransferPacket"; // DateTime, FakeServer.Service.ServerType, ISession, Packet
    public const string OnModuleReceivePacket = "OnModuleReceivePacket"; // DateTime, FakeServer.Service.ServerType, ISession, Packet
    public const string OnModuleTransferPacket = "OnModuleTransferPacket"; // DateTime, FakeServer.Service.ServerType, ISession, Packet

    // Login and pre game stuff
    public const string OnUserAgentLogin = "OnUserAgentLogin"; // ISession
    public const string OnUserJoinCharScreen = "OnUserJoinCharScreen"; // ISession
    public const string OnUserLeaveCharScreen = "OnUserLeaveCharScreen"; // ISession
    public const string OnUserCharnameSent = "OnUserCharnameSent"; // ISession

    // Game stuff
    public const string OnCharacterFirstSpawn = "OnCharacterFirstSpawn"; // ISession
    public const string OnCharacterGameReadyChange = "OnCharacterGameReadyChange"; // ISession, (Bool) Status
    public const string OnCharacterSpawn = "OnCharacterSpawn"; // ISession, (Bool) Status

    // Server Stuff
    public const string OnAsyncServerStart = "OnAsyncServerStart"; // IAsyncServer
    public const string OnAsyncServerStop = "OnAsyncServerStart"; // IAsyncServer

    // Command Stuff
    public const string OnCommandExecution = "OnCommandExecution"; // inputString, Command || null
}