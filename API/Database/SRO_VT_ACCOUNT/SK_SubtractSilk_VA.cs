using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class SK_SubtractSilk_VA
{
    public int BuyNo { get; set; }

    public int UserJID { get; set; }

    public byte Silk_Type { get; set; }

    public byte Silk_Reason { get; set; }

    public int Silk_Offset { get; set; }

    public int Silk_Remain { get; set; }

    public int ID { get; set; }

    public int BuyQuantity { get; set; }

    public string OrderNumber { get; set; } = null!;

    public byte? PGCompany { get; set; }

    public byte? PayMethod { get; set; }

    public string? PGUniqueNo { get; set; }

    public string? AuthNumber { get; set; }

    public DateTime? AuthDate { get; set; }

    public int? SubJID { get; set; }

    public string? srID { get; set; }

    public string SlipPaper { get; set; } = null!;

    public int? MngID { get; set; }

    public string? IP { get; set; }

    public DateTime RegDate { get; set; }
}
