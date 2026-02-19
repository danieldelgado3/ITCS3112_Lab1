using ITCS3112_Lab1.Contracts;
using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Services;

public class LogNotifier : INotifier
{
    public void DueSoon(Borrower borrower, CheckoutRecord record)
    {
        throw new NotImplementedException();
    }

    public void Overdue(Borrower borrower, CheckoutRecord record)
    {
        throw new NotImplementedException();
    }
}