using System.Text;
using SilkroadSecurityFake.Packets;

namespace SilkroadSecurityFake;

/// Credits: https://github.com/DummkopfOfHachtenduden/ISRORCert
public static class ByteArrayExtensions
{
    public static string HexDump(this Packet packet)
    {
        return HexDump(packet.Data);
    }

    private static string HexDump(this Span<byte> packetData)
    {
        const int bytesPerLine = 16;
        var output = new StringBuilder();
        var asciiOutput = new StringBuilder();
        var length = packetData.Length;
        if (length % bytesPerLine != 0)
        {
            length += bytesPerLine - length % bytesPerLine;
        }
        for (var x = 0; x <= length; ++x)
        {
            if (x % bytesPerLine == 0)
            {
                if (x > 0)
                {
                    output.AppendFormat("  {0}{1}", asciiOutput, Environment.NewLine);
                    asciiOutput.Clear();
                }
                if (x != length)
                {
                    output.AppendFormat("{0:d10}   ", x);
                }
            }
            if (x < packetData.Length)
            {
                output.AppendFormat("{0:X2} ", packetData.ToArray()[x]);
                var ch = (char)packetData.ToArray()[x];
                if (!char.IsControl(ch))
                {
                    asciiOutput.AppendFormat("{0}", ch);
                }
                else
                {
                    asciiOutput.Append('.');
                }
            }
            else
            {
                output.Append("   ");
                asciiOutput.Append('.');
            }
        }
        return output.ToString();
    }

    public static string HexDump(this byte[] buffer)
    {
        return HexDump(buffer, 0, buffer.Length);
    }

    public static string HexDump(this byte[] buffer, int offset, int count)
    {
        const int bytesPerLine = 16;
        var output = new StringBuilder();
        var asciiOutput = new StringBuilder();
        var length = count;
        if (length % bytesPerLine != 0)
        {
            length += bytesPerLine - length % bytesPerLine;
        }
        for (var x = 0; x <= length; ++x)
        {
            if (x % bytesPerLine == 0)
            {
                if (x > 0)
                {
                    output.AppendFormat("  {0}{1}", asciiOutput, Environment.NewLine);
                    asciiOutput.Clear();
                }
                if (x != length)
                {
                    output.AppendFormat("{0:d10}   ", x);
                }
            }
            if (x < count)
            {
                output.AppendFormat("{0:X2} ", buffer[offset + x]);
                var ch = (char)buffer[offset + x];
                if (!char.IsControl(ch))
                {
                    asciiOutput.AppendFormat("{0}", ch);
                }
                else
                {
                    asciiOutput.Append('.');
                }
            }
            else
            {
                output.Append("   ");
                asciiOutput.Append('.');
            }
        }
        return output.ToString();
    }
}