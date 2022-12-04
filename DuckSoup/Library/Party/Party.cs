using System.Collections.Generic;
using API.Enums;
using API.Party;
using API.Session;

namespace DuckSoup.Library.Party;

public class Party : IParty
{
    public int PartyId { get; init; }
    public ISession Leader { get; set; }
    public PartyEnums.PartySettingsFlag PartySettingsFlag { get; init; }
    public List<ISession> Members { get; init; } = new();
}