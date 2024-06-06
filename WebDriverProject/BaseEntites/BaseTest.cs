using OpenQA.Selenium;
using System.Reflection;
using DotNetEnv;
using WebDriverProject.Core;
using WebDriverProject.Steps;
using WebDriverProject.Pages;

namespace WebDriverProject.BaseEntites;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class BaseTest : BaseApiTest
{
    public IWebDriver Driver { get; set; }
    public UserStep UserStep { get; set; }
    public NavigationStep NavigationStep { get; set; }
    protected LoginPage LoginPage;
    protected ProductsPage ProductsPage;


    [OneTimeSetUp]
    public static void SetupEnvVariables()
    {
        var pathToEnvFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            ".env");
        Env.Load(pathToEnvFile);
    }

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;
        //Steps
        UserStep = new UserStep(Driver);
        NavigationStep = new NavigationStep(Driver);
        //Page
        LoginPage = new LoginPage(Driver);
        ProductsPage = new ProductsPage(Driver);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Dispose();
    }
}