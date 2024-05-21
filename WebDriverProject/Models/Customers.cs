namespace WebDriverProject.Models;

public record Customers
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public virtual bool Equals(Customers customers)
    {
        return customers.FirstName == FirstName && customers.LastName == LastName && customers.Age == Age &&
               customers.Email == Email;
    }
}