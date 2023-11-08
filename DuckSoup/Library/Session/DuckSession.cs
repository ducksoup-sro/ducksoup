using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using API.Session;
using DuckSoup.Library.Server;
using Newtonsoft.Json;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Enums.Chat;
using PacketLibrary.VSRO188.Agent.Server;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Library.Session;

public class DuckSession : ISession
{
    public DuckSession(FakeSession fakeSession, FakeClient fakeClient)
    {
        Client = fakeSession;
        Server = fakeClient;
        Guid = Guid.NewGuid();
        SessionData = new ConcurrentDictionary<string, object>();

        SetData<ITimerManager>(Data.TimerManager, new TimerManager(this));
        SetData<ICountdownManager>(Data.CountDownManager, new CountdownManager(this));
    }

    private ConcurrentDictionary<string, object> SessionData { get; }

    [JsonIgnore] private FakeSession Client { get; }

    [JsonIgnore] private FakeClient Server { get; }

    [JsonIgnore] public IPEndPoint RemoteEndPoint => (IPEndPoint)Client.Socket.RemoteEndPoint;

    public Guid Guid { get; }

    public Task SendToClient(Packet packet)
    {
        Client.Send(packet, true);
        return Task.CompletedTask;
    }

    public Task SendToServer(Packet packet)
    {
        Server.Send(packet, true);
        return Task.CompletedTask;
    }

    [Obsolete("This seems to bug alot. Don't use")]
    public Task QueueToClient(Packet packet)
    {
        Client.Send(packet);
        return Task.CompletedTask;
    }

    [Obsolete("This seems to bug alot. Don't use")]
    public Task QueueToServer(Packet packet)
    {
        Server.Send(packet);
        return Task.CompletedTask;
    }

    public Task TransferToClient()
    {
        Client.Transfer();
        return Task.CompletedTask;
    }

    public Task TransferToServer()
    {
        Server.Transfer();
        return Task.CompletedTask;
    }

    public Task Disconnect()
    {
        if (Client.IsConnected) Client.Disconnect();
        if (Server.IsConnected) Server.Disconnect();
        return Task.CompletedTask;
    }

    public Task Disconnect(string reason)
    {
        if (!Client.IsConnected)
        {
            Disconnect();
            return Task.CompletedTask;
        }

        var notice = SERVER_CHAT_UPDATE.of(ChatType.Notice, reason).Result;
        SendToClient(notice);

        Disconnect();
        return Task.CompletedTask;
    }

    public ISession GetData<T>(string key, out T value, T defaultValue)
    {
        if (!SessionData.ContainsKey(key))
        {
            value = defaultValue;
            SetData(key, defaultValue);
            return this;
        }

        SessionData.TryGetValue(key, out var val);
        value = (T)val;
        return this;
    }

    public ISession SetData<T>(string key, T value)
    {
        SessionData.Remove(key, out var _);
        SessionData.TryAdd(key, value);
        return this;
    }

    public ISession HasData(string key, out bool value)
    {
        value = SessionData.ContainsKey(key);
        return this;
    }


    [Obsolete("Debug only. Don't use")]
    public ConcurrentDictionary<string, object> GetRawSessionData()
    {
        return SessionData;
    }
}