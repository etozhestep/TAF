using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverProject.Utils;

namespace WebDriverProject.Test;

public class WaitersTests : BaseTest
{
    [SetUp]
    public void OpenSite()
    {
        Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().HerokuappUrl + "dynamic_loading/1");
    }

    [Test]
    public void WaitForHelloWorld()
    {
        var button = Driver.FindElement(By.XPath("//*[.='Start']"));
        button.Click();

        Assert.That(button.Displayed, Is.False);

        var loading = Driver.FindElement(By.Id("loading"));
        Assert.That(loading.Displayed, Is.True);
        Assert.That(loading.Displayed, Is.False);

        Assert.That(Driver.FindElement(By.Id("finish")).Displayed);
    }

    [Test]
    public void ExplicitWaitForHelloWorld()
    {
        var button = Driver.FindElement(By.XPath("//*[.='Start']"));
        button.Click();

        WaitsHelper.WaitForElementInvisible(button);
        Assert.That(button.Displayed, Is.False);


        var loading = WaitsHelper.WaitForVisibility(By.Id("loading"));
        Assert.That(loading.Displayed, Is.True);

        WaitsHelper.WaitForElementInvisible(loading);
        Assert.That(loading.Displayed, Is.False);

        Assert.That(Driver.FindElement(By.Id("finish")).Displayed);
    }
}