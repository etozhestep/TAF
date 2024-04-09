using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebDriverProject.Utils;

public class WaitsHelper
{
    private IWebDriver driver { get; set; }
    private WebDriverWait _wait;
    private TimeSpan _timeout { get; set; }

    public WaitsHelper(IWebDriver driver,TimeSpan timeout)
    {
        this.driver = driver;
        _timeout = timeout;
        _wait = new WebDriverWait(driver, _timeout);
    }

    public IWebElement WaitForVisibility(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }
    public bool WaitForElementInvisible(By locator)
    {
        return _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
    }
    public bool WaitForElementInvisible(IWebElement element)
    {
        try
        {
            _wait.Until(d => !element.Displayed);
            return true;
        }
        catch (NoSuchElementException)
        {
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            throw new WebDriverTimeoutException($"Element visible after {_timeout} seconds");
        }
        
    }
}