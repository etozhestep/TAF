using Microsoft.Playwright;

namespace PW1.Core;

public class BrowserManager
{
    public IBrowser Browser { get; private set; }
    public IPage Page { get; private set; }

    public async Task InitializeAsync()
    {
        var playwright = await Playwright.CreateAsync();
        Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
        {
            Headless = false
        });
        Page = await Browser.NewPageAsync();
    }

    public async Task Cleanup()
    {
        await Browser.CloseAsync();
    }
}