﻿using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RentItemInfo
{
    public long nItemDBID { get; set; }

    public int nRentType { get; set; }

    public short nCanDelete { get; set; }

    public short nCanRecharge { get; set; }

    public DateTime PeriodBeginTime { get; set; }

    public DateTime PeriodEndTime { get; set; }

    public DateTime? MeterRateTime { get; set; }

    public short? nPackingState { get; set; }

    public int? nPackingTime { get; set; }
}
