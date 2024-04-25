using OpenQA.Selenium;

namespace WebDriverProject.Pages;

public class ProductsPage : BasePage
{
    private static readonly By ProductsTitleBy = By.XPath("//*[.='Products']");
    private readonly string _endPoint = "inventory.html";

    public ProductsPage(IWebDriver driver) : base(driver)
    {
        Driver = driver;
    }

    protected IWebDriver Driver { get; set; }

    public override string GetEndpoint()
    {
        return _endPoint;
    }

    public IWebElement ProductsTitle()
    {
        return Driver.FindElement(ProductsTitleBy);
    }

    protected override bool EvaluateLoadedStatus()
    {
        return ProductsTitle().Displayed;
    }
}