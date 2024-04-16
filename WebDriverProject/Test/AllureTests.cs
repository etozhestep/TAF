using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace WebDriverProject.Test;

[AllureParentSuite("Allure tests")]
public class AllureTests : BaseTest
{
    [Test]
    [AllureSeverity(SeverityLevel.critical)]
    public void SerenityTest()
    {
        Assert.That(true);
    }

    [Test]
    public void SerenityApiTest()
    {
        AllureApi.SetSeverity(SeverityLevel.critical);
        Assert.That(true);
    }

    [Test(Description = "Description")]
    [AllureDescription("Test to show description")]
    public void DescriptionTest()
    {
        Assert.That(true);
    }

    [Test]
    public void DescriptionApiTest()
    {
        AllureApi.SetDescription("Description");
        Assert.That(true);
    }

    [Test]
    [AllureOwner("ASciapaniuk")]
    public void OwnerTest()
    {
        Assert.That(true);
    }

    [Test]
    [AllureIssue("BUG-06")]
    [AllureTms("TMS-066")]
    [AllureLink("WebSite", "https://google.com")]
    public void IssueTest()
    {
        Assert.That(true);
    }

    [Test]
    [AllureEpic("Web interface")]
    [AllureFeature("Essential feature")]
    [AllureStory("Frontend fix")]
    public void Epic1Test()
    {
        Assert.That(true);
    }

    [Test]
    [AllureEpic("Web interface")]
    [AllureFeature("Ui feature")]
    [AllureStory("Frontend fix")]
    public void Epic2Test()
    {
        Assert.That(true);
    }

    [Test]
    [AllureSuite("Suite test")]
    [AllureSubSuite("Sub suite")]
    public void SuiteTest()
    {
        Assert.That(true);
    }

    [Test]
    public void ScreenTest()
    {
        Driver.Navigate().GoToUrl("https://google.com");
        Assert.That(false);
    }
}