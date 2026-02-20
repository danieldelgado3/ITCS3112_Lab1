using ITCS3112_Lab1.Domain;

namespace ITCS3112_Lab1.Contracts;
// TODO: need to do xml
public interface IRepository
{
    void SaveItem(Item item);
    Item? GetItem(string itemId);
    List<Item> AllItems();

    void SaveRecord(CheckoutRecord record);
    CheckoutRecord? GetActiveRecordFor(string itemId);
    List<CheckoutRecord> AllRecords();
    public void RemoveRecord(CheckoutRecord record);
}