using OpenQA.Selenium;
using WebDriverProject.Utils;

namespace WebDriverProject.Pages;

public abstract class BasePage
{
    protected IWebDriver Driver { get; set; }


    public BasePage(IWebDriver driver)
    {
        Driver = driver;
    }

    public abstract string GetEndpoint();

    public void OpenPageByUrl(string endPoint)
    {
        Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl + endPoint);
    }
}