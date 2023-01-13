using System;
using System.Collections.Generic;

namespace API.Database.DuckSoup;

public partial class Machine
{
    public int MachineId { get; set; }

    public string Address { get; set; } = null!;

    public string? Notice { get; set; }

    public virtual ICollection<Service> ServiceLocalMachine_Machines { get; } = new List<Service>();

    public virtual ICollection<Service> ServiceRemoteMachine_Machines { get; } = new List<Service>();

    public virtual ICollection<Service> ServiceSpoofMachine_Machines { get; } = new List<Service>();
}
