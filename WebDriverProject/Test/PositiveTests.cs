using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverProject.Test;

[TestFixture]
public class PositiveTests : BaseTest
{
    private const string Url = "https://www.saucedemo.com/";
    private string userNameXpathLocator = "//input[@data-test='username']";
    private string passwordCssLocator = "[placeholder='Password']";
    private string loginButtonCssLocator = ".submit-button.btn_action";
    private string productsTitleXpathLocator = "//*[.='Products']";


    [Test]
    public void PositiveLogin()
    {
        var standartUserName = "standard_user";
        var password = "secret_sauce";
        var expectedUrl = "https://www.saucedemo.com/inventory.html";

        Driver.Navigate().GoToUrl(Url);
        var userNameField = Driver.FindElement(By.XPath(userNameXpathLocator));
        var passwordField = Driver.FindElement(By.CssSelector(passwordCssLocator));
        var loginButton = Driver.FindElement(By.CssSelector(loginButtonCssLocator));

        userNameField.SendKeys(standartUserName);
        passwordField.SendKeys(password);
        loginButton.Click();

        var productTitle = Driver.FindElement(By.XPath(productsTitleXpathLocator));

        Assert.Multiple(() =>
            {
                Assert.That(expectedUrl, Is.EqualTo(Driver.Url));
                Assert.That(productTitle.Displayed, Is.True);
            }
        );
    }
}