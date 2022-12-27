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

    public List<IParty> GetParties()
    {
        return _parties.Values.ToList();
    }

    public IParty GetParty(int id)
    {
        return _parties.TryGetValue(id, out var value) ? value : null;
    }

    public IParty GetParty(string charname)
    {
        return _parties.Values.FirstOrDefault(party => party.Members.Any(partyMember => string.Equals(partyMember.SessionData.Charname, charname, StringComparison.CurrentCultureIgnoreCase)));
    }

    public IParty GetParty(ISession session)
    {
        return _parties.Values.FirstOrDefault(party => party.Members.Any(partyMember => partyMember.ClientGuid == session.ClientGuid));
    }

    public void AddParty(IParty party)
    {
        _parties.AddOrUpdate(party.PartyId, party, (_, _) => party);
    }

    public void RemoveParty(int id)
    {
        var party = GetParty(id);
        RemovePartyMatchEntry(party);
        _parties.Remove(id, out _);
    }

    public void RemoveParty(string charname)
    {
        var party = GetParty(charname);
        RemovePartyMatchEntry(party);
        _parties.Remove(party.PartyId, out _);
    }

    public void RemoveParty(ISession session)
    {
        var party = GetParty(session);
        RemovePartyMatchEntry(party);
        _parties.Remove(party.PartyId, out _);
    }

    public bool IsInParty(string charname)
    {
        return _parties.Values.Any(party => party.Members.Any(partyMember => string.Equals(partyMember.SessionData.Charname, charname, StringComparison.CurrentCultureIgnoreCase)));
    }

    public bool IsInParty(ISession session)
    {
        return _parties.Values.Any(party => party.Members.Any(partyMember => partyMember.ClientGuid == session.ClientGuid));
    }
    
    public bool HasPartyMatchEntry(string charname)
    {
        return _partyMatchEntries.Values.Any(entry => entry.Party.Members.Any(partyMember => string.Equals(partyMember.SessionData.Charname, charname, StringComparison.CurrentCultureIgnoreCase)));
    }

    public bool HasPartyMatchEntry(ISession session)
    {
        return _partyMatchEntries.Values.Any(entry => entry.Party.Members.Any(partyMember => partyMember.ClientGuid == session.ClientGuid));
    }

    public List<IPartyMatchEntry> GetPartyMatchEntries()
    {
        return _partyMatchEntries.Values.ToList();
    }

    public IPartyMatchEntry GetPartyMatchEntry(int id)
    {
        return _partyMatchEntries.TryGetValue(id, out var value) ? value : null;
    }

    public IPartyMatchEntry GetPartyMatchEntry(IParty party)
    {
        return _partyMatchEntries.Values.FirstOrDefault(partyMatchEntry => partyMatchEntry.Party == party);
    }

    public void AddPartyMatchEntry(IPartyMatchEntry partyMatchEntry)
    {
        _partyMatchEntries.AddOrUpdate(partyMatchEntry.MatchId, partyMatchEntry, (_, _) => partyMatchEntry);
    }

    public void RemovePartyMatchEntry(int id)
    {
        _partyMatchEntries.Remove(id, out _);
    }

    public void RemovePartyMatchEntry(IParty party)
    {
        var removingEntry = _partyMatchEntries.Values.FirstOrDefault(partyMatchEntry => partyMatchEntry.Party.PartyId == party.PartyId);
        if (removingEntry != null)
        {
            _partyMatchEntries.Remove(removingEntry.MatchId, out _);
        }
    }

    public bool HasPartyMatchEntry(IParty party)
    {
        var removingEntry = _partyMatchEntries.Values.FirstOrDefault(partyMatchEntry => partyMatchEntry.Party.PartyId == party.PartyId);
        return removingEntry != null;
    }

    public bool HasPartyMatchEntry(int id)
    {
        return _partyMatchEntries.ContainsKey(id);
    }
}