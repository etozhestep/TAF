using WebDriverProject.Utils;

namespace PW1.Test;

[TestFixture]
public class LoginTests : BaseTest
{
    [Test]
    public async Task LoginWithCorrectCredentials()
    {
        var productPage = await LoginPage.LoginAsync(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        var productTitle = await productPage.ProductTitle();
        var isProductTitleDisplayed = await productTitle.IsVisibleAsync();
        Assert.That(isProductTitleDisplayed);
    }
}