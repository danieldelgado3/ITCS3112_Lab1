using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Contracts;

/// <summary>
/// Defines the catalog interface for retrieving items.
/// </summary>
public interface ICatalog
{
    /// <summary>
    /// Lists all items that are available.
    /// </summary>
    /// <returns>A list of available items.</returns>
    /// <remarks>
    /// Postconditions:
    /// - Returned list that only contains items that are not currently checked out or lost.
    /// </remarks>
    List<Item> ListAvailable();
    
    /// <summary>
    /// Lists all items that are checked out.
    /// </summary>
    /// <returns>A list of checked out items.</returns>
    List<Item> ListCheckedOut();
    
    /// <summary>
    /// Lists all items that are marked as lost.
    /// </summary>
    /// <returns>A list of lost items.</returns>
    List<Item> ListLost();
    
    /// <summary>
    /// Finds an item by its ID.
    /// </summary>
    /// <param name="itemId">The ID of the item.</param>
    /// <returns>The item with the matching ID.</returns>
    /// <remarks>
    /// Preconditions:
    /// - itemId must not be null or empty.
    /// </remarks>
    Item? FindById(string itemId);
    
    /// <summary>
    /// Searches items using a query.
    /// </summary>
    /// <param name="query">The search query.</param>
    /// <returns>A list of matching items.</returns>
    /// <remarks>
    /// Preconditions:
    /// - query must not be null.
    /// </remarks>
    List<Item> SearchBy(string query);
    //optional to implement
}