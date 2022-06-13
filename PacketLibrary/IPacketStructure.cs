#region

using System.Diagnostics.CodeAnalysis;
using PacketLibrary.Enums;
using SilkroadSecurityAPI;

#endregion

namespace PacketLibrary
{
    public interface IPacketStructure
    {
        public static ushort MsgId { get; }
        public static bool Encrypted { get; }
        public static bool Massive { get; }
        public PacketDirection FromDirection { get; }
        public PacketDirection ToDirection { get; }
        public Task Read(Packet packet);
        public Packet Build();
    }
}