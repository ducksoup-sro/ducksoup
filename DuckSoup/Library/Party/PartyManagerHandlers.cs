using System;
using System.Linq;
using System.Threading.Tasks;
using API;
using API.Enums;
using API.Party;
using API.Server;
using API.ServiceFactory;
using API.Session;
using PacketLibrary.Agent.Server;
using SilkroadSecurityAPI;

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

    private async Task<PacketResult> SERVER_AGENT_PARTY_MATCHING_CHANGE_RESPONSE(Packet packet, ISession session)
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

    private async Task<PacketResult> SERVER_AGENT_PARTY_UPDATE(Packet packet, ISession session)
    {
        var response = new SERVER_AGENT_PARTY_UPDATE();

        await response.Read(packet);
        ISession sess = null;
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
                    _partyManager.getParty(session)?.Members.Add(session);
                }

                break;
            case PartyEnums.PartyUpdateType.Leave:
                // everywhere
                Global.Logger.InfoFormat("{0} 111", session.SessionData.Charname);
                foreach (var sharedObjectsAgentSession in _sharedObjects.AgentSessions.Where(
                             sharedObjectsAgentSession =>
                                 sharedObjectsAgentSession.SessionData.JID == response.UserJID))
                {
                    sess = sharedObjectsAgentSession;
                }

                Global.Logger.InfoFormat("{0} 222", session.SessionData.Charname);

                if (sess != null)
                {
                    _partyManager.getParty(session)?.Members.Remove(session);
                }

                Global.Logger.InfoFormat("{0} 333", session.SessionData.Charname);

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

        return new PacketResult();
    }

    private async Task<PacketResult> SERVER_AGENT_PARTY_MATCHING_DELETE_RESPONSE(Packet packet, ISession session)
    {
        var response = new SERVER_AGENT_PARTY_MATCHING_DELETE_RESPONSE();
        await response.Read(packet);
        _partyManager.removePartyMatchEntry((int) response.MatchingID);
        return new PacketResult();
    }

    private async Task<PacketResult> SERVER_AGENT_PARTY_MATCHING_FORM_RESPONSE(Packet packet, ISession session)
    {
        var response = new SERVER_AGENT_PARTY_MATCHING_FORM_RESPONSE();
        await response.Read(packet);

        IParty party = new Party
        {
            Leader = session,
            PartyId = (int) response.ID,
            PartySettingsFlag = response.SettingsFlag
        };
        party.Members.Add(session);

        IPartyMatchEntry partyMatchEntry = new PartyMatchEntry
        {
            LevelMax = response.LevelRangeMax,
            LevelMin = response.LevelRangeMin,
            MatchId = (int) response.MatchingID,
            Party = party,
            PurposeType = response.Purpose,
            Title = response.Title
        };

        _partyManager.addParty(party);
        _partyManager.addPartyMatchEntry(partyMatchEntry);

        Global.Logger.Info("Party and Partymatching added");

        return new PacketResult();
    }

    private async Task<PacketResult> SERVER_AGENT_PARTY_CREATE_FROM_MATCHING(Packet packet, ISession session)
    {
        var response = new SERVER_AGENT_PARTY_CREATE_FROM_MATCHING();
        await response.Read(packet);

        IParty party = new Party
        {
            Leader = session,
            PartyId = response.ID,
            PartySettingsFlag = response.PartySettingsFlag
        };
        party.Members.Add(session);

        _partyManager.addParty(party);

        Global.Logger.Info("Party added");

        return new PacketResult();
    }
}