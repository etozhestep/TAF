using OpenQA.Selenium;
using WebDriverProject.Core;
using WebDriverProject.Pages;
using WebDriverProject.Steps;

namespace WebDriverProject.Test;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class BaseTest
{
    public IWebDriver Driver { get; set; }
    public UserStep UserStep { get; set; }
    public NavigationStep NavigationStep { get; set; }

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;
        UserStep = new UserStep(Driver);
        NavigationStep = new NavigationStep(Driver);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Dispose();
    }
}