using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;
using API.Enums;
using API.Party;
using API.Server;
using API.ServiceFactory;
using API.Session;
using Newtonsoft.Json;
using PacketLibrary.Agent.Server;
using SilkroadSecurityAPI;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DuckSoup.Library.Party;

public class PartyManagerHandlers
{
    private readonly IPartyManager _partyManager;
    private readonly ISharedObjects _sharedObjects;

    public PartyManagerHandlers(IPacketHandler packetHandler)
    {
        _partyManager = ServiceFactory.Load<IPartyManager>(typeof(IPartyManager));
        _sharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));

        // CREATE
        packetHandler.RegisterModuleHandler(0x3065, SERVER_AGENT_PARTY_CREATE_FROM_MATCHING);
        packetHandler.RegisterModuleHandler(0xB069, SERVER_AGENT_PARTY_MATCHING_FORM_RESPONSE);

        // DELETE
        // Session Disconnect only if alone
        packetHandler.RegisterModuleHandler(0xB06B, SERVER_AGENT_PARTY_MATCHING_DELETE_RESPONSE);

        // UPDATE
        packetHandler.RegisterModuleHandler(0x3864, SERVER_AGENT_PARTY_UPDATE);
        packetHandler.RegisterModuleHandler(0xB06A, SERVER_AGENT_PARTY_MATCHING_CHANGE_RESPONSE);
    }

    private async Task<PacketResult> SERVER_AGENT_PARTY_MATCHING_CHANGE_RESPONSE(Packet packet, ISession session, object obj)
    {
        var response = new SERVER_AGENT_PARTY_MATCHING_CHANGE_RESPONSE();
        await response.Read(packet);

        var entry = _partyManager.getPartyMatchEntry((int) response.MatchingID);

        if (entry == null)
        {
            return new PacketResult();
        }

        entry.Title = response.Title;
        entry.PurposeType = response.Purpose;
        entry.LevelMax = response.LevelRangeMax;
        entry.LevelMin = response.LevelRangeMin;

        _partyManager.addPartyMatchEntry(entry);

        return new PacketResult();
    }

    private async Task<PacketResult> SERVER_AGENT_PARTY_UPDATE(Packet packet, ISession session, object obj)
    {
        var response = new SERVER_AGENT_PARTY_UPDATE();
        
        await response.Read(packet);
        ISession sess = null;

        try
        {
            switch (response.PartyUpdateType)
            {
                case PartyEnums.PartyUpdateType.Dismissed:
                    if (response.ErrorCode == 11)
                    {
                        _partyManager.removeParty(session);
                    }

                    break;
                case PartyEnums.PartyUpdateType.Joined:
                    foreach (var sharedObjectsAgentSession in _sharedObjects.AgentSessions.Where(
                                 sharedObjectsAgentSession => sharedObjectsAgentSession.SessionData.Charname ==
                                                              response.MemberInfo.Name))
                    {
                        sess = sharedObjectsAgentSession;
                    }

                    if (sess != null)
                    {
                        var needsAddding = true;
                        var tparty = _partyManager.getParty(session);
                        foreach (var tpartyMember in tparty.Members)
                        {
                            if (tpartyMember.SessionData.JID == sess.SessionData.JID)
                            {
                                needsAddding = false;
                            }
                        }

                        if (needsAddding)
                        {
                            tparty.Members.Add(sess);
                        }
                    }

                    break;
                case PartyEnums.PartyUpdateType.Leave:
                    // everywhere
                    foreach (var sharedObjectsAgentSession in _sharedObjects.AgentSessions.Where(
                                 sharedObjectsAgentSession =>
                                     sharedObjectsAgentSession.SessionData.JID == response.UserJID))
                    {
                        sess = sharedObjectsAgentSession;
                    }

                    if (sess != null)
                    {
                        _partyManager.getParty(session)?.Members.Remove(sess);
                    }

                    break;
                case PartyEnums.PartyUpdateType.Member:
                    break;
                case PartyEnums.PartyUpdateType.Leader:
                    foreach (var sharedObjectsAgentSession in _sharedObjects.AgentSessions.Where(
                                 sharedObjectsAgentSession =>
                                     sharedObjectsAgentSession.SessionData.JID == response.UserJID))
                    {
                        sess = sharedObjectsAgentSession;
                    }

                    var party = _partyManager.getParty(session);
                    if (sess != null && party != null)
                    {
                        party.Leader = sess;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        catch (Exception e)
        {
            Global.Logger.Info(e.ToString());
        }
        return new PacketResult();
    }

    private async Task<PacketResult> SERVER_AGENT_PARTY_MATCHING_DELETE_RESPONSE(Packet packet, ISession session, object obj)
    {
        var response = new SERVER_AGENT_PARTY_MATCHING_DELETE_RESPONSE();
        await response.Read(packet);
        _partyManager.removePartyMatchEntry((int) response.MatchingID);
        return new PacketResult();
    }

    private async Task<PacketResult> SERVER_AGENT_PARTY_MATCHING_FORM_RESPONSE(Packet packet, ISession session, object obj)
    {
        var response = new SERVER_AGENT_PARTY_MATCHING_FORM_RESPONSE();
        await response.Read(packet);

        IParty party;
        if (response.ID == 0)
        {
            party = new Party
            {
                PartyId = (int) response.ID,
                Leader = session,
                Members = new List<ISession> {session},
                PartySettingsFlag = response.SettingsFlag
            };
        }
        else
        {
            party = _partyManager.getParty((int) response.ID);
        }

        IPartyMatchEntry partyMatchEntry = new PartyMatchEntry
        {
            LevelMax = response.LevelRangeMax,
            LevelMin = response.LevelRangeMin,
            MatchId = (int) response.MatchingID,
            Party = party,
            PurposeType = response.Purpose,
            Title = response.Title
        };

        _partyManager.addPartyMatchEntry(partyMatchEntry);
        
        return new PacketResult();
    }

    private async Task<PacketResult> SERVER_AGENT_PARTY_CREATE_FROM_MATCHING(Packet packet, ISession session, object obj)
    {
        var response = new SERVER_AGENT_PARTY_CREATE_FROM_MATCHING();
        await response.Read(packet);

        var party = _partyManager.getParty(response.ID);
        if (party != null || response.ID == 0)
        {
            return new PacketResult();
        }

        var leaderSession = _sharedObjects.AgentSessions.First(session => session.SessionData.JID == response.LeaderJID);
        party = new Party
        {
            Leader = leaderSession,
            PartyId = response.ID,
            PartySettingsFlag = response.PartySettingsFlag
        };
        
        foreach (var responseMemberInfo in response.MemberInfos)
        {
            party.Members.Add(_sharedObjects.AgentSessions.First(session => session.SessionData.JID == responseMemberInfo.JID));
        }
        
        _partyManager.addParty(party);

        _partyManager.getPartyMatchEntries()
            .First(entry => entry.Party?.Leader.SessionData.JID == leaderSession.SessionData.JID).Party = party;
        
        return new PacketResult();
    }
}