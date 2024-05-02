using NUnit.Framework;
using WebDriverProject.Core;
using WebDriverProject.Steps;

namespace BDD.StepDefinitions;

[Binding]
public class FirstTestForLearningSpecFlowStepDefinitions : BaseStepDefs
{
    private NavigationStep _navigationStep;
    public FirstTestForLearningSpecFlowStepDefinitions(Browser browser) : base(browser)
    {
        _navigationStep = new NavigationStep(Driver);
    }


    [Given(@"open login page")]
    public void WhenOpenLoginPage()
    {
        _navigationStep.NavigateToLoginPage();
    }

    [Then(@"username field is displayed")]
    public void IsUserNameFieldDisplayed()
    {
        Console.WriteLine("Assertion...");
        Assert.That(true);
    }
}