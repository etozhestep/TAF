using Microsoft.Playwright;
using OpenQA.Selenium;
using WebDriverProject.Utils;

namespace PW1.Page;

public class ProductsPage : BasePage
{
    private string _endpoint = "inventory.html";
    public string ProductTitleSelector = "xpath=//*[.='Products']";

    public ProductsPage(IPage page) : base(page)
    {
    }

    public override async Task NavigateAsync()
    {
        await Page.GotoAsync(Configurator.ReadConfiguration().SauceDemoUrl + _endpoint);
    }

    public async Task<IElementHandle?> ProductTitle()
    {
        return await Page.QuerySelectorAsync(ProductTitleSelector);
    }
}