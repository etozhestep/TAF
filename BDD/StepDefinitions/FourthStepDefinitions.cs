using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BDD.StepDefinitions
{
    [Binding]
    public class FourthStepDefinitions
    {
        [When(@"user '([^']*)' with password '([^']*)' logged in")]
        public void WhenUserWithPasswordLoggedIn(string p0, string p1)
        {
            Console.WriteLine($"user with {p0} and pass {p1} logged in");
        }

        [Then(@"the project id equals to (.*)")]
        public void ThenTheProjectIdEqualsTo(int p0)
        {
            Assert.That(p0 == 20);
        }

        [Then(@"user name is '([^']*)'")]
        public void ThenUserNameIs(string p0)
        {
            Assert.That(p0.Equals("Andrei Sciapaniuk"));
        }
    }
}