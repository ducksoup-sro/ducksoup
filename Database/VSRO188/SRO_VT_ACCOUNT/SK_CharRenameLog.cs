using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class SK_CharRenameLog
{
    public int id { get; set; }

    public int? JID { get; set; }

    public string? struserid { get; set; }

    public string? old_char { get; set; }

    public string? new_char { get; set; }

    public string? server { get; set; }

    public DateTime? timechange { get; set; }
}
