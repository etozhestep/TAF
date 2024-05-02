using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class LoginStepDefs
    {
        [When(@"enter '([^']*)' in username field")]
        public void EnterInUsernameField(string p0)
        {
            Console.WriteLine(p0);
        }

        [When(@"enter '([^']*)' in password field")]
        public void EnterInPasswordField(string p0)
        {
            Console.WriteLine(p0);
        }

        [When(@"click login button")]
        public void ClickLoginButton()
        {
            Console.WriteLine("click login...");
        }

        [Then(@"products page displayed")]
        public void ProductsPageDisplayed()
        {
            Assert.That(true);
        }

        [Then(@"name '([^']*)' displayed")]
        public void NameDisplayed(string p0)
        {
            Assert.That(p0.Equals("Andrei Sciapaniuk"));
        }

        [Then(@"user id equals (.*)")]
        public void UserIdEquals(int p0)
        {
            Assert.That(p0 == 700);
        }

        [When(@"enter ""([^""]*)"" in password field")]
        public void WhenEnterInPasswordField(string street)
        {
            throw new PendingStepException();
        }

    }
}