using Microsoft.Playwright;

namespace PlayWright.Core;

public class BrowserManager
{
    public IBrowser Browser { get; private set; }
    public IPage Page { get; set; }

    public async Task InitializeDriver()
    {
        var playwright = await Playwright.CreateAsync();
        Browser = await playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions()
            {
                Headless = false
            });
        Page = await Browser.NewPageAsync();
    }

    public async Task CloseBrowser()
    {
        await Browser.CloseAsync();
    }
}