using Microsoft.Playwright;
using WebDriverProject.Utils;

namespace PlayWright.Page;

public class ProductsPage : BasePage
{
    private const string _endPoint = "inventory.html";
    public string productsTitle = "xpath=//*[.='Products']";

    public ProductsPage(IPage page) : base(page)
    {
    }

    public override async Task NavigateAsync()
    {
        await Page.GotoAsync(Configurator.ReadConfiguration().SauceDemoUrl + _endPoint);
    }
}