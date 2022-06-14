using SilkroadSecurityAPI;

namespace PacketLibrary.Objects.Gateway;

public class Notice
{
    public string Subject { get; set; }
    public string Article { get; set; }
    public DateTime DateTime { get; set; }

    public Notice(Packet packet)
    {
        //2   ushort  notice.Subject.Length
        //    *   string  notice.Subject
        Subject = packet.ReadAscii();
        //2   ushort  notice.Article.Length
        //    *   string  notice.Article
        Article = packet.ReadAscii();
        DateTime = new DateTime(packet.ReadUInt16(), packet.ReadUInt16(), packet.ReadUInt16(), packet.ReadUInt16(), packet.ReadUInt16(), packet.ReadUInt16(), Convert.ToUInt16(packet.ReadUInt32()));
        //2   ushort  notice.EditDate.Year
        //2   ushort  notice.EditDate.Month
        //2   ushort  notice.EditDate.Day
        //2   ushort  notice.EditDate.Hour
        //2   ushort  notice.EditDate.Minute
        //2   ushort  notice.EditDate.Second
        //4   uint    notice.EditDate.Microsecond
    }
    
    public Notice(string subject, string article, DateTime dateTime)
    {
        Subject = subject;
        Article = article;
        DateTime = dateTime;
    }

    public Packet build(Packet packet)
    {
        packet.WriteAscii(Subject);
        packet.WriteAscii(Article);
        packet.WriteUInt16(DateTime.Year);
        packet.WriteUInt16(DateTime.Month);
        packet.WriteUInt16(DateTime.Day);
        packet.WriteUInt16(DateTime.Hour);
        packet.WriteUInt16(DateTime.Minute);
        packet.WriteUInt16(DateTime.Second);
        packet.WriteUInt32(DateTime.Millisecond);

        return packet;
    }
}