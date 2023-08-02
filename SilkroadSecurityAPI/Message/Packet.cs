using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SilkroadSecurityAPI.Message;

public class Packet
{
    #region Constructors

    public Packet(ushort msgId, bool encrypted = false, bool massive = false, byte[]? bytes = null, int offset = 0,
        int length = 0)
    {
        ValidatePacketParameters(encrypted, massive);

        Opcode = msgId;
        Encrypted = encrypted;
        Massive = massive;
        _writer = new PacketWriter();
        _reader = null;
        _readerBytes = null;

        if (bytes != null) _writer.Write(bytes, offset, length);
    }
    
    public Packet(Packet packet)
    {
        ValidatePacketParameters(packet.Encrypted, packet.Massive);

        Opcode = packet.MsgId;
        Encrypted = packet.Encrypted;
        Massive = packet.Massive;
        _writer = new PacketWriter();
        _reader = null;
        _readerBytes = null;

        if (packet.GetBytes() != null) _writer.Write(packet.GetBytes(), 0, packet.GetBytes().Length);
    }
    
    public Packet()
    {
        
    }

    #endregion

    #region Fields

    public bool _isReadOnly;
    private PacketReader _reader;
    private byte[] _readerBytes;
    private PacketWriter? _writer;

    #endregion

    #region Properties

    public ushort Opcode { get; set; }
    public ushort MsgId => Opcode;

    public bool Encrypted { get; set; }

    public bool Massive { get; set; }

    public virtual PacketDirection FromDirection => throw new NotImplementedException();

    public virtual PacketDirection ToDirection => throw new NotImplementedException();

    public PacketResultType ResultType { get; set; } = PacketResultType.Nothing;
    public ushort Status { get; set; } = 0;

    #endregion

    #region Methods

    public byte[] GetBytes()
    {
        return _isReadOnly ? _readerBytes : _writer.GetBytes();
    }

    public void ToReadOnly()
    {
        InitializePacketReader();
        _isReadOnly = true;
    }

    public void Reset()
    {
        _writer = new PacketWriter();
    }

    public long SeekRead(long offset, SeekOrigin origin)
    {
        ValidateIsReadOnly("Cannot SeekRead on an unlocked Packet.");

        return _reader.BaseStream.Seek(offset, origin);
    }

    public int RemainingRead()
    {
        ValidateIsReadOnly("Cannot SeekRead on an unlocked Packet.");

        return (int)(_reader.BaseStream.Length - _reader.BaseStream.Position);
    }

    public virtual Task Read()
    {
        throw new NotImplementedException();
    }

    public virtual Task<Packet> Build()
    {
        throw new NotImplementedException();
    }

    public T CreateCopy<T>() where T : Packet, new()
    {
        var copy = new T
        {
            Opcode = Opcode,
            Massive = Massive,
            Encrypted = Encrypted,
            _writer = _writer,
            _readerBytes = _readerBytes,
            _reader = _reader,
            _isReadOnly = _isReadOnly
        };
        return copy;
    }

    #endregion

    #region Private Methods

    private void ValidatePacketParameters(bool encrypted, bool massive)
    {
        if (encrypted && massive) throw new ArgumentException("Packets cannot both be massive and encrypted!");
    }

    private void ValidateIsReadOnly(string errorMessage)
    {
        if (!_isReadOnly) throw new InvalidOperationException(errorMessage);
    }

    private void InitializePacketReader()
    {
        if(_writer != null) {
            _readerBytes = _writer.GetBytes();
            _writer?.Close();
        }
        _writer = null;
        _reader = new PacketReader(_readerBytes);
    }

    #endregion

    #region Read/Write

    public Packet TryRead<T>(out T value)
        where T : unmanaged
    {
        var size = (ushort)Unsafe.SizeOf<T>();
        MemoryMarshal.TryRead(_reader.ReadBytes(size), out value);
        return this;
    }

    public Packet TryReadString(out string value)
    {
        return TryRead(out value, Encoding.UTF8);
    }

    public Packet TryReadUnicode(out string value)
    {
        TryRead(out ushort length);
        length = (ushort)(length * 2);
        return TryRead(out value, length, Encoding.Unicode);
    }

    /// <summary>
    ///     Defaults to CodePage 65001 // UTF8
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public Packet TryRead(out string value)
    {
        return TryReadString(out value);
    }

    public Packet TryRead(out string value, Encoding encoding)
    {
        TryRead(out ushort length);
        return TryRead(out value, length, encoding);
    }

    public Packet TryRead(out string value, ushort length)
    {
        return TryRead(out value, length, Encoding.UTF8);
    }

    public Packet TryRead(out string value, ushort length, Encoding encoding)
    {
        value = encoding.GetString(_reader.ReadBytes(length));
        return this;
    }

    public Packet TryWrite<T>(T value) where T : unmanaged
    {
        return TryWrite(ref value);
    }

    public Packet TryWrite<T>(ref T value)
        where T : unmanaged
    {
        _writer.Write(value);
        return this;
    }

    public Packet TryWriteString(string value)
    {
        return TryWrite(value, Encoding.UTF8);
    }

    public Packet TryWriteUnicode(string value)
    {
        return TryWrite(value, Encoding.Unicode);
    }

    /// <summary>
    ///     Defaults to CodePage 65001 // UTF8
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public Packet TryWrite(string value)
    {
        return TryWriteString(value);
    }

    public Packet TryWrite(string value, Encoding encoding)
    {
        var bytes = encoding.GetBytes(value);
        _writer.Write((ushort)value.Length);
        _writer.Write(bytes);
        return this;
    }

    #endregion
}