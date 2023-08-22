using System.Runtime.InteropServices;

namespace SilkroadSecurityFake.Security;

[StructLayout(LayoutKind.Explicit, Size = 8, CharSet = CharSet.Ansi)]
public class SecurityFlags
{
    [FieldOffset(5)] public byte _6;
    [FieldOffset(6)] public byte _7;
    [FieldOffset(7)] public byte _8;
    [FieldOffset(1)] public byte Blowfish;
    [FieldOffset(3)] public byte Handshake;
    [FieldOffset(4)] public byte HandshakeResponse;
    [FieldOffset(0)] public byte None;
    [FieldOffset(2)] public byte SecurityBytes;


    public static byte FromSecurityFlags(SecurityFlags flags)
    {
        return (byte)(flags.None | flags.Blowfish << 1 | flags.SecurityBytes << 2 | flags.Handshake << 3 |
                      flags.HandshakeResponse << 4 | flags._6 << 5 | flags._7 << 6 | flags._8 << 7);
    }
    
    public static SecurityFlags ToSecurityFlags(byte value)
    {
        var flags = new SecurityFlags();
        flags.None = (byte) (value & 1);
        value >>= 1;
        flags.Blowfish = (byte) (value & 1);
        value >>= 1;
        flags.SecurityBytes = (byte) (value & 1);
        value >>= 1;
        flags.Handshake = (byte) (value & 1);
        value >>= 1;
        flags.HandshakeResponse = (byte) (value & 1);
        value >>= 1;
        flags._6 = (byte) (value & 1);
        value >>= 1;
        flags._7 = (byte) (value & 1);
        value >>= 1;
        flags._8 = (byte) (value & 1);
        value >>= 1;
        return flags;
    }
}