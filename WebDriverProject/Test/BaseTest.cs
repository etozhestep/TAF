using OpenQA.Selenium;
using WebDriverProject.Core;
using WebDriverProject.Pages;

namespace WebDriverProject.Test;

[Parallelizable(ParallelScope.Fixtures)]
public class BaseTest
{
    public IWebDriver Driver { get; set; }
    public LoginPage LoginPage { get; set; }
    public ProductsPage ProductsPage { get; set; }

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;
        LoginPage = new LoginPage(Driver);
        ProductsPage = new ProductsPage(Driver);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Dispose();
    }
}