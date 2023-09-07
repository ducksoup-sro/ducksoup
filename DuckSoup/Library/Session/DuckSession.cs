﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Server;
using DuckSoup.Library.Server;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Enums.Chat;
using PacketLibrary.VSRO188.Agent.Server;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Library.Session;

public class DuckSession : ISession
{
    public Guid Guid { get; }
    private Dictionary<string, object> SessionData { get; }
    private FakeSession Client { get; }
    private FakeClient Server { get; }
    
    public DuckSession(FakeSession fakeSession, FakeClient fakeClient)
    {
        Client = fakeSession;
        Server = fakeClient;
        Guid = Guid.NewGuid();
        SessionData = new Dictionary<string, object>();    }

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

        var notice = SERVER_CHAT_UPDATE.of(ChatType.Notice, reason);
        QueueToClient(notice);

        Disconnect();
        return Task.CompletedTask;
    }
    
    public ISession GetData<T>(string key, out T value)
    {
        SessionData.TryGetValue(key, out var val);
        value = (T)val;
        return this;
    }

    public ISession SetData<T>(string key, T value)
    {
        SessionData.Remove(key);
        SessionData.Add(key, value);
        return this;
    }

    public ISession HasData(string key, out bool value)
    {
        value = SessionData.ContainsKey(key);
        return this;
    }

    public ISession Data<T>(string key, out T value, T defaultValue)
    {
        if (!SessionData.ContainsKey(key))
        {
            value = defaultValue;
            return this;
        }
        
        SessionData.TryGetValue(key, out var val);
        value = (T)val;
        return this;
    }
}