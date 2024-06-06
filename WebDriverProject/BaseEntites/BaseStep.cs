using OpenQA.Selenium;
using WebDriverProject.Pages;

namespace WebDriverProject.BaseEntites;

public class BaseStep
{
    protected IWebDriver _driver;
    protected LoginPage LoginPage;
    protected ProductsPage ProductsPage;

    public BaseStep(IWebDriver driver)
    {
        _driver = driver;

        LoginPage = new LoginPage(driver);
        ProductsPage = new ProductsPage(driver);
    }

}