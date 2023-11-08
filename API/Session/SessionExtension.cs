using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Enums.Chat;
using PacketLibrary.VSRO188.Agent.Server;

namespace API.Session;

public static class SessionExtension
{
    public static async Task SendNotice(this ISession session, string message)
    {
        await session.SendToClient(await SERVER_CHAT_UPDATE.of(ChatType.Notice, message));
    }
}