using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Contracts;

public interface ICatalog
{
    List<Item> ListAvailable();
    List<Item> ListCheckedOut();
    List<Item> ListLost();
    Item? FindById(string itemId);
    List<Item> SearchBy(string query);
}