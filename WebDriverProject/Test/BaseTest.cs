using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using WebDriverProject.Core;
using WebDriverProject.Steps;

namespace WebDriverProject.Test;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureNUnit]
public class BaseTest
{
    public IWebDriver Driver { get; set; }
    public UserStep UserStep { get; set; }
    public NavigationStep NavigationStep { get; set; }

    [SetUp]
    [AllureBefore("Set up driver")]
    public void Setup()
    {
        Driver = new Browser().Driver;
        UserStep = new UserStep(Driver);
        NavigationStep = new NavigationStep(Driver);
    }

    [TearDown]
    [AllureAfter("Driver quite")]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var screenshotByte = ((ITakesScreenshot)Driver).GetScreenshot().AsByteArray;
            AllureApi.AddAttachment("screenshot", "image/png", screenshotByte);
        }


        Driver.Dispose();
    }
}