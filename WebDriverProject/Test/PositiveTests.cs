using WebDriverProject.Pages;
using WebDriverProject.Utils;

namespace WebDriverProject.Test;

[TestFixture]
public class PositiveTests : BaseTest
{
    [SetUp]
    public void Setup()
    {
        Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl);
    }

    [Test]
    public void PositiveLogin()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);


        ProductsPage.OpenPageByUrl();
        Assert.That(ProductsPage.ProductsTitle().Displayed, Is.True);
    }
}