using WebDriverProject.Utils;

namespace WebDriverProject.Test;

[TestFixture]
public class NegativeTests : BaseTest
{
    [SetUp]
    public void Setup()
    {
        Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl);
    }

    [Test]
    public void LoginWithoutPassword()
    {
        LoginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo);

        Assert.That(LoginPage.ErrorTitle().Text, Is.EqualTo("Epic sadface: Password is required"));
    }

    [Test]
    public void LoginWithoutUsernameAndPassword()
    {
        LoginPage.Login();
        Assert.That(LoginPage.ErrorTitle().Text, Is.EqualTo("Epic sadface: Username is required"));
    }
}