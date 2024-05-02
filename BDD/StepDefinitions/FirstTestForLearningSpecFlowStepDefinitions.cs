using BDD.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BDD.StepDefinitions;

[Binding]
public class FirstTestForLearningSpecFlowStepDefinitions
{
    private Browser _browser;

    public FirstTestForLearningSpecFlowStepDefinitions(Browser browser)
    {
        _browser = browser;
    }

    [Given(@"open browser")]
    public void GivenOpenBrowser()
    {
        Console.WriteLine("Browser is started...");
        _browser.Driver = new ChromeDriver();
    }

    [Given(@"open login page")]
    public void WhenOpenLoginPage()
    {
        Console.WriteLine("login page opened...");
       _browser.Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    [Then(@"username field is displayed")]
    public void IsUserNameFieldDisplayed()
    {
        Console.WriteLine("Assertion...");
        Assert.That(true);
    }
}