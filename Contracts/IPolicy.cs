using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Contracts;

/// <summary>
/// Interface that controls checkout policies.
/// </summary>
public interface IPolicy
{
    /// <summary>
    /// Checks if an item can be checked out.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>True if the item is available, false otherwise</returns>
    /// <remarks>
    /// Preconditions:
    /// - item must not be null.
    /// </remarks>
    bool CanCheckout(Item item);
    
    // TODO: Need to do xml
    DateTime NormalizeDueDate(DateTime proposed);
}