using System;
using System.Collections.Generic;

namespace API.Database.DuckSoup;

public partial class Service
{
    public int ServiceId { get; set; }

    public string Name { get; set; } = null!;

    public ServerType ServerType { get; set; }

    public int RemotePort { get; set; }

    public int BindPort { get; set; }

    public int ByteLimitation { get; set; }

    public bool AutoStart { get; set; }

    public int LocalMachine_MachineId { get; set; }

    public int RemoteMachine_MachineId { get; set; }

    public int? SpoofMachine_MachineId { get; set; }

    public virtual Machine LocalMachine_Machine { get; set; } = null!;

    public virtual Machine RemoteMachine_Machine { get; set; } = null!;

    public virtual Machine? SpoofMachine_Machine { get; set; }
}
