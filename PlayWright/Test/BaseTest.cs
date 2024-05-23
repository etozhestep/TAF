using Microsoft.Playwright;
using PlayWright.Core;
using PlayWright.Page;

namespace PlayWright.Test;

public class BaseTest
{
    protected BrowserManager BrowserManager { get; set; }
    protected IPage Page { get; set; }
    protected LoginPage LoginPage { get; set; }
    protected ProductsPage ProductsPage { get; set; }

    [SetUp]
    public async Task Setup()
    {
        BrowserManager = new BrowserManager();
        await BrowserManager.InitializeDriver();
        Page = BrowserManager.Page;
        LoginPage = new LoginPage(Page);
        ProductsPage = new ProductsPage(Page);
    }

    [TearDown]
    public async Task TearDown()
    {
        await BrowserManager.CloseBrowser();
    }
}