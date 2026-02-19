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
        throw new NotImplementedException();
    }

    public Item? FindById(string itemId)
    {
        throw new NotImplementedException();
    }

    public List<Item> SearchBy(string query)
    {
        throw new NotImplementedException();
    }
}