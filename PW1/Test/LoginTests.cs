using Microsoft.Playwright;
using WebDriverProject.Utils;

namespace PW1.Test;

[TestFixture]
public class LoginTests : BaseTest
{
    [Test]
    public async Task LoginWithCorrectCredentials()
    {
        await LoginPage.NavigateAsync();
        var productPage = await LoginPage.LoginAsync(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        await Assertions.Expect(BrowserManager.Page.Locator(productPage.ProductTitleSelector))
            .ToBeVisibleAsync();
    }
}