using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefQuest
{
    public byte Service { get; set; }

    public int ID { get; set; }

    public string CodeName { get; set; } = null!;

    public byte Level { get; set; }

    public string DescName { get; set; } = null!;

    public string NameString { get; set; } = null!;

    public string PayString { get; set; } = null!;

    public string ContentsString { get; set; } = null!;

    public string PayContents { get; set; } = null!;

    public string NoticeNPC { get; set; } = null!;

    public string NoticeCondition { get; set; } = null!;
}
