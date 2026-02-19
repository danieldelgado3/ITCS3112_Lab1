using ITCS3112_Lab1.Contracts;
using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Repository;

public class InMemoryRepository : IRepository
{
    private  List<Item> _inventory;
    private List<CheckoutRecord> _checkoutRecords;

    public InMemoryRepository()
    {
        _inventory = new List<Item>();
        _checkoutRecords = new List<CheckoutRecord>();
    }

    public void SaveItem(Item item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        if (_inventory.Any(i => i.Id == item.Id))
        {
            throw new InvalidOperationException($"Item with id {item.Id} already exists");
        }
        _inventory.Add(item);
    }

    public Item? GetItem(string itemId)
    {
        foreach (Item item in _inventory)
        {
            if (item.Id == itemId)
            {
                return item;
            }
        }
        throw new KeyNotFoundException($"Item with id {itemId} does not exist");
    }

    public List<Item> AllItems()
    {
        return _inventory;
    }

    public void SaveRecord(CheckoutRecord record)
    {
        if (record is null)
        {
            throw new ArgumentNullException(nameof(record));
        }
        
        _checkoutRecords.Add(record);
    }

    public CheckoutRecord? GetActiveRecordFor(string itemId)
    {
        foreach (CheckoutRecord record in _checkoutRecords)
        {
            if (record.Item.Id == itemId)
            {
                return record;
            } 
        }
        throw new KeyNotFoundException($"Item with id {itemId} does not exist");
    }

    public List<CheckoutRecord> AllRecords()
    {
        return  _checkoutRecords;
    }
}