using OpenQA.Selenium.DevTools.V121.Audits;
using WebDriverProject.Models;
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
    [Category("Positive Test")]
    public void PositiveLogin()
    {
        var admin = new UserModel()
        {
            UserName = Configurator.ReadConfiguration().UserNameSauceDemo,
            Password = Configurator.ReadConfiguration().PasswordSauceDemo
        };

        Assert.That(UserStep.SuccessfulLogin(admin)
            .ProductsTitle().Displayed, Is.True);
    }


    [Test]
    [Category("Positive Test")]

    public void NavigateToProductsTest()
    {
        var admin = new UserModel()
        {
            UserName = Configurator.ReadConfiguration().UserNameSauceDemo,
            Password = Configurator.ReadConfiguration().PasswordSauceDemo
        };

        UserStep.SuccessfulLogin(admin).CartIcon().Click();

        NavigationStep.NavigateToProductsPage();
    }
}