using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Objects;

public class Punishment
{
    public readonly ushort EndDateDay;
    public readonly ushort EndDateHour;
    public readonly ushort EndDateMicrosecond;
    public readonly ushort EndDateMinute;
    public readonly ushort EndDateMonth;
    public readonly ushort EndDateNanosecond;
    public readonly ushort EndDateSecond;
    public readonly ushort EndDateYear;
    public readonly string Reason;

    public Punishment(Packet packet)
    {
        packet.TryRead(out Reason)
            .TryRead<ushort>(out EndDateYear)
            .TryRead<ushort>(out EndDateMonth)
            .TryRead<ushort>(out EndDateDay)
            .TryRead<ushort>(out EndDateHour)
            .TryRead<ushort>(out EndDateMinute)
            .TryRead<ushort>(out EndDateSecond)
            .TryRead<ushort>(out EndDateMicrosecond)
            .TryRead<ushort>(out EndDateNanosecond);

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
            .TryWrite<ushort>(EndDateYear)
            .TryWrite<ushort>(EndDateMonth)
            .TryWrite<ushort>(EndDateDay)
            .TryWrite<ushort>(EndDateHour)
            .TryWrite<ushort>(EndDateMinute)
            .TryWrite<ushort>(EndDateSecond)
            .TryWrite<ushort>(EndDateMicrosecond)
            .TryWrite<ushort>(EndDateNanosecond);

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