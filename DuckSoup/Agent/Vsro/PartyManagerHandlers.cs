using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;
using API.Party;
using API.ServiceFactory;
using API.Session;
using DuckSoup.Library.Session;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Server;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Library.Party;

public class PartyManagerHandlers
{
    private readonly IPartyManager _partyManager;

    public PartyManagerHandlers(IPacketHandler packetHandler)
    {
        _partyManager = ServiceFactory.Load<IPartyManager>(typeof(IPartyManager));

        // CREATE
        packetHandler.RegisterModuleHandler<SERVER_PARTY_CREATE_FROM_MATCHING>(PartyCreateFromMatching);
        packetHandler.RegisterModuleHandler<SERVER_PARTY_MATCHING_FORM_RESPONSE>(PartyMatchingFormResponse);

        // DELETE
        // Session Disconnect only if alone
        packetHandler.RegisterModuleHandler<SERVER_PARTY_MATCHING_DELETE_RESPONSE>(PartyMatchingDeleteResponse);

        // UPDATE
        packetHandler.RegisterModuleHandler<SERVER_PARTY_UPDATE>(PartyUpdate);
        packetHandler.RegisterModuleHandler<SERVER_PARTY_MATCHING_CHANGE_RESPONSE>(PartyMatchingChangeResponse);
    }

    private async Task<Packet> PartyMatchingChangeResponse(SERVER_PARTY_MATCHING_CHANGE_RESPONSE data, ISession session)
    {
        var entry = _partyManager.GetPartyMatchEntry((int)data.MatchingId);

        if (entry == null) return data;

        entry.Title = data.Title;
        entry.PurposeType = data.partyPurpose;
        entry.LevelMax = data.LevelRangeMax;
        entry.LevelMin = data.LevelRangeMin;

        _partyManager.AddPartyMatchEntry(entry);

        return data;
    }

    private async Task<Packet> PartyUpdate(SERVER_PARTY_UPDATE data, ISession session)
    {
        ISession? sess = null;
        switch (data.PartyUpdateType)
        {
            case PartyUpdateType.Dismissed:
                if (data.ErrorCode == PartyErrorCode.Dismissed) _partyManager.RemoveParty(session);

                break;
            case PartyUpdateType.Joined:
                sess = await Helper.GetSessionByCharName(data.MemberInfo.Name);
                if (sess == null) break;

                var needsAdding = true;
                var tParty = _partyManager.GetParty(session);
                foreach (var tPartyMember in tParty.Members)
                {
                    tPartyMember.GetData("jid", out uint? tPartyJid, null);
                    sess.GetData("jid", out uint? sessJid, null);
                    if (tPartyJid == sessJid) needsAdding = false;
                }

                if (needsAdding) tParty.Members.Add(sess);

                break;
            case PartyUpdateType.Leave:
                // everywhere
                sess = await Helper.GetSessionByAccountJid((int)data.UserJID);
                if (sess == null) break;

                _partyManager.GetParty(session)?.Members.Remove(sess);
                break;
            case PartyUpdateType.Member:
                break;
            case PartyUpdateType.Leader:
                sess = await Helper.GetSessionByAccountJid((int)data.UserJID);
                if (sess == null) break;

                var party = _partyManager.GetParty(session);
                if (party == null) break;

                party.Leader = sess;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return data;
    }

    private async Task<Packet> PartyMatchingDeleteResponse(SERVER_PARTY_MATCHING_DELETE_RESPONSE data, ISession session)
    {
        _partyManager.RemovePartyMatchEntry((int)data.MatchingId);
        return data;
    }

    private async Task<Packet> PartyMatchingFormResponse(SERVER_PARTY_MATCHING_FORM_RESPONSE data, ISession session)
    {
        IParty party;
        if (data.Id == 0)
            party = new Party
            {
                PartyId = (int)data.Id,
                Leader = session,
                Members = new List<ISession> { session },
                PartySettingsFlag = data.partySetting
            };
        else
            party = _partyManager.GetParty((int)data.Id);

        IPartyMatchEntry? partyMatchEntry = new PartyMatchEntry
        {
            LevelMax = data.LevelRangeMax,
            LevelMin = data.LevelRangeMin,
            MatchId = (int)data.MatchingId,
            Party = party,
            PurposeType = data.partyPurpose,
            Title = data.Title
        };

        _partyManager.AddPartyMatchEntry(partyMatchEntry);

        return data;
    }

    private async Task<Packet> PartyCreateFromMatching(SERVER_PARTY_CREATE_FROM_MATCHING data, ISession session)
    {
        var party = _partyManager.GetParty(data.ID);
        if (party != null || data.ID == 0) return data;

        var leaderSession = await Helper.GetSessionByAccountJid(data.LeaderJID);
        party = new Party
        {
            Leader = leaderSession,
            PartyId = data.ID,
            PartySettingsFlag = data.PartySettingsFlag
        };

        foreach (var dataMemberInfo in data.MemberInfos)
            party.Members.Add(await Helper.GetSessionByAccountJid(dataMemberInfo.JID));

        _partyManager.AddParty(party);

        var partyMatchEntry = _partyManager.GetPartyMatchEntries()
            .FirstOrDefault(entry =>
            {
                entry.Party.Leader.GetData(Data.CharInfo, out CharInfo? entryInfo, null);
                leaderSession.GetData(Data.CharInfo, out CharInfo? leaderInfo, null);
                return leaderInfo.Jid == entryInfo.Jid;
            });
        if (partyMatchEntry != null) partyMatchEntry.Party = party;

        return data;
    }
}