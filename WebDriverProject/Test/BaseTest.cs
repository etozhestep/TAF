using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
    public WaitsHelper? WaitsHelper { get; set; }
    public Actions Actions { get; set; }
    public IJavaScriptExecutor Js { get; set; }

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;
        LoginPage = new LoginPage(Driver);
        ProductsPage = new ProductsPage(Driver);
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.ReadConfiguration().TimeOut));
        Actions = new Actions(Driver);
        Js = (IJavaScriptExecutor)Driver;
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Dispose();
    }
}