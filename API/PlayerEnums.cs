namespace API
{
    public enum PVPCape : byte
    {
        None = 0,
        Red = 1,
        Gray = 2,
        Blue = 3,
        White = 4,
        Yellow = 5
    }

    public enum ExpIcon : byte
    {
        Beginner = 0,
        Helpful = 1,
        BeginnerAndHelpful = 2
    }

    public enum Job : byte
    {
        None = 0,
        Trader = 1,
        Thief = 2,
        Hunter = 3
    }

    public enum PvpState : byte
    {
        Neutral = 0,
        Assaulter = 1,
        PlayerKiller = 2
    }

    public enum Scrolling : byte
    {
        None = 0,
        ReturnScroll = 1,
        BanditReturnScroll = 2
    }

    public enum Interaction : byte
    {
        None = 0,
        OnExchangeProbably = 2,
        OnStall = 4,
        OnShop = 6
    }

    public enum CaptureTheFlag : byte
    {
        None = 0xFF,
        Red = 1,
        Blue = 2
    }
}