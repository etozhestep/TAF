using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using WebDriverProject.Pages;

namespace SpecflowBDD.StepDefinitions
{
    [Binding]
    public class LoginStepDefs
    {
        private LoginPage _loginPage;
        private ProductsPage _productsPage;

        [BeforeScenario]
        public void BeforeScenario()
        {
            BaseStepDefs.Driver = new ChromeDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            BaseStepDefs.Driver.Quit();
        }

        [Given(@"Open Login Page")]
        public void OpenLoginPage()
        {
            _loginPage = new LoginPage(BaseStepDefs.Driver, true);
        }


        [When(@"Enter valid login ""([^""]*)"" and password ""([^""]*)""")]
        public void EnterValidLoginAndPassword(string login = "", string password = "")
        {
            _loginPage = new LoginPage(BaseStepDefs.Driver);
            _loginPage.UserNameField().SendKeys(login);
            _loginPage.PasswordField().SendKeys(password);
        }

        [When(@"Click login button")]
        public void WhenClickLoginButton()
        {
            _loginPage.LoginButton().Click();
        }


        [Then(@"Products title is displayed")]
        public void IsProductsTitleDisplayed()
        {
            _productsPage = new ProductsPage(BaseStepDefs.Driver);
            Assert.That(_productsPage.ProductsTitle().Displayed);
        }

        [Then(@"Error message ""([^""]*)"" displayed")]
        public void ThenErrorMessageDisplayed(string expectedText)
        {
            var actualText = _loginPage.ErrorTitle().Text.Trim();
            Assert.That(actualText.Equals(expectedText));
        }
    }
}