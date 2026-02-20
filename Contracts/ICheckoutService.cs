using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Contracts;

/// <summary>
/// Defines the ICheckout interface used for the program's main services such as checkouts and returns.
/// </summary>
public interface ICheckoutService
{
    /// <summary>
    /// Gets the catalog.
    /// </summary>
    /// <returns>The catalog.</returns>
    ICatalog GetCatalog();
    
    /// <summary>
    /// Checks out an item to a borrower.
    /// </summary>
    /// <param name="itemId">The item ID.</param>
    /// <param name="borrower">The borrower.</param>
    /// <param name="dueDate">The due date.</param>
    /// <returns>A receipt with the checkout details.</returns>
    /// <remarks>
    /// Preconditions:
    /// - itemId must not be null or empty.
    /// - borrower must not be null.
    /// - dueDate cannot be the current date.
    /// Postconditions:
    /// - Item is marked as checked out.
    /// - A checkout record is created.
    /// </remarks>
    Receipt Checkout(string itemId, Borrower borrower, DateTime dueDate);
    
    /// <summary>
    /// Returns an item to the inventory.
    /// </summary>
    /// <param name="itemId">The item ID.</param>
    /// <returns>A receipt with the return details.</returns>
    /// <remarks>
    /// Preconditions:
    /// - itemId must not be null or empty.
    /// Postconditions:
    /// - Item is marked as available.
    /// </remarks>
    Receipt ReturnItem(string itemId);
    
    /// <summary>
    /// Marks an item as lost.
    /// </summary>
    /// <param name="itemId">The item ID.</param>
    /// <remarks>
    /// Preconditions:
    /// - itemId must not be null or empty.
    /// Postconditions:
    /// - Item is marked as lost.
    /// </remarks>
    void MarkLost(string itemId);
    
    /// <summary>
    /// Returns a list of checkout records.
    /// </summary>
    /// <returns>A list of all active loans.</returns>
    List<CheckoutRecord> ListActiveLoans();
    
    /// <summary>
    /// Returns a list of loans that are due soon.
    /// </summary>
    /// <param name="window">The time window to check.</param>
    /// <returns>A list of loans that are due soon.</returns>
    List<CheckoutRecord> FindDueSoon(TimeSpan window);
    
    /// <summary>
    /// Finds all overdue loans.
    /// </summary>
    /// <returns>A list of overdue loans.</returns>
    List<CheckoutRecord> FindOverdue();
    
    /// <summary>
    /// Adds an item to the inventory.
    /// </summary>
    /// <param name="id">The item ID.</param>
    /// <param name="name">The name of the item.</param>
    /// <param name="category">The category of the item.</param>
    /// <param name="condition">The condition of the item.</param>
    /// <remarks>
    /// Preconditions:
    /// -All the parameters cannot be null.
    /// Postconditions:
    /// - Item is saved to the repository.
    /// </remarks>
    void AddItem(string id, string name, string category, string condition);
}