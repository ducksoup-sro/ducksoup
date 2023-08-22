using System.Text.Json;

namespace SilkroadSecurityFake.ByteBuff;

public sealed class Buff : IDisposable
{
    #region Properties

    public BuffSize Size { get; }
    public Memory<byte> Buffer { get; set; }
    
    public int Position { get; private set; }

    #endregion

    public Buff(BuffSize size)
    {
        Buffer = new byte[(int)size];
        Size = size;
    }

    #region Write/Read

    public void Write(ReadOnlySpan<byte> data, ushort offset = 0)
    {
        if (data.IsEmpty)
        {
            throw new ArgumentNullException(nameof(data));
        }

        if (offset + data.Length > Buffer.Length)
        {
            throw new ArgumentException("[Buff::Write] Data length and offset exceed buffer size");
        }

        data.CopyTo(Buffer.Span[offset..]);
    }

    public void Write(ref byte[] data, ushort offset = 0)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        if (offset + data.Length > Buffer.Length)
        {
            throw new ArgumentException("[Buff::Write] Data length and offset exceed buffer size");
        }

        new ReadOnlySpan<byte>(data).CopyTo(Buffer.Span[offset..]);
    }
    
    public void Write(byte[] data, ushort offset = 0)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        if (offset + data.Length > Buffer.Length)
        {
            throw new ArgumentException("[Buff::Write] Data length and offset exceed buffer size");
        }

        new ReadOnlySpan<byte>(data).CopyTo(Buffer.Span[offset..]);
    }

    public void Write(ReadOnlyMemory<byte> data, ushort offset = 0)
    {
        if (data.IsEmpty)
        {
            throw new ArgumentNullException(nameof(data));
        }

        if (offset + data.Length > Buffer.Length)
        {
            throw new ArgumentException("[Buff::Write] Data length and offset exceed buffer size");
        }

        data.Span.CopyTo(Buffer.Span[offset..]);
    }
    
    public Span<byte> Read(ushort length, ushort offset = 0, bool keep = false)
    {
        if (offset + length > Buffer.Length)
        {
            throw new ArgumentException("[Buff::Read] Take length and offset exceed buffer length");
        }

        var takenData = Buffer.Span.Slice(Position + offset, length);

        if (!keep)
        {
            Position += length;
        }

        return takenData;
    }

    #endregion

    #region BuffPool

    public void Reset()
    {
        Buffer.Span.Clear();
        Position = 0;
    }

    public void Return()
    {
        BuffPool.Return(this);
    }

    public static Buff Rent(BuffSize buffSize)
    {
        return BuffPool.Rent(buffSize);
    }

    #endregion

    #region ToString

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

    #endregion

    #region IDisposeable

    public bool Disposed { get; private set; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (Disposed) return;

        if (disposing)
        {
            Buffer.Span.Clear();
        }

        Disposed = true;
    }

    // Use C# destructor syntax for finalization code.
    ~Buff()
    {
        Dispose(false);
    }

    #endregion
}