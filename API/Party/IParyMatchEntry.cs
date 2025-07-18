using PacketLibrary.VSRO188.Agent.Enums;

namespace API.Party;

public interface IPartyMatchEntry
{
    IParty? Party { get; set; }
    int MatchId { get; init; }
    PartyPurposeType PurposeType { get; set; }
    byte LevelMin { get; set; }
    byte LevelMax { get; set; }
    string Title { get; set; }
}