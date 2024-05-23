using Microsoft.Playwright;
using WebDriverProject.Utils;

namespace PlayWright.Test;

public class LoginTest : BaseTest
{
    [Test]
    public async Task LoginWithCorrectCredentials()
    {
        await LoginPage.NavigateAsync();
        await LoginPage.LoginAsync(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        await Assertions.Expect(Page.Locator(ProductsPage.productsTitle)).ToBeVisibleAsync();
    }
}