using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Objects;

public class Punishment
{
    public readonly ushort EndDateDay;
    public readonly ushort EndDateHour;
    public readonly ushort EndDateMicrosecond;
    public readonly ushort EndDateMinute;
    public readonly ushort EndDateMonth;
    public readonly ushort EndDateSecond;
    public readonly ushort EndDateYear;
    public readonly string Reason;

    public Punishment(Packet packet)
    {
        packet.TryRead(out Reason)
            .TryRead(out EndDateYear)
            .TryRead(out EndDateMonth)
            .TryRead(out EndDateDay)
            .TryRead(out EndDateHour)
            .TryRead(out EndDateMinute)
            .TryRead(out EndDateSecond)
            .TryRead(out EndDateMicrosecond);

        // // 2   ushort  punishment.Reason.Length
        // //     *   string  punishment.Reason
        // Reason = packet.ReadAscii();
        // EndDateYear = packet.ReadUInt16(); // 2   ushort  punishment.EndDate.Year
        // EndDateMonth = packet.ReadUInt16(); // 2   ushort  punishment.EndDate.Month
        // EndDateDay = packet.ReadUInt16(); // 2   ushort  punishment.EndDate.Day
        // EndDateHour = packet.ReadUInt16(); // 2   ushort  punishment.EndDate.Hour
        // EndDateMinute = packet.ReadUInt16(); // 2   ushort  punishment.EndDate.Minute
        // EndDateSecond = packet.ReadUInt16(); // 2   ushort  punishment.EndDate.Second
        // EndDateMicrosecond = packet.ReadUInt16(); // 2   ushort  punishment.EndDate.Microsecond
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

    public Packet Build(Packet packet)
    {
        packet.TryWrite(Reason)
            .TryWrite(EndDateYear)
            .TryWrite(EndDateMonth)
            .TryWrite(EndDateDay)
            .TryWrite(EndDateHour)
            .TryWrite(EndDateMinute)
            .TryWrite(EndDateSecond)
            .TryWrite(EndDateMicrosecond);

        // packet.WriteAscii(Reason);
        // packet.WriteUInt16(EndDateYear);
        // packet.WriteUInt16(EndDateMonth);
        // packet.WriteUInt16(EndDateDay);
        // packet.WriteUInt16(EndDateHour);
        // packet.WriteUInt16(EndDateMinute);
        // packet.WriteUInt16(EndDateSecond);
        // packet.WriteUInt16(EndDateMicrosecond); // this might be wrong
        return packet;
    }
}