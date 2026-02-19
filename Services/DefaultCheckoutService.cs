using ITCS3112_Lab1.Contracts;
using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Services;

public class DefaultCheckoutService : ICheckoutService
{
    private readonly IRepository _repository;
    private readonly IPolicy _policy;
    private readonly INotifier _notifier;
    private readonly IClock _clock;
    private readonly ICatalog _catalog;

    public DefaultCheckoutService(
        IRepository repository, 
        IPolicy policy, 
        INotifier notifier, 
        IClock clock, 
        ICatalog catalog)
    {
        _repository = repository;
        _policy = policy;
        _notifier = notifier;
        _clock = clock;
        _catalog = catalog;
    }

    public ICatalog GetCatalog()
    {
        return _catalog;
    }

    public Receipt Checkout(string itemId, Borrower borrower, DateTime dueDate)
    {
        Item item = _repository.GetItem(itemId);

        if (!_policy.CanCheckout(item))
        {
            throw new Exception($"Item with id {itemId} cannot checkout");
        }

        item.MarkCheckedOut();

        CheckoutRecord record =
            new CheckoutRecord(item, borrower, _clock.Today(), dueDate);

        _repository.SaveRecord(record);

        return new Receipt($"{item.Name} with Item ID: {itemId} has been checked out");
    }


    public Receipt ReturnItem(string itemId)
    {
        CheckoutRecord? record = _repository.GetActiveRecordFor(itemId);
        
        Item item = record.Item;
        
        item.MarkAvailable();
        
        _repository.RemoveRecord(record);
        
        return new Receipt($"Item {itemId} has been returned.");
    }

    public void MarkLost(string itemId)
    {
        throw new NotImplementedException();
    }

    public List<CheckoutRecord> ListActiveLoans()
    {
        throw new NotImplementedException();
    }

    public List<CheckoutRecord> FindDueSoon(TimeSpan window)
    {
        throw new NotImplementedException();
    }

    public List<CheckoutRecord> FindOverdue()
    {
        DateTime today = _clock.Today();
        List<CheckoutRecord> records = _repository.AllRecords();
        List<CheckoutRecord> overdueList = new List<CheckoutRecord>();
        foreach (CheckoutRecord record in records)
        {
            if (record.DueDate < today)
            {
                overdueList.Add(record);
            }
        }
        return overdueList;
    }

    public void AddItem(string id, string name, string category, string condition)
    {
        if (id is null || name is null || category is null || condition is null)
        {
            throw new ArgumentException("Unable to create item");
        }

        if (category != "VR Headset" && category != "Sensor" && category != "Laptop")
        {
            throw new ArgumentException("Category must be either VR Headset or Sensor or Laptop");
        }
        Item item = new Item(id, name, category, condition);
        _repository.SaveItem(item);
    }
}