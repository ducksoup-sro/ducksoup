namespace PacketLibrary.Enums.Agent.Operator;

// https://www.elitepvpers.com/forum/sro-coding-corner/4388307-about-gm-command-packet.html
public enum GameCommands : byte
{
    FindUser = 1,
    GoTown = 2,
    ToTown = 3,
    WorldStatus = 4,
    LoadMonster = 6,
    MakeItem = 7,
    MoveToUser = 8,
    WP = 10,
    Zoe = 12,
    Ban = 13,
    Invisible = 14,
    Invincible = 15,
    Recalluser = 17,
    Recallguild = 18,
    Liename = 19,
    Mobkill = 20,
    resetq = 28,
    Movetonpc = 31,
    Makerentitem = 38,
    Spawnunique_loc = 42
}