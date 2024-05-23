using OpenQA.Selenium;
using WebDriverProject.BaseEntites;

namespace WebDriverProject.Pages;

public class ProductsPage : BasePage
{
    private static readonly By ProductsTitleBy = By.XPath("//*[.='Products']");
    private static readonly By CartIconBy = By.CssSelector("[data-test='shopping-cart-link']");
    private readonly string _endPoint = "inventory.html";

    public ProductsPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
    {
    }

    public override string GetEndpoint()
    {
        return _endPoint;
    }

    public IWebElement ProductsTitle()
    {
        return Driver.FindElement(ProductsTitleBy);
    }

    public IWebElement CartIcon()
    {
        return Driver.FindElement(CartIconBy);
    }

    protected override bool EvaluateLoadedStatus()
    {
        return ProductsTitle().Displayed;
    }
}