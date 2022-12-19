using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using API.Objects;
using API.Objects.Inventory;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Inventory;

// https://github.com/SDClowen/RSBot/
public class InventoryItemCollection : IInventoryItemCollection
{
    protected List<IInventoryItem> _collection;

    public byte Capacity
    {
        get => (byte) (_collection.Capacity - 1);
        set => _collection.Capacity = value + 1;
    }

    public int Count => _collection.Count;

    public virtual bool Full => Count >= Capacity;

    public bool IsReadOnly => false;

    public IInventoryItem this[int index]
    {
        get => _collection[index];
        set => _collection[index] = value;
    }

    public InventoryItemCollection(byte size)
    {
        _collection = new List<IInventoryItem>(size + 1);
    }

    public InventoryItemCollection(Packet packet)
    {
        _collection = new List<IInventoryItem>();
        Deserialize(packet);
    }

    public void Add(IInventoryItem newItem)
        => _collection.Add(newItem);

    public bool Remove(IInventoryItem item)
        => _collection.Remove(item);

    public void RemoveAt(byte slot)
        => _collection.RemoveAll(p => p.Slot == slot);

    public IInventoryItem GetItemAt(byte slot)
        => GetItem(item => item.Slot == slot);

    public bool Contains(IInventoryItem item)
        => _collection.Contains(item);

    public bool Contains(byte slot)
        => GetItem(item => item.Slot == slot) != null;

    public void UpdateItemSlot(byte slot, byte newSlot)
    {
        if (GetItemAt(slot) is IInventoryItem itemToUpdate)
            itemToUpdate.Slot = newSlot;
    }

    public void UpdateItemAmount(byte slot, ushort newAmount)
    {
        if (newAmount <= 0)
        {
            RemoveAt(slot);
            return;
        }

        if (GetItemAt(slot) is IInventoryItem itemToUpdate)
            itemToUpdate.Amount = newAmount;
    }

    protected void OrderBySlot()
        => _collection.Sort((a, b) => a.Slot.CompareTo(b.Slot));

    public IList<IInventoryItem> GetItems(Predicate<IInventoryItem> predicate)
    {
        //OrderBySlot();
        return _collection.FindAll(predicate);
    }

    public ICollection<IInventoryItem> GetItems(uint objId)
        => GetItems(item => item.Record.ID == objId);

    public ICollection<IInventoryItem> GetItems(string recordCodeName)
        => GetItems(item => item.Record.GetRefObjCommon.CodeName128 == recordCodeName);

    public ICollection<IInventoryItem> GetItems(ITypeIdFilter filter)
        => GetItems(item => filter.EqualsRefItem(item.Record.GetRefObjCommon));

    public ICollection<IInventoryItem> GetItems(ITypeIdFilter filter, Predicate<IInventoryItem> action)
        => GetItems(item => filter.EqualsRefItem(item.Record.GetRefObjCommon) && action(item));

    public IInventoryItem GetItem(Predicate<IInventoryItem> predicate)
        => GetItems(predicate).FirstOrDefault();

    public IInventoryItem GetItem(uint objId)
        => GetItem(item => item.Record.ID == objId);

    public IInventoryItem GetItem(ITypeIdFilter filter)
        => GetItem(item => filter.EqualsRefItem(item.Record.GetRefObjCommon));

    public IInventoryItem GetItem(ITypeIdFilter filter, Predicate<IInventoryItem> action)
        => GetItem(item => filter.EqualsRefItem(item.Record.GetRefObjCommon) && action(item));

    public IInventoryItem GetItem(string recordCodeName)
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

    public void CopyTo(IInventoryItem[] array, int arrayIndex)
        => _collection.CopyTo(array, arrayIndex);

    public void Clear()
        => _collection.Clear();

    public IEnumerator<IInventoryItem> GetEnumerator()
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
        Capacity = packet.ReadUInt8();
        if (Capacity <= 0)
            return;

        var amount = packet.ReadUInt8();
        for (var i = 0; i < amount; i++)
            _collection.Add(InventoryItem.FromPacket(packet));
    }
}