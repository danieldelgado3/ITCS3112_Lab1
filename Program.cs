using ITCS3112_Lab1.Contracts;
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
                    //ShowCourseCatalog();
                    break;

                case "2":
                    //EnrollNewStudent(studentService);
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