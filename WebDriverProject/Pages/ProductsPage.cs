using OpenQA.Selenium;
using WebDriverProject.Element;

namespace WebDriverProject.Pages;

public class ProductsPage : BasePage
{
    private static readonly By ProductsTitleBy = By.XPath("//*[.='Products']");
    private string _endPoint = "inventory.html";

    protected IWebDriver Driver { get; set; }

    public override string GetEndpoint()
    {
        return _endPoint;
    }

    public ProductsPage(IWebDriver driver) : base(driver)
    {
        Driver = driver;
    }

    public UiElement ProductsTitle() => new(Driver, ProductsTitleBy);
}