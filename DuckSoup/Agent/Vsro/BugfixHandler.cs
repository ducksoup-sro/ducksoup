using System;
using System.Threading.Tasks;
using API.Extensions;
using API.Session;
using Database.VSRO188;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Client;
using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Agent.Vsro;

public class BugfixHandler
{
    public BugfixHandler(PacketHandler packetHandler)
    {
        packetHandler.RegisterClientHandler<CLIENT_CHARACTER_ACTION_REQUEST>(1,
            ClientCharacterActionRequest); // Snow Shield fix
    }
    
    private async Task<Packet> ClientCharacterActionRequest(CLIENT_CHARACTER_ACTION_REQUEST data, ISession session)
    {
        data.TryRead(out byte result);
        if (result != 0x01) return data;

        data.TryRead(out CharacterAction action);
        if (action != CharacterAction.SkillCast) return data;

        data.TryRead(out uint skillId);
        var skill = await Cache.GetRefSkillAsync((int)skillId);
        if (skill == null) return data;

        if (!skill.Basic_Code.Contains("COLD_SHIELD")) return data;

        session.GetData(Data.LastSnowShieldUsage, out long lastUsage, 0);
        if (lastUsage + skill.Action_ReuseDelay >
            DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
        {
            await session.SendNotice("You cannot use Snow Shield again. Please wait another " +
                                     (int)((DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - lastUsage -
                                            skill.Action_ReuseDelay) / 1000 * -1) +
                                     " seconds!");
            data.Status = 0x02;
            data.ResultType = PacketResultType.Block;
            return data;
        }

        session.SetData(Data.LastSnowShieldUsage, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
        return data;
    }
}