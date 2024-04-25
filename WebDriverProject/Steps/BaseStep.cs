using OpenQA.Selenium;

namespace WebDriverProject.Steps;

public class BaseStep
{
    protected IWebDriver _driver;

    public BaseStep(IWebDriver driver)
    {

        _driver = driver;
    }

}