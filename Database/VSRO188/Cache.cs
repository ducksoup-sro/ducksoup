using System.Linq.Expressions;
using Database.VSRO188.SRO_VT_ACCOUNT;
using Database.VSRO188.SRO_VT_SHARD;
using Microsoft.EntityFrameworkCore;

namespace Database.VSRO188;

public static class Cache
{
    public static readonly Dictionary<int, _RefObjCommon> RefObjCommons = new Dictionary<int, _RefObjCommon>();
    public static readonly Dictionary<int, _RefObjItem> RefObjItems = new Dictionary<int, _RefObjItem>();
    public static readonly Dictionary<int, _RefObjChar> RefObjChars = new Dictionary<int, _RefObjChar>();
    public static readonly Dictionary<int, _RefSkill> RefSkills = new Dictionary<int, _RefSkill>();
    public static readonly Dictionary<int, _RefRegion> RefRegions = new Dictionary<int, _RefRegion>();
    public static readonly Dictionary<int, _RefQuest> RefQuests = new Dictionary<int, _RefQuest>();
    public static readonly Dictionary<int, _RefQuestReward> RefQuestRewards = new Dictionary<int, _RefQuestReward>();
    public static readonly Dictionary<int, _RefQuestRewardItem> RefQuestRewardItems = new Dictionary<int, _RefQuestRewardItem>();
    public static readonly Dictionary<byte, _RefLevel> RefLevels = new Dictionary<byte, _RefLevel>();

    public static readonly Dictionary<int, _Notice> Notices = new Dictionary<int, _Notice>();

    public static void FillCache()
    {
        using Context.SRO_VT_SHARD shard = new Context.SRO_VT_SHARD();
        shard._RefObjCommons.AsNoTracking().ForEachAsync((entry) => { RefObjCommons.TryAdd(entry.ID, entry); });
        shard._RefObjItems.AsNoTracking().ForEachAsync((entry) => { RefObjItems.TryAdd(entry.ID, entry); });
        shard._RefObjChars.AsNoTracking().ForEachAsync((entry) => { RefObjChars.TryAdd(entry.ID, entry); });
        shard._RefSkills.AsNoTracking().ForEachAsync((entry) => { RefSkills.TryAdd(entry.ID, entry); });
        shard._RefRegions.AsNoTracking().ForEachAsync((entry) => { RefRegions.TryAdd(entry.wRegionID, entry); });
        shard._RefQuests.AsNoTracking().ForEachAsync((entry) => { RefQuests.TryAdd(entry.ID, entry); });
        shard._RefQuestRewards.AsNoTracking().ForEachAsync((entry) => { RefQuestRewards.TryAdd(entry.QuestID, entry); });
        shard._RefQuestRewardItems.AsNoTracking().ForEachAsync((entry) => { RefQuestRewardItems.TryAdd(entry.QuestID, entry); });
        shard._RefLevels.AsNoTracking().ForEachAsync((entry) => { RefLevels.TryAdd(entry.Lvl, entry); });

        using Context.SRO_VT_ACCOUNT account = new Context.SRO_VT_ACCOUNT();
        account._Notices.ForEachAsync((entry) => { Notices.TryAdd(entry.ID, entry); });
    }

    public static void ClearCache()
    {
        RefObjCommons.Clear();
        RefObjItems.Clear();
        RefObjChars.Clear();
        RefSkills.Clear();
        RefRegions.Clear();
        RefQuests.Clear();
        RefQuestRewards.Clear();
        RefQuestRewardItems.Clear();
        RefLevels.Clear();
        Notices.Clear();
    }

    public static async Task<_RefObjCommon?> GetRefObjCommonAsync(int id)
    {
        if (RefObjCommons.ContainsKey(id))
        {
            return RefObjCommons[id];
        }

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        _RefObjCommon? value = await db._RefObjCommons.AsNoTracking().FirstOrDefaultAsync(entry => entry.ID == id);

        if (value != null)
        {
            RefObjCommons.TryAdd(id, value);
        }

        return value;
    }

    public static async Task<_RefObjCommon?> GetRefObjCommonAsync(Expression<Func<_RefObjCommon, bool>> predicate)
    {
        _RefObjCommon? value = RefObjCommons.Values.AsQueryable().AsNoTracking().FirstOrDefault(predicate.Compile());

        if (value != null) return value;

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        value = await db._RefObjCommons.AsNoTracking().FirstOrDefaultAsync(predicate);

        if (value != null)
        {
            RefObjCommons.TryAdd(value.ID, value);
        }

        return value;
    }

    public static async Task<_RefObjItem?> GetRefObjItemAsync(int id)
    {
        if (RefObjItems.ContainsKey(id))
        {
            return RefObjItems[id];
        }

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        _RefObjItem? value = await db._RefObjItems.AsNoTracking().FirstOrDefaultAsync(entry => entry.ID == id);

        if (value != null)
        {
            RefObjItems.TryAdd(id, value);
        }

        return value;
    }

    public static async Task<_RefObjItem?> GetRefObjItemAsync(Expression<Func<_RefObjItem, bool>> predicate)
    {
        _RefObjItem? value = RefObjItems.Values.AsQueryable().AsNoTracking().FirstOrDefault(predicate.Compile());

        if (value != null) return value;

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        value = await db._RefObjItems.AsNoTracking().FirstOrDefaultAsync(predicate);
        if (value != null)
        {
            RefObjItems.TryAdd(value.ID, value);
        }

        return value;
    }

    public static async Task<_RefObjChar?> GetRefObjCharAsync(int id)
    {
        if (RefObjChars.ContainsKey(id))
        {
            return RefObjChars[id];
        }

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        _RefObjChar? value = await db._RefObjChars.AsNoTracking().FirstOrDefaultAsync(entry => entry.ID == id);

        if (value != null)
        {
            RefObjChars.TryAdd(id, value);
        }

        return value;
    }

    public static async Task<_RefObjChar?> GetRefObjCharAsync(Expression<Func<_RefObjChar, bool>> predicate)
    {
        _RefObjChar? value = RefObjChars.Values.AsQueryable().AsNoTracking().FirstOrDefault(predicate.Compile());

        if (value != null) return value;

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        value = await db._RefObjChars.AsNoTracking().FirstOrDefaultAsync(predicate);
        if (value != null)
        {
            RefObjChars.TryAdd(value.ID, value);
        }

        return value;
    }

    public static async Task<_RefSkill?> GetRefSkillAsync(int id)
    {
        if (RefSkills.ContainsKey(id))
        {
            return RefSkills[id];
        }

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        _RefSkill? value = await db._RefSkills.AsNoTracking().FirstOrDefaultAsync(entry => entry.ID == id);

        if (value != null)
        {
            RefSkills.TryAdd(id, value);
        }

        return value;
    }

    public static async Task<_RefSkill?> GetRefSkillAsync(Expression<Func<_RefSkill, bool>> predicate)
    {
        _RefSkill? value = RefSkills.Values.AsQueryable().AsNoTracking().FirstOrDefault(predicate.Compile());

        if (value != null) return value;

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        value = await db._RefSkills.AsNoTracking().FirstOrDefaultAsync(predicate);
        if (value != null)
        {
            RefSkills.TryAdd(value.ID, value);
        }

        return value;
    }

    public static async Task<_RefRegion?> GetRefRegionAsync(int regionId)
    {
        if (RefRegions.ContainsKey(regionId))
        {
            return RefRegions[regionId];
        }

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        _RefRegion? value = await db._RefRegions.AsNoTracking().FirstOrDefaultAsync(entry => entry.wRegionID == regionId);

        if (value != null)
        {
            RefRegions.TryAdd(regionId, value);
        }

        return value;
    }

    public static async Task<_RefRegion?> GetRefRegionAsync(Expression<Func<_RefRegion, bool>> predicate)
    {
        _RefRegion? value = RefRegions.Values.AsQueryable().AsNoTracking().FirstOrDefault(predicate.Compile());

        if (value != null) return value;

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        value = await db._RefRegions.AsNoTracking().FirstOrDefaultAsync(predicate);

        if (value != null)
        {
            RefRegions.TryAdd(value.wRegionID, value);
        }

        return value;
    }

    public static async Task<_RefQuest?> GetRefQuestAsync(int id)
    {
        if (RefQuests.ContainsKey(id))
        {
            return RefQuests[id];
        }

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        _RefQuest? value = await db._RefQuests.FindAsync(id);
        if (value != null)
        {
            RefQuests.TryAdd(id, value);
        }

        return value;
    }

    public static async Task<_RefQuest?> GetRefQuestAsync(Expression<Func<_RefQuest, bool>> predicate)
    {
        _RefQuest? value = RefQuests.Values.AsQueryable().AsNoTracking().FirstOrDefault(predicate.Compile());

        if (value != null) return value;

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        value = await db._RefQuests.AsNoTracking().FirstOrDefaultAsync(predicate);
        if (value != null)
        {
            RefQuests.TryAdd(value.ID, value);
        }

        return value;
    }

    public static async Task<_RefQuestReward?> GetRefQuestRewardAsync(int questId)
    {
        if (RefQuestRewards.ContainsKey(questId))
        {
            return RefQuestRewards[questId];
        }

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        _RefQuestReward? value = await db._RefQuestRewards.FindAsync(questId);
        if (value != null)
        {
            RefQuestRewards.TryAdd(questId, value);
        }

        return value;
    }

    public static async Task<_RefQuestReward?> GetRefQuestRewardAsync(Expression<Func<_RefQuestReward, bool>> predicate)
    {
        _RefQuestReward? value = RefQuestRewards.Values.AsQueryable().AsNoTracking().FirstOrDefault(predicate.Compile());

        if (value != null) return value;

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        value = await db._RefQuestRewards.AsNoTracking().FirstOrDefaultAsync(predicate);
        if (value != null)
        {
            RefQuestRewards.TryAdd(value.QuestID, value);
        }

        return value;
    }

    public static async Task<_RefQuestRewardItem?> GetRefQuestRewardItemAsync(int questId)
    {
        if (RefQuestRewardItems.ContainsKey(questId))
        {
            return RefQuestRewardItems[questId];
        }

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        _RefQuestRewardItem? value = await db._RefQuestRewardItems.FindAsync(questId);
        if (value != null)
        {
            RefQuestRewardItems.TryAdd(questId, value);
        }

        return value;
    }

    public static async Task<_RefQuestRewardItem?> GetRefQuestRewardItemAsync(
        Expression<Func<_RefQuestRewardItem, bool>> predicate)
    {
        _RefQuestRewardItem? value = RefQuestRewardItems.Values.AsQueryable().AsNoTracking().FirstOrDefault(predicate.Compile());

        if (value != null) return value;

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        value = await db._RefQuestRewardItems.AsNoTracking().FirstOrDefaultAsync(predicate);
        if (value != null)
        {
            RefQuestRewardItems.TryAdd(value.QuestID, value);
        }

        return value;
    }

    public static async Task<_RefLevel?> GetRefLevelAsync(byte level)
    {
        if (RefLevels.ContainsKey(level))
        {
            return RefLevels[level];
        }

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        _RefLevel? value = await db._RefLevels.AsNoTracking().FirstOrDefaultAsync(entry => entry.Lvl == level);

        if (value != null)
        {
            RefLevels.TryAdd(level, value);
        }

        return value;
    }

    public static async Task<_RefLevel?> GetRefLevelAsync(Expression<Func<_RefLevel, bool>> predicate)
    {
        _RefLevel? value = RefLevels.Values.AsQueryable().AsNoTracking().FirstOrDefault(predicate.Compile());

        if (value != null) return value;

        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        value = await db._RefLevels.AsNoTracking().FirstOrDefaultAsync(predicate);
        if (value != null)
        {
            RefLevels.TryAdd(value.Lvl, value);
        }

        return value;
    }

    public static async Task<_Notice?> GetNoticeAsync(int id)
    {
        if (Notices.ContainsKey(id))
        {
            return Notices[id];
        }

        await using Context.SRO_VT_ACCOUNT db = new Context.SRO_VT_ACCOUNT();
        _Notice? value = await db._Notices.FindAsync(id);
        if (value != null)
        {
            Notices.TryAdd(id, value);
        }

        return value;
    }

    public static async Task<_Notice?> GetNoticeAsync(Expression<Func<_Notice, bool>> predicate)
    {
        _Notice? value = Notices.Values.AsQueryable().AsNoTracking().FirstOrDefault(predicate.Compile());

        if (value != null) return value;

        await using Context.SRO_VT_ACCOUNT db = new Context.SRO_VT_ACCOUNT();
        value = await db._Notices.AsNoTracking().FirstOrDefaultAsync(predicate);
        if (value != null)
        {
            Notices.TryAdd(value.ID, value);
        }

        return value;
    }

    public static async Task<_Char?> GetCharAsync(int charId)
    {
        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        return await db._Chars.AsNoTracking().FirstOrDefaultAsync(c => c.CharID == charId);
    }

    public static async Task<_Char?> GetCharAsync(Expression<Func<_Char, bool>> predicate)
    {
        await using Context.SRO_VT_SHARD db = new Context.SRO_VT_SHARD();
        return await db._Chars.AsNoTracking().FirstOrDefaultAsync(predicate);
    }
}