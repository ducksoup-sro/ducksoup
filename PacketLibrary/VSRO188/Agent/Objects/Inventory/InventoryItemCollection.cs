using System.Collections;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Inventory;

// https://github.com/SDClowen/RSBot/
public class InventoryItemCollection : IEnumerable
{
    protected List<InventoryItem> _collection;

    public byte Capacity
    {
        get => (byte) (_collection.Capacity - 1);
        set => _collection.Capacity = value + 1;
    }

    public int Count => _collection.Count;

    public virtual bool Full => Count >= Capacity;

    public bool IsReadOnly => false;

    public InventoryItem this[int index]
    {
        get => _collection[index];
        set => _collection[index] = value;
    }

    public InventoryItemCollection(byte size)
    {
        _collection = new List<InventoryItem>(size + 1);
    }

    public InventoryItemCollection(Packet packet)
    {
        _collection = new List<InventoryItem>();
        Deserialize(packet);
    }

    public void Add(InventoryItem newItem)
        => _collection.Add(newItem);

    public bool Remove(InventoryItem item)
        => _collection.Remove(item);

    public void RemoveAt(byte slot)
        => _collection.RemoveAll(p => p.Slot == slot);

    public InventoryItem GetItemAt(byte slot)
        => GetItem(item => item.Slot == slot);

    public bool Contains(InventoryItem item)
        => _collection.Contains(item);

    public bool Contains(byte slot)
        => GetItem(item => item.Slot == slot) != null;

    public void UpdateItemSlot(byte slot, byte newSlot)
    {
        if (GetItemAt(slot) is InventoryItem itemToUpdate)
            itemToUpdate.Slot = newSlot;
    }

    public void UpdateItemAmount(byte slot, ushort newAmount)
    {
        if (newAmount <= 0)
        {
            RemoveAt(slot);
            return;
        }

        if (GetItemAt(slot) is InventoryItem itemToUpdate)
            itemToUpdate.Amount = newAmount;
    }

    protected void OrderBySlot()
        => _collection.Sort((a, b) => a.Slot.CompareTo(b.Slot));

    public IList<InventoryItem> GetItems(Predicate<InventoryItem> predicate)
    {
        //OrderBySlot();
        return _collection.FindAll(predicate);
    }

    public ICollection<InventoryItem> GetItems(uint objId)
        => GetItems(item => item.Record.ID == objId);

    public ICollection<InventoryItem> GetItems(string recordCodeName)
        => GetItems(item => item.Record.GetRefObjCommon.CodeName128 == recordCodeName);

    public ICollection<InventoryItem> GetItems(TypeIdFilter filter)
        => GetItems(item => filter.EqualsRefItem(item.Record.GetRefObjCommon));

    public ICollection<InventoryItem> GetItems(TypeIdFilter filter, Predicate<InventoryItem> action)
        => GetItems(item => filter.EqualsRefItem(item.Record.GetRefObjCommon) && action(item));

    public InventoryItem GetItem(Predicate<InventoryItem> predicate)
        => GetItems(predicate).FirstOrDefault();

    public InventoryItem GetItem(uint objId)
        => GetItem(item => item.Record.ID == objId);

    public InventoryItem GetItem(TypeIdFilter filter)
        => GetItem(item => filter.EqualsRefItem(item.Record.GetRefObjCommon));

    public InventoryItem GetItem(TypeIdFilter filter, Predicate<InventoryItem> action)
        => GetItem(item => filter.EqualsRefItem(item.Record.GetRefObjCommon) && action(item));

    public InventoryItem GetItem(string recordCodeName)
        => GetItem(item => item.Record.GetRefObjCommon.CodeName128 == recordCodeName);

    public int GetSumAmount(string recordCodeName)
    {
        var sum = 0;
        foreach (var item in GetItems(recordCodeName))
            sum += item.Amount;

        return sum;
    }

    public int GetSumAmount(TypeIdFilter filter)
    {
        var sum = 0;
        foreach (var item in GetItems(filter))
            sum += item.Amount;

        return sum;
    }

    public virtual byte GetFreeSlot()
    {
        for (byte slot = 0; slot < Capacity; slot++)
        {
            if (GetItemAt(slot) == null)
                return slot;
        }

        return 0xFF;
    }

    public void CopyTo(InventoryItem[] array, int arrayIndex)
        => _collection.CopyTo(array, arrayIndex);

    public void Clear()
        => _collection.Clear();

    public IEnumerator<InventoryItem> GetEnumerator()
    {
        //OrderBySlot();
        return _collection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        //OrderBySlot();
        return _collection.GetEnumerator();
    }

    public void Deserialize(Packet packet)
    {
        packet.TryRead<byte>(out var capacity);
        if (capacity <= 0)
            return;

        packet.TryRead<byte>(out var amount);
        for (var i = 0; i < amount; i++)
            _collection.Add(InventoryItem.FromPacket(packet));
    }
}