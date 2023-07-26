﻿using System.IO;

namespace SilkroadSecurityAPI.Message;

public class PacketWriter : BinaryWriter
{
    private readonly MemoryStream _mMs;

    public PacketWriter()
    {
        _mMs = new MemoryStream();
        OutStream = _mMs;
    }

    public byte[] GetBytes()
    {
        return _mMs.ToArray();
    }
}