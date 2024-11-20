using System.Reflection;
using Allure.Net.Commons;
using Allure.NUnit;
using NLog;
using OpenQA.Selenium;
using WebDriverProject.Core;
using WebDriverProject.Pages;

namespace WebDriverProject.Test;

[Parallelizable(ParallelScope.Fixtures)]
[AllureNUnit]
public class BaseTest
{
    protected Logger logger = LogManager.GetCurrentClassLogger();
    public IWebDriver Driver { get; set; }
    public LoginPage LoginPage { get; set; }
    public ProductsPage ProductsPage { get; set; }

    [OneTimeSetUp]
    public void GlobalSetup()
    {
        new NLogConfig().Config();
        AllureLifecycle.Instance.CleanupResultDirectory();
    }

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;
        LoginPage = new LoginPage(Driver);
        ProductsPage = new ProductsPage(Driver);
    }

    [TearDown]
    public void TearDown()
    {
        var errorLogfilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "ErrorLogFile.txt");
        var infoLogfilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "InfoLogFile.txt");

        AllureApi.AddAttachment("errorLog", "text/html", errorLogfilePath);
        AllureApi.AddAttachment("infoLog", "text/html", infoLogfilePath);

        Driver.Dispose();
    }
}