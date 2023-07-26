using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Objects;

public class Notice
{
    public string Article;
    public DateTime DateTime;
    public string Subject;

    public Notice()
    {
    }

    public Notice(string subject, string article, DateTime dateTime)
    {
        Subject = subject;
        Article = article;
        DateTime = dateTime;
    }

    public Notice(Packet packet)
    {
        packet.TryRead(out Subject)
            .TryRead(out Article)
            .TryRead<ushort>(out var year)
            .TryRead<ushort>(out var month)
            .TryRead<ushort>(out var day)
            .TryRead<ushort>(out var hour)
            .TryRead<ushort>(out var minute)
            .TryRead<ushort>(out var second)
            .TryRead<uint>(out var microsecond);
        DateTime = new DateTime(year, month, day, hour, minute, second, Convert.ToUInt16(microsecond));

        // //2   ushort  notice.Subject.Length
        // //    *   string  notice.Subject
        // Subject = packet.ReadAscii();
        // //2   ushort  notice.Article.Length
        // //    *   string  notice.Article
        // Article = packet.ReadAscii();
        // DateTime = new DateTime(packet.ReadUInt16(), packet.ReadUInt16(), packet.ReadUInt16(), packet.ReadUInt16(), packet.ReadUInt16(), packet.ReadUInt16(), Convert.ToUInt16(packet.ReadUInt32()));
        // //2   ushort  notice.EditDate.Year
        // //2   ushort  notice.EditDate.Month
        // //2   ushort  notice.EditDate.Day
        // //2   ushort  notice.EditDate.Hour
        // //2   ushort  notice.EditDate.Minute
        // //2   ushort  notice.EditDate.Second
        // //4   uint    notice.EditDate.Microsecond
    }

    public Packet Build(Packet packet)
    {
        packet.TryWrite(Subject)
            .TryWrite(Article)
            .TryWrite((ushort)DateTime.Year)
            .TryWrite((ushort)DateTime.Month)
            .TryWrite((ushort)DateTime.Day)
            .TryWrite((ushort)DateTime.Hour)
            .TryWrite((ushort)DateTime.Minute)
            .TryWrite((ushort)DateTime.Second)
            .TryWrite((uint)DateTime.Millisecond);
        // packet.WriteAscii(Subject);
        // packet.WriteAscii(Article);
        // packet.WriteUInt16(DateTime.Year);
        // packet.WriteUInt16(DateTime.Month);
        // packet.WriteUInt16(DateTime.Day);
        // packet.WriteUInt16(DateTime.Hour);
        // packet.WriteUInt16(DateTime.Minute);
        // packet.WriteUInt16(DateTime.Second);
        // packet.WriteUInt32(DateTime.Millisecond);
        return packet;
    }
}