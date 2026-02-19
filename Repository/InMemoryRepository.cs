using ITCS3112_Lab1.Contracts;
using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Repository;

public class InMemoryRepository : IRepository
{
    private List<Item> _inventory;
    private List<CheckoutRecord> _checkoutRecords;

    public InMemoryRepository()
    {
        _inventory = new List<Item>();
        _checkoutRecords = new List<CheckoutRecord>();
    }

    public void SaveItem(Item item)
    {
        throw new NotImplementedException();
    }

    public Item? GetItem(string itemId)
    {
        throw new NotImplementedException();
    }

    public List<Item> AllItems()
    {
        throw new NotImplementedException();
    }

    public void SaveRecord(CheckoutRecord record)
    {
        throw new NotImplementedException();
    }

    public CheckoutRecord? GetActiveRecordFor(string itemId)
    {
        throw new NotImplementedException();
    }

    public List<CheckoutRecord> AllRecords()
    {
        throw new NotImplementedException();
    }
}