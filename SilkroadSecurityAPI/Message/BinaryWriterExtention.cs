using System.Runtime.InteropServices;
using System.Text.Json;

namespace SilkroadSecurityAPI.Message;

public static class BinaryWriterExtensions
{
    public static void Write<T>(this BinaryWriter writer, T value) where T : unmanaged
    {
        var byteSpan = MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(ref value, 1));
        writer.Write(byteSpan);
    }
    
    public static string ToJsonString<T>(this T obj)
    {
        if (obj == null) return string.Empty;

        var options = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(obj, options);
    }
}