using Database.VSRO188;
using Database.VSRO188.SRO_VT_SHARD;
using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public sealed class SpawnedPlayer : SpawnedBionic
{
    public ExpIcon AutoInverstExp;
    public byte AvatarInventorySize;
    public Dictionary<_RefObjCommon, byte> Avatars;
    public SpawnedPlayerGuild Guild;
    public byte HwanLevel;
    public bool InCombat;
    public InteractMode InteractMode;
    public Dictionary<_RefObjCommon, byte> Inventory;
    public byte InventorySize;
    public Job Job;
    public byte JobLevel;
    public string Name;
    public bool OnTransport;
    public byte PKFlag;
    public PvpState PvpCape;
    public PvpState PvpState;
    public byte Scale;
    public ScrollState ScrollMode;
    public SpawnedPlayerStall Stall;
    public uint TransportUniqueId;
    public bool WearsJobSuite;

    public SpawnedPlayer(uint objId)
        : base(objId)
    {
    }

    internal void Deserialize(Packet packet)
    {
        packet.TryRead(out Scale);
        packet.TryRead(out HwanLevel);
        packet.TryRead(out PvpCape);
        packet.TryRead(out AutoInverstExp);
        packet.TryRead(out InventorySize);

        packet.TryRead<byte>(out var itemCount);
        Inventory = new Dictionary<_RefObjCommon, byte>();

        for (var i = 0; i < itemCount; i++)
        {
            packet.TryRead<uint>(out var itemId);
            var itemObj = Cache.GetRefObjCommonAsync(c => c.ID == itemId).Result;

            if (itemObj == null)
            {
                packet.TryRead<byte>(out var unk0);
                continue;
            }

            //Check if the player wears a job-suit
            if (itemObj.TypeID2 == 1 && itemObj.TypeID3 == 7 && itemObj.TypeID4 is not 4 or 5)
                WearsJobSuite = true;

            if (itemObj.TypeID2 == 1)
            {
                packet.TryRead<byte>(out var optLevel);
                Inventory.Add(itemObj, optLevel); //Item object and the "+" value as value
            }
        }

        Avatars = new Dictionary<_RefObjCommon, byte>();

        packet.TryRead(out AvatarInventorySize);
        packet.TryRead(out itemCount);

        for (var i = 0; i < itemCount; i++)
        {
            packet.TryRead<uint>(out var itemId);
            var itemObj = Cache.GetRefObjCommonAsync(c => c.ID == itemId).Result;
            if (itemObj == null)
            {
                packet.TryRead<byte>(out var unk2);
                continue;
            }

            packet.TryRead<byte>(out var optLevel);
            Avatars.Add(itemObj, optLevel); //Item object and the "+" value as value
        }


        packet.TryRead<bool>(out var hasMask);
        if (hasMask)
        {
            packet.TryRead<uint>(out var maskId);
            var maskObj = Cache.GetRefObjCommonAsync(c => c.ID == maskId).Result;
            if (maskObj == null) return;

            if (maskObj.TypeID1 == RefObjCommon.TypeID1 || maskObj.TypeID2 == RefObjCommon.TypeID2)
            {
                //duplicated player!
                packet.TryRead<byte>(out var scale);
                packet.TryRead(out itemCount);
                for (var i = 0; i < itemCount; i++) packet.TryRead<uint>(out var itemId);
            }
        }

        ParseBionicDetails(packet);

        packet.TryRead(out Name);
        packet.TryRead(out Job);
        packet.TryRead(out JobLevel);
        packet.TryRead(out PvpState);
        packet.TryRead(out OnTransport);
        packet.TryRead(out InCombat);

        if (OnTransport) packet.TryRead(out TransportUniqueId);

        packet.TryRead(out ScrollMode);
        packet.TryRead(out InteractMode);

        packet.TryRead<byte>(out var unkByte4); //unkByte4

        packet.TryRead(out var guildName);

        //Check if the player is wearing job suite, if not the GUILD object has to be parsed!
        if (!WearsJobSuite)
        {
            Guild = SpawnedPlayerGuild.FromPacket(packet);
            Guild.Name = guildName;
        }
        else
        {
            Guild = new SpawnedPlayerGuild { Name = guildName };
        }

        if (InteractMode == InteractMode.P2N_TALK) Stall = SpawnedPlayerStall.FromPacket(packet);

        packet.TryRead<byte>(out var equipmentCooldown); //Equipment Cooldown
        packet.TryRead(out PKFlag); //PKFlag
    }
}