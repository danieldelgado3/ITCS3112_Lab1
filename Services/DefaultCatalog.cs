using ITCS3112_Lab1.Contracts;
using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Services;

public class DefaultCatalog : ICatalog
{
    private readonly IRepository _repository;

    public DefaultCatalog(IRepository repository)
    {
        this._repository = repository;
    }

    public List<Item> ListAvailable()
    {
        List<Item> items = new List<Item>(_repository.AllItems());
        List<Item> availableItems = new List<Item>();
        foreach (var item in items)
        {
            if (item.Status == ItemStatus.Available)
            {
                availableItems.Add(item);
            }
        }
        return availableItems;
    }

    public Item? FindById(string itemId)
    {
        foreach (Item item in _repository.AllItems())
        {
            if (item.Id == itemId)
            {
                return item;
            }
        }
        throw new KeyNotFoundException($"Item with id {itemId} does not exist");
    }

    public List<Item> SearchBy(string query)
    {
        throw new NotImplementedException();
    }
}