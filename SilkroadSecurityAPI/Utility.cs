using System;
using System.Text;
using SilkroadSecurityAPI.VSRO188;

namespace SilkroadSecurityAPI;

public static class Utility
{
    public static string HexDump(this byte[] buffer)
    {
        return buffer.HexDump(0, buffer.Length);
    }

    public static string HexDump(this byte[] buffer, int offset, int count)
    {
        const int bytesPerLine = 16;
        StringBuilder output = new StringBuilder();
        StringBuilder ascii_output = new StringBuilder();
        int length = count;
        if (length % bytesPerLine != 0)
        {
            length += bytesPerLine - length % bytesPerLine;
        }
        for (int x = 0; x <= length; ++x)
        {
            if (x % bytesPerLine == 0)
            {
                if (x > 0)
                {
                    output.Append($"  {ascii_output.ToString()}{Environment.NewLine}");
                    ascii_output.Clear();
                }
                if (x != length)
                {
                    output.Append($"{x:d10}   ");
                }
            }
            if (x < count)
            {
                output.Append($"{buffer[offset + x]:X2} ");
                char ch = (char)buffer[offset + x];
                if (!char.IsControl(ch))
                {
                    ascii_output.Append($"{ch}");
                }
                else
                {
                    ascii_output.Append(".");
                }
            }
            else
            {
                output.Append("   ");
                ascii_output.Append(".");
            }
        }
        return output.ToString();
    }

    public static ISecurity GetSecurity(SecurityType securityType)
    {
        return securityType switch
        {
            SecurityType.VSRO188 => new Security(),
            SecurityType.ISRO_R => new ISRO_R.Security(),
            _ => new Security()
        };
    }

    public static IDefaultList GetDefaultList(SecurityType securityType)
    {
        return securityType switch
        {
            SecurityType.VSRO188 => new DefaultList(),
            SecurityType.ISRO_R => new ISRO_R.DefaultList(),
            _ => new DefaultList()
        };
    }
}