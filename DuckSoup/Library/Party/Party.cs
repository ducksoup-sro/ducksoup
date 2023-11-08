using System.Collections.Generic;
using API.Party;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Enums;

namespace DuckSoup.Library.Party;

public class Party : IParty
{
    public int PartyId { get; init; }
    public ISession Leader { get; set; }
    public PartySettingsFlag PartySettingsFlag { get; init; }
    public List<ISession> Members { get; init; } = new();
}