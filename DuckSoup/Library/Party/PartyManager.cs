using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using API.Party;
using API.ServiceFactory;
using API.Session;

namespace DuckSoup.Library.Party;

public class PartyManager : IPartyManager
{
    private readonly ConcurrentDictionary<int, IParty> _parties = new();

    private readonly ConcurrentDictionary<int, IPartyMatchEntry> _partyMatchEntries = new();

    public PartyManager()
    {
        ServiceFactory.Register<IPartyManager>(typeof(IPartyManager), this);
    }

    public List<IParty> getParties()
    {
        return _parties.Values.ToList();
    }

    public IParty getParty(int id)
    {
        return _parties.TryGetValue(id, out var value) ? value : null;
    }

    public IParty getParty(string charname)
    {
        return _parties.Values.FirstOrDefault(party => party.Members.Any(partyMember => string.Equals(partyMember.SessionData.Charname, charname, StringComparison.CurrentCultureIgnoreCase)));
    }

    public IParty getParty(ISession session)
    {
        return _parties.Values.FirstOrDefault(party => party.Members.Any(partyMember => partyMember.ClientId == session.ClientId));
    }

    public void addParty(IParty party)
    {
        _parties.AddOrUpdate(party.PartyId, party, (_, _) => party);
    }

    public void removeParty(int id)
    {
        var party = getParty(id);
        removePartyMatchEntry(party);
        _parties.Remove(id, out _);
    }

    public void removeParty(string charname)
    {
        var party = getParty(charname);
        removePartyMatchEntry(party);
        _parties.Remove(party.PartyId, out _);
    }

    public void removeParty(ISession session)
    {
        var party = getParty(session);
        removePartyMatchEntry(party);
        _parties.Remove(party.PartyId, out _);
    }

    public bool isInParty(string charname)
    {
        return _parties.Values.Any(party => party.Members.Any(partyMember => string.Equals(partyMember.SessionData.Charname, charname, StringComparison.CurrentCultureIgnoreCase)));
    }

    public bool isInParty(ISession session)
    {
        return _parties.Values.Any(party => party.Members.Any(partyMember => partyMember.ClientId == session.ClientId));
    }

    public List<IPartyMatchEntry> getPartyMatchEntries()
    {
        return _partyMatchEntries.Values.ToList();
    }

    public IPartyMatchEntry getPartyMatchEntry(int id)
    {
        return _partyMatchEntries.TryGetValue(id, out var value) ? value : null;
    }

    public IPartyMatchEntry getPartyMatchEntry(IParty party)
    {
        return _partyMatchEntries.Values.FirstOrDefault(partyMatchEntry => partyMatchEntry.Party == party);
    }

    public void addPartyMatchEntry(IPartyMatchEntry partyMatchEntry)
    {
        _partyMatchEntries.AddOrUpdate(partyMatchEntry.MatchId, partyMatchEntry, (_, _) => partyMatchEntry);
    }

    public void removePartyMatchEntry(int id)
    {
        _partyMatchEntries.Remove(id, out _);
    }

    public void removePartyMatchEntry(IParty party)
    {
        var removingEntry = _partyMatchEntries.Values.FirstOrDefault(partyMatchEntry => partyMatchEntry.Party.PartyId == party.PartyId);
        if (removingEntry != null)
        {
            _partyMatchEntries.Remove(removingEntry.MatchId, out _);
        }
    }

    public bool hasPartyMatchEntry(IParty party)
    {
        var removingEntry = _partyMatchEntries.Values.FirstOrDefault(partyMatchEntry => partyMatchEntry.Party.PartyId == party.PartyId);
        return removingEntry != null;
    }

    public bool hasPartyMatchEntry(int id)
    {
        return _partyMatchEntries.ContainsKey(id);
    }
}