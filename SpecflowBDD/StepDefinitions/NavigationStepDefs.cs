using System;
using TechTalk.SpecFlow;
using WebDriverProject.Pages;
using WebDriverProject.Steps;

namespace SpecflowBDD.StepDefinitions
{
    [Binding]
    public class NavigationStepDefs
    {
        private ProductsPage _productsPage;
        private NavigationStep _navigationStep;

        [When(@"Click cart button")]
        public void ClickCartButton()
        {
            _productsPage = new ProductsPage(BaseStepDefs.Driver);
            _productsPage.CartIcon().Click();
        }

        [When(@"Open Products Page")]
        public void OpenProductsPage()
        {
            _navigationStep = new NavigationStep(BaseStepDefs.Driver);
            _navigationStep.NavigateToProductsPage();
        }
    }
}