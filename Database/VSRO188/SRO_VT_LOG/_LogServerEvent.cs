namespace Database.VSRO188.SRO_VT_LOG;

public class _LogServerEvent
{
    public int ID { get; set; }

    public DateTime EventTime { get; set; }

    public int ServerEventID { get; set; }

    public byte LogType { get; set; }

    public string? strDesc { get; set; }
}