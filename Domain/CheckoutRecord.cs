namespace ITCS3112_Lab1.Domain;

public class CheckoutRecord
{
    public Item Item { get; }
    public Borrower Borrower { get; }
    public DateTime CheckoutDate { get; }
    public DateTime DueDate { get; }

    public CheckoutRecord(Item item, Borrower borrower, DateTime checkoutDate, DateTime dueDate)
    {
        Item = item;
        Borrower = borrower;
        CheckoutDate = checkoutDate;
        DueDate = dueDate;
    }
    
}