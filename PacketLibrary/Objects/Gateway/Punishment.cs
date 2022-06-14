using SilkroadSecurityAPI;

namespace PacketLibrary.Objects.Gateway;

public class Punishment
{
    public string Reason { get; set; }
    public ushort EndDateYear { get; set; }
    public ushort EndDateMonth { get; set; }
    public ushort EndDateDay { get; set; }
    public ushort EndDateHour { get; set; }
    public ushort EndDateMinute { get; set; }
    public ushort EndDateSecond { get; set; }
    public ushort EndDateMicrosecond { get; set; }

    public Punishment(Packet packet)
    {
        // 2   ushort  punishment.Reason.Length
        //     *   string  punishment.Reason
        Reason = packet.ReadAscii();
        EndDateYear = packet.ReadUInt16(); // 2   ushort  punishment.EndDate.Year
        EndDateMonth = packet.ReadUInt16(); // 2   ushort  punishment.EndDate.Month
        EndDateDay = packet.ReadUInt16(); // 2   ushort  punishment.EndDate.Day
        EndDateHour = packet.ReadUInt16(); // 2   ushort  punishment.EndDate.Hour
        EndDateMinute = packet.ReadUInt16(); // 2   ushort  punishment.EndDate.Minute
        EndDateSecond = packet.ReadUInt16(); // 2   ushort  punishment.EndDate.Second
        EndDateMicrosecond = packet.ReadUInt16(); // 2   ushort  punishment.EndDate.Microsecond
    }

    public Punishment(string reason, ushort year, ushort month, ushort day, ushort hour, ushort minute, ushort second,
        ushort microsecond)
    {
        Reason = reason;
        EndDateYear = year;
        EndDateMonth = month;
        EndDateDay = day;
        EndDateHour = hour;
        EndDateMinute = minute;
        EndDateSecond = second;
        EndDateMicrosecond = microsecond;
    }

    public Packet build(Packet packet)
    {
        packet.WriteAscii(Reason);
        packet.WriteUInt16(EndDateYear);
        packet.WriteUInt16(EndDateMonth);
        packet.WriteUInt16(EndDateDay);
        packet.WriteUInt16(EndDateHour);
        packet.WriteUInt16(EndDateMinute);
        packet.WriteUInt16(EndDateSecond);
        packet.WriteUInt16(EndDateMicrosecond); // this might be wrong

        return packet;
    }
}