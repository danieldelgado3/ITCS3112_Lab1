using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Contracts;

public interface IPolicy
{
    bool CanCheckout(Item item);
    DateTime NormalizeDueDate(DateTime proposed);
}