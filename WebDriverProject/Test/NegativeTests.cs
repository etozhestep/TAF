using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverProject.Test;

public class NegativeTests : BaseTest
{
    private const string Url = "https://www.saucedemo.com/";
    private string userNameXpathLocator = "//input[@data-test='username']";
    private string passwordCssLocator = "[placeholder='Password']";
    private string loginButtonCssLocator = ".submit-button.btn_action";

    [Test]
    public void LoginWithoutPassword()
    {
        var standartUserName = "standard_user";
        var expectedErrorText = "Epic sadface: Password is required";

        Driver.Navigate().GoToUrl(Url);
        var userNameField = Driver.FindElement(By.XPath(userNameXpathLocator));
        var loginButton = Driver.FindElement(By.CssSelector(loginButtonCssLocator));

        userNameField.SendKeys(standartUserName);
        loginButton.Click();

        var actualErrorText = Driver.FindElement(By.TagName("h3")).Text;

        Assert.That(actualErrorText, Is.EqualTo(expectedErrorText));
    }

    [Test]
    public void LoginWithoutUsernameAndPassword()
    {
        var expectedErrorText = "Epic sadface: Username is required";

        Driver.Navigate().GoToUrl(Url);
        var loginButton = Driver.FindElement(By.CssSelector(loginButtonCssLocator));

        loginButton.Click();

        var actualErrorText = Driver.FindElement(By.TagName("h3")).Text;

        Assert.That(actualErrorText, Is.EqualTo(expectedErrorText));
    }
}