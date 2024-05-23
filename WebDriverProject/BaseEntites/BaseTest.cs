using OpenQA.Selenium;
using System.Reflection;
using DotNetEnv;
using WebDriverProject.Core;
using WebDriverProject.Steps;

namespace WebDriverProject.BaseEntites;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class BaseTest
{
    public IWebDriver Driver { get; set; }
    public UserStep UserStep { get; set; }
    public NavigationStep NavigationStep { get; set; }

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
        UserStep = new UserStep(Driver);
        NavigationStep = new NavigationStep(Driver);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Dispose();
    }
}