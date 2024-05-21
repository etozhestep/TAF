using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverProject.Utils;

namespace WebDriverProject.Pages;

public abstract class BasePage : LoadableComponent<BasePage>
{
    protected IWebDriver Driver { get; set; }


    protected BasePage(IWebDriver driver, bool openPageByUrl = false)
    {
        Driver = driver;
        if (openPageByUrl)

        {
            //ExecuteLoad();
            Load();
        }
    }

    public abstract string GetEndpoint();

    protected override void ExecuteLoad()
    {
        Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl + GetEndpoint());
    }
}