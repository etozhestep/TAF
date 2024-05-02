using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverProject.Core;

namespace BDD.StepDefinitions;

public class BaseStepDefs
{
    protected IWebDriver Driver { get; }

    public BaseStepDefs(Browser browser)
    {
        Driver = browser.Driver;
    }
}