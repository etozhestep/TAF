using WebDriverProject.Models;
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
        var userWithoutPass = new UserModel()
        {
            UserName = Configurator.ReadConfiguration().UserNameSauceDemo
        };

        Assert.That(
            UserStep.UnsuccesfulLoginWithoutPassword(userWithoutPass)
                .ErrorTitle()
                .Text, Is.EqualTo("Epic sadface: Password is required"));
    }

    [Test]
    public void LoginWithoutUsernameAndPassword()
    {
        Assert.That(UserStep
            .UnsuccesfulLoginWithoutUserNameAndPassword()
            .ErrorTitle()
            .Text, Is.EqualTo("Epic sadface: Username is required"));
    }
}