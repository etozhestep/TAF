using Microsoft.Playwright;
using PW1.Core;
using PW1.Page;

namespace PW1.Test;

public class BaseTest
{
    protected BrowserManager BrowserManager { get; set; }
    protected LoginPage LoginPage { get; set; }

    [SetUp]
    public async Task Setup()
    {
        BrowserManager = new BrowserManager();
        await BrowserManager.InitializeAsync();
        LoginPage = new LoginPage(BrowserManager.Page);
    }

    [TearDown]
    public async Task TearDown()
    {
        await BrowserManager.Cleanup();
    }
}