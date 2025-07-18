using System.Collections.Concurrent;
using System.Net;
using SilkroadSecurityAPI;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Handler;

public interface ISession
{
    /// <summary>
    ///     Endpoint of the client / user
    /// </summary>
    IPEndPoint? RemoteEndPoint { get; }

    /// <summary>
    ///     Unique ID of the session
    /// </summary>
    Guid Guid { get; }

    /// <summary>
    ///     Sends the packet immediately to the client
    /// </summary>
    /// <param name="packet"></param>
    /// <returns></returns>
    Task SendToClient(Packet packet);

    /// <summary>
    ///     Sends the packet immediately to the Server / Module
    /// </summary>
    /// <param name="packet"></param>
    /// <returns></returns>
    Task SendToServer(Packet packet);

    /// <summary>
    ///     Queues the packet and will be send on the next <see cref="TransferToClient" /> call
    /// </summary>
    /// <param name="packet"></param>
    /// <returns></returns>
    [Obsolete("This seems to bug alot. Don't use")]
    Task QueueToClient(Packet packet);

    /// <summary>
    ///     Queues the packet and will be send on the next <see cref="TransferToServer" /> call
    /// </summary>
    /// <param name="packet"></param>
    /// <returns></returns>
    [Obsolete("This seems to bug alot. Don't use")]
    Task QueueToServer(Packet packet);

    /// <summary>
    ///     Gives you the SecurityAPI object for the server (P -> S)
    /// </summary>
    /// <returns></returns>
    [Obsolete("Do not interact with it, beside you know what you're doing.")]
    ISecurity GetServerSecurity();

    /// <summary>
    ///     Gives you the SecurityAPI object for the client (P -> C)
    /// </summary>
    /// <returns></returns>
    [Obsolete("Do not interact with it, beside you know what you're doing.")]
    ISecurity GetClientSecurity();

    /// <summary>
    ///     Transfers the current packet queue to the Client. Packets can be queued with <see cref="QueueToClient" />
    /// </summary>
    /// <returns></returns>
    Task TransferToClient();

    /// <summary>
    ///     Transfers the current packet queue to the Server / Module. Packets can be queued with <see cref="QueueToServer" />
    /// </summary>
    /// <returns></returns>
    Task TransferToServer();

    /// <summary>
    ///     Disconnects the Session
    /// </summary>
    /// <returns></returns>
    Task Disconnect();

    /// <summary>
    ///     Disconnects the Session with a reason
    /// </summary>
    /// <param name="reason"></param>
    /// <returns></returns>
    Task Disconnect(string reason);

    /// <summary>
    ///     Retrieves session data which can be set by <see cref="SetData{T}" />
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ISession GetData<T>(string key, out T value, T defaultValue);

    /// <summary>
    ///     Sets data for the session which can be retrieved by <see cref="GetData{T}" />
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ISession SetData<T>(string key, T value);

    /// <summary>
    ///     Checks if the session has a key data. Essential for <see cref="GetData{T}" />
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    ISession HasData(string key, out bool value);

    /// <summary>
    ///     Removes the whole object out of the playerdata
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    ISession RemoveData(string key);

    /// <summary>
    ///     Debug only. Don't use
    /// </summary>
    /// <returns></returns>
    ConcurrentDictionary<string, object> GetRawSessionData();
}