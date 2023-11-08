using System.Net;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Handler;

public interface ISession
{
    /// <summary>
    ///     Endpoint of the client / user
    /// </summary>
    IPEndPoint RemoteEndPoint { get; }

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
    /// Debug only. Don't use
    /// </summary>
    /// <returns></returns>
    Dictionary<string, object> GetRawSessionData();
}