using API.Session;
using Database.VSRO188;
using Database.VSRO188.SRO_VT_SHARD;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Enums.Chat;
using PacketLibrary.VSRO188.Agent.Server;

namespace API.Extensions;

public static class SessionExtension
{
    public static async Task SendNotice(this ISession session, string message)
    {
        await session.SendToClient(await SERVER_CHAT_UPDATE.of(ChatType.Notice, message));
    }

    public static ITimerManager? GetTimerManager(this ISession session)
    {
        session.GetData(Data.TimerManager, out ITimerManager? timerManager, null);
        return timerManager;
    }

    public static ICountdownManager? GetCountdownManager(this ISession session)
    {
        session.GetData(Data.CountDownManager, out ICountdownManager? countdownManager, null);
        return countdownManager;
    }

    public static async Task<_Char?> GetChar(this ISession session)
    {
        session.GetData(Data.CharId, out int charId, -1);
        if (charId == -1)
        {
            return null;
        }
        
        return await Cache.GetCharAsync(charId);
    }
}