using ITCS3112_Lab1.Contracts;
using ITCS3112_Lab1.Domain;
using ITCS3112_Lab1.Repository;
using ITCS3112_Lab1.Services;

namespace ITCS3112_Lab1;

class Program
{
    static void Main(string[] args)
    {
        IRepository repository = new InMemoryRepository();
        ICatalog catalog = new DefaultCatalog(repository);
        IPolicy policy = new DefaultPolicy();
        IClock clock = new SystemClock();
        INotifier notifier = new LogNotifier();

        ICheckoutService checkoutService = new DefaultCheckoutService(
            repository,
            policy,
            notifier,
            clock,
            catalog);
        
        Console.WriteLine("Welcome to the Equipment Checkout System!");
        RunLoggedOutMenu(checkoutService);
    }
    
    public static void RunLoggedOutMenu(ICheckoutService checkoutService)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1) Add items to inventory");
            Console.WriteLine("2) List available items");
            Console.WriteLine("3) List unavailable items");
            Console.WriteLine("4) Check out item");
            Console.WriteLine("5) Return item");
            Console.WriteLine("6) Show due soon (next 24h)");
            Console.WriteLine("7) Show overdue items");
            Console.WriteLine("8) Search items (optional)");
            Console.WriteLine("9) Mark item LOST");
            Console.WriteLine("0) Exit");

            string? input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    Console.Write("ID: ");
                    var id = Console.ReadLine();

                    Console.Write("Name: ");
                    var name = Console.ReadLine();

                    Console.Write("Category: ");
                    var category = Console.ReadLine();

                    Console.Write("Condition: ");
                    var condition = Console.ReadLine();
                    
                    checkoutService.AddItem(id, name, category, condition);
                    break;

                case "2":
                    List<Item> available = checkoutService.GetCatalog().ListAvailable();
                    foreach (var item in available)
                    {
                        Console.WriteLine($"{item.Id} {item.Name} {item.Category} {item.Condition}");
                    }
                    break;
                
                case "3":
                    List<Item> unavailable = checkoutService.GetCatalog().ListCheckedOut();
                    foreach (var item in unavailable)
                    {
                        Console.WriteLine($"{item.Id} {item.Name} {item.Category} {item.Condition}");
                    }
                    break;
                
                case "4":
                    Console.Write("Enter item ID: ");
                    var itemId = Console.ReadLine();

                    Console.Write("Enter borrower ID: ");
                    var borrowerId = Console.ReadLine();

                    Console.Write("Enter borrower name: ");
                    var borrowerName = Console.ReadLine();

                    Console.Write("Enter borrower email: ");
                    var borrowerEmail = Console.ReadLine();

                    Console.Write("Enter due date (YYYY-MM-DD): ");
                    var dueInput = Console.ReadLine();

                    DateTime dueDate = DateTime.Parse(dueInput!);

                    Borrower borrower = new Borrower(borrowerId, borrowerName, borrowerEmail);

                    try
                    {
                        Receipt receipt = checkoutService.Checkout(itemId!, borrower, dueDate);
                        Console.WriteLine(receipt.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                
                case "5":
                    Console.Write("Enter item ID: ");
                    var itemIdToReturn = Console.ReadLine();

                    try
                    {
                        Receipt receipt = checkoutService.ReturnItem(itemIdToReturn);
                        Console.WriteLine(receipt.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                
                case "6":

                    break;
                
                case "7":
                    List<CheckoutRecord> overdue =  checkoutService.FindOverdue();
                    Console.WriteLine("Overdue Items:");
                    foreach (var item in overdue)
                    {
                        Console.WriteLine($"{item.Item.Id}, {item.Borrower.Name}, {item.Borrower.Email}, Due: {item.DueDate}");
                    }

                    break;


                case "0":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("Goodbye!");
    }
}