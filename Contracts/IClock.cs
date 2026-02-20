namespace ITCS3112_Lab1.Contracts;

/// <summary>
/// Gets the current date.
/// </summary>
public interface IClock
{
    /// <summary>
    /// Gets today's date.
    /// </summary>
    /// <returns>The current date.</returns>
    DateTime Today();
}