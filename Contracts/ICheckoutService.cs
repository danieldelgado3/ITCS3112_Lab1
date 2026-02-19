using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Contracts;

public interface ICheckoutService
{
    ICatalog GetCatalog();
    Receipt Checkout(string itemId, Borrower borrower, DateTime dueDate);
    Receipt ReturnItem(string itemId);
    void MarkLost(string itemId);
    List<CheckoutRecord> ListActiveLoans();
    List<CheckoutRecord> FindDueSoon(TimeSpan window);
    List<CheckoutRecord> FindOverdue();
    void AddItem(string id, string name, string category, string condition);
}