using ITCS3112_Lab1.Contracts;
using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Services;

public class DefaultPolicy : IPolicy
{
    public bool CanCheckout(Item item)
    {
        return item.Status == ItemStatus.Available;
    }
    //TODO
    public DateTime NormalizeDueDate(DateTime proposed)
    {
        throw new NotImplementedException();
    }
}