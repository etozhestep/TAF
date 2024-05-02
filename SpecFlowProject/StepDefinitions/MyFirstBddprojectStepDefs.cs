using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class MyFirstBddprojectStepDefs
    {
        [Given(@"open browser")]
        public void OpenBrowser()
        {
            Console.WriteLine("Open browser...");
        }

        [Given(@"open login page")]
        [When(@"open login page")]
        public void OpenLoginPage()
        {
            Console.WriteLine("Open Login Page...");
        }

        [Then("login button displayed")]
        public void IsLoginButtonDisplayed()
        {
            Console.WriteLine("Assert is login button displayed...");
            Assert.IsTrue(true);
        }

        [Given(@"cart button not displayed")]
        public void IsCartButtonDisplayed()
        {
            Assert.IsFalse(false);
        }

    }
}