using NLog;
using WebDriverProject.Utils;

namespace WebDriverProject.Test;

[TestFixture]
public class NegativeTests : BaseTest
{
    [SetUp]
    public void Setup()
    {
        try
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl);
        }
        catch (Exception e)
        {
           logger.Error(e,"Невозможно перейти на сайт");
            throw;
        }
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