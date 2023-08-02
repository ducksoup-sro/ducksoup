using API.Enums;
using PacketLibrary.Handler;

namespace API.Party;

public interface IParty
{
    int PartyId { get; init; }
    ISession Leader { get; set; }
    PartyEnums.PartySettingsFlag PartySettingsFlag { get; init; }
    List<ISession> Members { get; init; }
}