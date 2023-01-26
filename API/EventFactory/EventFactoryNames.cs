using System.ComponentModel;

namespace API.EventFactory;

public static class EventFactoryNames
{
    // Session Stuff
    public const string OnSessionStart = "OnSessionStart"; // ISession
    public const string OnSessionEnd = "OnSessionEnd"; // ISession
    
    // Login and pre game stuff
    public const string OnUserAgentLogin = "OnUserAgentLogin"; // ISession
    public const string OnUserJoinCharScreen = "OnUserJoinCharScreen"; // ISession
    public const string OnUserLeaveCharScreen = "OnUserLeaveCharScreen"; // ISession
    public const string OnUserCharnameSent = "OnUserCharnameSent"; // ISession
    
    // Game stuff
    public const string OnCharacterFirstSpawn = "OnCharacterFirstSpawn"; // ISession
    public const string OnCharacterGameReadyChange = "OnCharacterGameReadyChange"; // ISession, (Bool) Status
    
    // Server Stuff
    public const string OnAsyncServerStart = "OnAsyncServerStart"; // IAsyncServer
    public const string OnAsyncServerStop = "OnAsyncServerStart"; // IAsyncServer
    
    // Command Stuff
    public const string OnCommandExecution = "OnCommandExecution"; // inputString, Command || null
}