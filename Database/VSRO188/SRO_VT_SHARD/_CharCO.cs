namespace Database.VSRO188.SRO_VT_SHARD;

public partial class _CharCO
{
    public int ID { get; set; }

    public int OwnerCharID { get; set; }

    public int RefCharID { get; set; }

    public int HP { get; set; }

    public int MP { get; set; }

    public int KeeperNPC { get; set; }

    public byte State { get; set; }

    public string? CharName { get; set; }

    public byte Lvl { get; set; }

    public long ExpOffset { get; set; }

    public short HGP { get; set; }

    public int PetOption { get; set; }

    public DateTime? RentEndTime { get; set; }
}
