using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Enums;

namespace API.Party;

public interface IParty
{
    public int PartyId { get; init; }
    public ISession Leader { get; set; }
    public PartySettingsFlag PartySettingsFlag { get; init; }
    public List<ISession> Members { get; init; }
}