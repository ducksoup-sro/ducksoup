using SilkroadSecurityAPI;

namespace API.Session;

// https://github.com/SDClowen/RSBot/
public interface IRegion
{
    bool IsDungeon { get; }
    ushort GetId();
    byte GetX();
    byte GetY();
    void SetId(ushort id);
    void SetX(byte x);
    void SetY(byte y);
    IRegion[] GetSurroundingRegions();
    void Serialize(Packet packet);
}