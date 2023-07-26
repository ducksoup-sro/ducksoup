namespace PacketLibrary.Enums.Global;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/blob/master/Packets/GLOBAL/ServerUpdateFlag.cs
[Flags]
public enum ServerUpdateFlag : byte
{
    ServerBody = 1,
    ServerCord = 2
}