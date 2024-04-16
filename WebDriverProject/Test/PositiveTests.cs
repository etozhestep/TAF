using Allure.Net.Commons;
using OpenQA.Selenium;
using WebDriverProject.Pages;
using WebDriverProject.Utils;

namespace WebDriverProject.Test;

[TestFixture]
public class PositiveTests : BaseTest
{
    private string attributeXpathLocator = "//div[5]";
    private string redItemXpathLocator = "//*[text()='Test.allTheThings() T-Shirt (Red)']//parent::div";
    private string partialcontainsTextXpath = "//*[contains(text(),'Swag')]";
    private string ancestorXpath = "//div[@id='shopping_cart_container']/ancestor::div[@data-test='primary-header']";
    private string childXpath = "//div[@id='menu_button_container']/child::div/child::*/child::*";
    private string descendantXpath = "//*[@class ='product_sort_container']/descendant::*[4]";
    private string byClassLocator = ".title";
    private string byIdLocator = "#item_1_title_link";
    private string byAttributeValue = "[src='/static/media/bolt-shirt-1200x1500.c2599ac5.jpg']";
    private string idAddToCartRedTShirtXpath = "//*[@id = 'add-to-cart-sauce-labs-backpack']";
    private string shoppingIconXpath = "//*[@class ='shopping_cart_link']";
    private string shoppingBadgeXpath = "//*[@class ='shopping_cart_badge']";
    private string cartItemXpath = "//*[@class ='cart_item']";

    [SetUp]
    public void Setup()
    {
        Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl);
    }

    [Test]
    public void PositiveLogin()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        Assert.That(ProductsPage.ProductsTitle().Displayed, Is.True);
    }

    [Test]
    public void ProductTitle()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        Assert.That(ProductsPage.ProductsTitle().Displayed, Is.True);
    }

    [Test]
    public void XPAttribute()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        var attributeXpath = Driver.FindElement(By.XPath(attributeXpathLocator));
        attributeXpath.Click();
        Assert.That(attributeXpath.Displayed, Is.True);
    }

    [Test]
    public void RedInventoryItem()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        var inventoryItemParent = Driver.FindElement(By.XPath(redItemXpathLocator));
        Assert.That(inventoryItemParent.Displayed, Is.True);
    }

    [Test]
    public void SwagTitle()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        var partialcontainsText = Driver.FindElement(By.XPath(partialcontainsTextXpath));
        Assert.That(partialcontainsText.Enabled, Is.True);
    }

    [Test]
    public void AncestorHeader()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        var ancestorFinder = Driver.FindElement(By.XPath(ancestorXpath));
        Assert.That(ancestorFinder.Enabled, Is.True);
    }

    [Test]
    public void MenuBurgerButton()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        var burgButton = Driver.FindElement(By.XPath(childXpath));
        Assert.That(burgButton.Enabled, Is.True);
    }

    [Test]
    public void SortContainer()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        var valueSort = Driver.FindElement(By.XPath(descendantXpath));
        Assert.That(valueSort.Enabled, Is.True);
    }

    [Test]
    public void ByClass()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        var productTitleCss = Driver.FindElement(By.CssSelector(byClassLocator));
        Assert.That(productTitleCss.Enabled, Is.True);
    }

    [Test]
    public void ById()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        var productTitleCss = Driver.FindElement(By.CssSelector(byIdLocator));
        Assert.That(productTitleCss.Enabled, Is.True);
    }

    [Test]
    public void ImageValue()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        var productTitleCss = Driver.FindElement(By.CssSelector(byAttributeValue));
        Assert.That(productTitleCss.Enabled, Is.True);
    }

    [Test]
    public void ChoiceBtnEnable()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        var sauceLabsBackpackAddBtn = Driver.FindElement(By.XPath(idAddToCartRedTShirtXpath));
        Assert.That(sauceLabsBackpackAddBtn.Enabled, Is.True);
    }

    [Test]
    public void ShoppingLinkDisplayed()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        var shopIcn = Driver.FindElement(By.XPath(shoppingIconXpath));
        ;
        Assert.That(shopIcn.Enabled, Is.True);
    }

    [Test]
    public void ShoppingBadgeDisplayedWithOneAddedItem()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        var sauceLabsBackpackAddBtn = Driver.FindElement(By.XPath(idAddToCartRedTShirtXpath));
        sauceLabsBackpackAddBtn.Click();
        var shoppingBage = Driver.FindElement(By.XPath(shoppingBadgeXpath));
        Assert.That(shoppingBage.Displayed, Is.True);
    }

    [Test]
    public void WalkToCheckoutWithItem()
    {
        LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
        var sauceLabsBackpackAddBtn = Driver.FindElement(By.XPath(idAddToCartRedTShirtXpath));
        sauceLabsBackpackAddBtn.Click();
        var shopIcn = Driver.FindElement(By.XPath(shoppingIconXpath));
        ;
        shopIcn.Click();
        var cartItem = Driver.FindElement(By.XPath(cartItemXpath));
        Assert.That(cartItem.Displayed, Is.True);
    }
}