namespace ITCS3112_Lab1.Domain;

public class Item
{
    public string Id { get; }
    public string Name { get; }
    public string Category { get; }
    public string Condition { get; }
    public ItemStatus Status { get; private set; }
    
    public Item(string id, string name, string category, string condition)
    {
        Id = id;
        Name = name;
        Category = category;
        Condition = condition;
        Status = ItemStatus.Available;
    }
    
    public void MarkCheckedOut()
    {
        Status = ItemStatus.CheckedOut;
    }

    public void MarkAvailable()
    {
        Status = ItemStatus.Available;
    }

    public void MarkLost()
    {
        Status = ItemStatus.Lost;
    }
    
}