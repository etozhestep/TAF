using WebDriverProject.Connector;
using WebDriverProject.Models;
using WebDriverProject.Services;

namespace WebDriverProject.Test;

public class DatabaseTest
{
    private DbConnector _connector;
    private CustomerService _customerService;

    [OneTimeSetUp]
    public void ConnectToDatabase()
    {
        _connector = new DbConnector();
        _customerService = new CustomerService(_connector.Connection);
    }

    [Test]
    public void GetAllData()
    {
        Assert.That(_customerService.GetAllCustomers().Count == 6);
    }

    [Test]
    public void AddCustomerTest()
    {
        var expectedCustomer = new Customers()
        {
            FirstName = "Ted",
            LastName = "Thor",
            Email = "tt@test.com",
            Age = 42
        };
        var actualCustomer = _customerService.AddCustomerAndReturnModel(expectedCustomer);
        Assert.That(actualCustomer.Equals(expectedCustomer));
    }

    [Test]
    public void RemoveCustomerTest()
    {
        _customerService.DeleteCustomerById(14);
        Assert.That(_customerService.GetCustomerById(14) == null);
    }

    [Test]
    public void GetCustomerTest()
    {
        Assert.That(_customerService.GetCustomerById(9)!.FirstName.Equals("Ted"));
    }


    [OneTimeTearDown]
    public void DisconnectFromDatabase()
    {
        if (_connector != null)
        {
            _connector.CloseConnection();
        }
    }
}