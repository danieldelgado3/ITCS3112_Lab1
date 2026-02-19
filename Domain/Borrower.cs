namespace ITCS3112_Lab1.Domain;

public class Borrower
{
    public string Id { get; }
    public string Name { get; }
    public string Email { get; }

    public Borrower(string id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

}