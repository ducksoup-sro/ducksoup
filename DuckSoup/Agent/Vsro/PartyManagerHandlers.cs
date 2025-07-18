using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;
using API.Party;
using API.ServiceFactory;
using API.Session;
using DuckSoup.Library.Party;
using DuckSoup.Library.Session;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Objects.Party;
using PacketLibrary.VSRO188.Agent.Server;
using Serilog;
using SilkroadSecurityAPI.Message;
using PartyMatchEntry = DuckSoup.Library.Party.PartyMatchEntry;

namespace DuckSoup.Agent.Vsro;

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
        try
        {
            IPartyMatchEntry? entry = _partyManager.GetPartyMatchEntry((int)data.MatchingId);

            if (entry == null) return data;

            entry.Title = data.Title;
            entry.PurposeType = data.partyPurpose;
            entry.LevelMax = data.LevelRangeMax;
            entry.LevelMin = data.LevelRangeMin;

            _partyManager.AddPartyMatchEntry(entry);
        }
        catch (Exception e)
        {
            Log.Error("PartyManagerHandler:56 {0}", e.InnerException);
        }

        return data;
    }

    private async Task<Packet> PartyUpdate(SERVER_PARTY_UPDATE data, ISession session)
    {
        try
        {
            ISession? sess = null;
            switch (data.PartyUpdateType)
            {
                case PartyUpdateType.Dismissed:
                    if (data.ErrorCode == PartyErrorCode.Dismissed)
                    {
                        _partyManager.RemoveParty(session);
                    }

                    break;
                case PartyUpdateType.Joined:
                    sess = await Helper.GetSessionByCharName(data.MemberInfo.Name);
                    if (sess == null) break;

                    sess.GetData(Data.CharInfo, out CharInfo? sessData, null);
                    if (sessData == null) break;

                    bool needsAdding = true;
                    IParty? tParty = _partyManager.GetParty(session);
                    if (tParty == null)
                    {
                        Log.Error("Couldn't find a party for the char {0}", sessData.CharName);
                        break;
                    }

                    foreach (ISession tPartyMember in tParty.Members)
                    {
                        tPartyMember.GetData(Data.CharInfo, out CharInfo? tPartyData, null);
                        if (tPartyData == null)
                        {
                            continue;
                        }

                        if (tPartyData.Jid == sessData.Jid) needsAdding = false;
                    }

                    if (needsAdding) tParty.Members.Add(sess);

                    break;
                case PartyUpdateType.Leave:
                    // everywhere
                    sess = await Helper.GetSessionByAccountJid((int)data.UserJID);
                    if (sess == null) break;

                    IParty? pt = _partyManager.GetParty(session);
                    if (pt == null || !pt.Members.Contains(sess))
                    {
                        break;
                    }

                    pt.Members.Remove(sess);
                    break;
                case PartyUpdateType.Member:
                    break;
                case PartyUpdateType.Leader:
                    sess = await Helper.GetSessionByAccountJid((int)data.UserJID);
                    if (sess == null) break;

                    IParty? party = _partyManager.GetParty(session);
                    if (party == null) break;

                    party.Leader = sess;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        catch (Exception e)
        {
            Log.Error("PartyManagerHandler:135 {0}", e.InnerException);
        }

        return data;
    }

    private async Task<Packet> PartyMatchingDeleteResponse(SERVER_PARTY_MATCHING_DELETE_RESPONSE data, ISession session)
    {
        try
        {
            _partyManager.RemovePartyMatchEntry((int)data.MatchingId);
        }
        catch (Exception e)
        {
            Log.Error("PartyManagerHandler:149 {0}", e.InnerException);
        }

        return data;
    }

    private async Task<Packet> PartyMatchingFormResponse(SERVER_PARTY_MATCHING_FORM_RESPONSE data, ISession session)
    {
        try
        {
            IParty? party;
            if (data.Id == 0)
                party = new Party
                {
                    PartyId = (int)data.Id,
                    Leader = session,
                    Members = new List<ISession>
                    {
                        session
                    },
                    PartySettingsFlag = data.partySetting
                };
            else
            {
                party = _partyManager.GetParty((int)data.Id);
            }

            if (party == null)
            {
                return data;
            }

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
        }
        catch (Exception e)
        {
            Log.Error("PartyManagerHandler:192 {0}", e.InnerException);
        }

        return data;
    }

    private async Task<Packet> PartyCreateFromMatching(SERVER_PARTY_CREATE_FROM_MATCHING data, ISession session)
    {
        try
        {
            IParty? party = _partyManager.GetParty(data.ID);
            if (party != null || data.ID == 0) return data;

            ISession? leaderSession = await Helper.GetSessionByAccountJid(data.LeaderJID);
            if (leaderSession == null)
            {
                return data;
            }

            party = new Party
            {
                Leader = leaderSession,
                PartyId = data.ID,
                PartySettingsFlag = data.PartySettingsFlag
            };

            foreach (PartyMemberInfo dataMemberInfo in data.MemberInfos)
            {
                ISession? sess = await Helper.GetSessionByAccountJid(dataMemberInfo.JID);
                if (sess == null)
                {
                    continue;
                }

                party.Members.Add(sess);
            }

            _partyManager.AddParty(party);

            IPartyMatchEntry? partyMatchEntry = _partyManager.GetPartyMatchEntries()
                .FirstOrDefault(entry =>
                {
                    if (entry == null || entry.Party == null)
                    {
                        return false;
                    }

                    entry.Party.Leader.GetData(Data.CharInfo, out CharInfo? entryInfo, null);
                    leaderSession.GetData(Data.CharInfo, out CharInfo? leaderInfo, null);
                    if (entryInfo == null || leaderInfo == null)
                    {
                        return false;
                    }

                    return leaderInfo.Jid == entryInfo.Jid;
                });

            if (partyMatchEntry != null) partyMatchEntry.Party = party;
        }
        catch (Exception e)
        {
            Log.Error("PartyManagerHandler:253 {0}", e.InnerException);
        }

        return data;
    }
}