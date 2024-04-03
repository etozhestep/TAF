using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverProject.Test;

public class BaseTest
{
    public IWebDriver Driver { get; set; }

    [SetUp]
    public void Setup()
    {
        Driver = new ChromeDriver();
        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Dispose();
    }
}