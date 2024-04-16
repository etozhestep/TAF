using System.Reflection;
using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WebDriverProject.Core;
using WebDriverProject.Pages;
using WebDriverProject.Utils;

namespace WebDriverProject.Test;

[TestFixture]
[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureNUnit]
public class BaseTest
{
    [OneTimeSetUp]
    [AllureBefore("Clean up allure-results directory")]
    public static void GlobalSetUp()
    {
        AllureLifecycle.Instance.CleanupResultDirectory();
    }

    [SetUp]
    [AllureBefore("Set up driver")]
    public void Setup()
    {
        Driver = new Browser().Driver;
        LoginPage = new LoginPage(Driver);
        ProductsPage = new ProductsPage(Driver);
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.ReadConfiguration().TimeOut));
        Actions = new Actions(Driver);
        Js = (IJavaScriptExecutor)Driver;
    }

    [TearDown]
    [AllureAfter("Driver quite")]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            var screenshotByte = screenshot.AsByteArray;
            AllureApi.AddAttachment("screenshot", "image/png", screenshotByte);
        }

        try
        {
            var loggerPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "fileLogger.txt");
            AllureApi.AddAttachment("logger", "text/html", loggerPath);
        }
        catch
        {
            Console.WriteLine("couldnt load file");
        }
        Driver.Dispose();

    }


    public IWebDriver Driver { get; set; }
    public LoginPage LoginPage { get; set; }
    public ProductsPage ProductsPage { get; set; }
    public WaitsHelper? WaitsHelper { get; set; }
    public Actions Actions { get; set; }
    public IJavaScriptExecutor Js { get; set; }
}