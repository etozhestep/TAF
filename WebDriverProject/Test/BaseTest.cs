using OpenQA.Selenium;
using WebDriverProject.Core;
using WebDriverProject.Pages;
using WebDriverProject.Utils;

namespace WebDriverProject.Test;

[Parallelizable(ParallelScope.Fixtures)]
public class BaseTest
{
    public IWebDriver Driver { get; set; }
    public LoginPage LoginPage { get; set; }
    public ProductsPage ProductsPage { get; set; }
    public WaitsHelper _waitsHelper { get; set; }

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;
        LoginPage = new LoginPage(Driver);
        ProductsPage = new ProductsPage(Driver);
        _waitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.ReadConfiguration().TimeOut));
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Dispose();
    }
}