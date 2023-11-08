using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Objects.Party;

namespace API.Party;

public interface IPartyManager
{
    List<IParty> GetParties();
    IParty? GetParty(int id);
    IParty? GetParty(string charName);
    IParty? GetParty(ISession session);
    void AddParty(IParty party);
    void RemoveParty(int id);
    void RemoveParty(string charName);
    void RemoveParty(ISession session);
    bool IsInParty(string charName);
    bool IsInParty(ISession session);
    bool HasPartyMatchEntry(string charName);
    bool HasPartyMatchEntry(ISession session);
    List<IPartyMatchEntry?> GetPartyMatchEntries();
    IPartyMatchEntry? GetPartyMatchEntry(int id);
    IPartyMatchEntry? GetPartyMatchEntry(IParty party);
    void AddPartyMatchEntry(IPartyMatchEntry partyMatchEntry);
    void RemovePartyMatchEntry(int id);
    void RemovePartyMatchEntry(IParty party);
    bool HasPartyMatchEntry(IParty party);
    bool HasPartyMatchEntry(int id);
}