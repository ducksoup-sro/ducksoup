using System;
using System.Text;

namespace SilkroadSecurityAPI;

public class Utility
{
    public static string HexDump(byte[] buffer)
    {
        return HexDump(buffer, 0, buffer.Length);
    }

    public static string HexDump(byte[] buffer, int offset, int count)
    {
        const int bytesPerLine = 16;
        var output = new StringBuilder();
        var asciiOutput = new StringBuilder();
        var length = count;
        if (length % bytesPerLine != 0) length += bytesPerLine - length % bytesPerLine;
        for (var x = 0; x <= length; ++x)
        {
            if (x % bytesPerLine == 0)
            {
                if (x > 0)
                {
                    output.AppendFormat("  {0}{1}", asciiOutput, Environment.NewLine);
                    asciiOutput.Clear();
                }

                if (x != length) output.AppendFormat("{0:d10}   ", x);
            }

            if (x < count)
            {
                output.AppendFormat("{0:X2} ", buffer[offset + x]);
                var ch = (char)buffer[offset + x];
                if (!char.IsControl(ch))
                    asciiOutput.AppendFormat("{0}", ch);
                else
                    asciiOutput.Append('.');
            }
            else
            {
                output.Append("   ");
                asciiOutput.Append('.');
            }
        }

        return output.ToString();
    }
    
    
    public static ISecurity GetSecurity(SecurityType securityType)
    {
        return securityType switch
        {
            SecurityType.VSRO188 => new VSRO188.Security(),
            SecurityType.ISRO_R => new ISRO_R.Security(),
            _ => new VSRO188.Security()
        };
    }
    
    public static IDefaultList GetDefaultList(SecurityType securityType)
    {
        return securityType switch
        {
            SecurityType.VSRO188 => new VSRO188.DefaultList(),
            SecurityType.ISRO_R => new ISRO_R.DefaultList(),
            _ => new VSRO188.DefaultList()
        };
    }
}