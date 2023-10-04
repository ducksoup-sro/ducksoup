using API.Enums;

namespace API.Party;

public interface IPartyMatchEntry
{
    IParty? Party { get; set; }
    int MatchId { get; init; }
    PartyEnums.PartyPurposeType PurposeType { get; set; }
    byte LevelMin { get; set; }
    byte LevelMax { get; set; }
    string Title { get; set; }
}