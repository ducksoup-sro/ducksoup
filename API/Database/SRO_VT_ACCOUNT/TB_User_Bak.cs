﻿using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class TB_User_Bak
{
    public int JID { get; set; }

    public string StrUserID { get; set; } = null!;

    public string password { get; set; } = null!;

    public string? question { get; set; }

    public string? answer { get; set; }

    public byte? Status { get; set; }

    public byte? GMrank { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? sex { get; set; }

    public string? certificate_num { get; set; }

    public string? address { get; set; }

    public string? postcode { get; set; }

    public string? phone { get; set; }

    public string? mobile { get; set; }

    public string? cid { get; set; }

    public DateTime? regtime { get; set; }

    public string? reg_ip { get; set; }

    public DateTime? Time_log { get; set; }

    public int? freetime { get; set; }

    public byte sec_primary { get; set; }

    public byte sec_content { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Province { get; set; }

    public string? District { get; set; }

    public string? WherePlay { get; set; }

    public string? WhereKnow { get; set; }

    public string? Reference { get; set; }

    public string? Games { get; set; }

    public string? strLevel { get; set; }

    public string? Class { get; set; }

    public byte? HowPlay { get; set; }

    public int AccPlayTime { get; set; }

    public int LatestUpdateTime_ToPlayTime { get; set; }
}
