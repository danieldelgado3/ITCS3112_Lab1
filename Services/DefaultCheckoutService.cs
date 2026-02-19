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
        this._repository = repository;
        _policy = policy;
        _notifier = notifier;
        _clock = clock;
        _catalog = catalog;
    }

    public ICatalog GetCatalog()
    {
        throw new NotImplementedException();
    }

    public Receipt Checkout(string itemId, Borrower borrower, DateTime dueDate)
    {
        throw new NotImplementedException();
    }

    public Receipt ReturnItem(string itemId)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
}