using WebDriverProject.Connector;
using WebDriverProject.Models;
using WebDriverProject.Services;

namespace WebDriverProject.Test;

public class DbTests
{
    private DbConnector _connector;
    private CustomerService _customerService;

    [OneTimeSetUp]
    public void SetConnection()
    {
        _connector = new DbConnector();
        _customerService = new CustomerService(_connector.Connection);
    }


    [Test]
    public void GetAllCustomersTest()
    {
        foreach (var customer in _customerService.GetAllCustomers())
        {
            Console.WriteLine(customer.CustomerFirstName);
        }


        Assert.That(_customerService.GetAllCustomers().Count == 3);
    }

    [Test]
    public void AddCustomerTest()
    {
        var expectedCustomer = new Customer()
        {
            CustomerFirstName = "Andrei",
            CustomerSecondName = "Sciapaniuk",
            CustomerEmail = "test@email.com",
            CustomerAge = 26
        };
        _customerService.AddCustomer(expectedCustomer);
    }

    [Test]
    public void UpdateCustomerTest()
    {
    }

    [Test]
    public void DeleteCustomerTest()
    {

        _customerService.DeleteCustomerById(4);
    }

    [OneTimeTearDown]
    public void CloseConnection()
    {
        _connector.CloseConnection();
    }
}