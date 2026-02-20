using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Contracts;

/// <summary>
/// Interface for the notification functionality.
/// </summary>
public interface INotifier
{
    /// <summary>
    /// Notifies that an item is due soon.
    /// </summary>
    /// <param name="borrower">The borrower.</param>
    /// <param name="record">The checkout record.</param>
    void DueSoon(Borrower borrower, CheckoutRecord record);
    
    /// <summary>
    /// Notifies that an item is overdue.
    /// </summary>
    /// <param name="borrower">The borrower.</param>
    /// <param name="record">The checkout record.</param>
    void Overdue(Borrower borrower, CheckoutRecord record);
}