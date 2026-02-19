using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Contracts;

public interface INotifier
{
    void DueSoon(Borrower borrower, CheckoutRecord record);
    void Overdue(Borrower borrower, CheckoutRecord record);
}