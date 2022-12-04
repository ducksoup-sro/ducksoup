using API.Session;

namespace API.Party;

public interface IPartyManager
{
    List<IParty> getParties();
    IParty? getParty(int id);
    IParty? getParty(string charname);
    IParty? getParty(ISession session);
    void addParty(IParty party);
    void removeParty(int id);
    void removeParty(string charname);
    void removeParty(ISession session);
    bool isInParty(string charname);
    bool isInParty(ISession session);
    List<IPartyMatchEntry> getPartyMatchEntries();
    IPartyMatchEntry? getPartyMatchEntry(int id);
    IPartyMatchEntry? getPartyMatchEntry(IParty party);
    void addPartyMatchEntry(IPartyMatchEntry partyMatchEntry);
    void removePartyMatchEntry(int id);
    void removePartyMatchEntry(IParty party);
    bool hasPartyMatchEntry(IParty party);
    bool hasPartyMatchEntry(int id);
}