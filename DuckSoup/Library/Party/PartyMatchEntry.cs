using API.Enums;
using API.Party;

namespace DuckSoup.Library.Party;

public class PartyMatchEntry : IPartyMatchEntry
{
    public IParty Party { get; init; }
    public int MatchId { get; init; }
    public PartyEnums.PartyPurposeType PurposeType { get; set; }
    public byte LevelMin { get; set; }
    public byte LevelMax { get; set; }
    public string Title { get; set; }
}