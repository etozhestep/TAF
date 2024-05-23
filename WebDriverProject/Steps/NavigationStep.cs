using OpenQA.Selenium;
using WebDriverProject.BaseEntites;
using WebDriverProject.Pages;

namespace WebDriverProject.Steps;

public class NavigationStep : BaseStep
{
    public NavigationStep(IWebDriver driver) : base(driver)
    {
        _driver = driver;
    }

    public void NavigateToCartPage()
    {
    }

    public ProductsPage NavigateToProductsPage()
    {
        return new ProductsPage(_driver, true);
    }
}