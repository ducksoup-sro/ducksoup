namespace SilkroadSecurityAPI.Message;

public enum PacketResultType
{
    Disconnect, // if used in a multi handler setup it will disconnect the player immediately 
    Block, // if used in a multi handler setup it will block ALL FURTHER PACKETHANDLERS
    Nothing // if used in a multi handler setup it will do nothing and the following handler will use just use the packet again
}