using API.Party;
using PacketLibrary.VSRO188.Agent.Enums;

namespace DuckSoup.Library.Party;

public class PartyMatchEntry : IPartyMatchEntry
{
    public IParty Party { get; set; }
    public int MatchId { get; init; }
    public PartyPurposeType PurposeType { get; set; }
    public byte LevelMin { get; set; }
    public byte LevelMax { get; set; }
    public string Title { get; set; }
}