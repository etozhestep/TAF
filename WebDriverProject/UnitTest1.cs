using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebDriverProject;

[TestFixture]
public class Tests
{
    public IWebDriver Driver { get; set; }

    [SetUp]
    public void OneTimeSetUp()
    {
        Driver = new ChromeDriver();

        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }


    [Test]
    public void TestCheckBoxes()
    {
        var url = "https://the-internet.herokuapp.com/checkboxes";

        Driver.Navigate().GoToUrl(url);
        var checkbox = Driver.FindElement(By.CssSelector("[type='checkbox']"));
        checkbox.Click();
        var isChecked = checkbox.Selected;

        //ClassicAssert.NotNull(isChecked);

        Assert.Multiple(() =>
            {
                Assert.That(isChecked);
                Assert.That(isChecked);
            }
        );
    }

    [Test]
    public void TestMultiple1()
    {
        Assert.Multiple(() =>
            {
                Assert.That(1, Is.EqualTo(2));
                Assert.That(2, Is.EqualTo(2));
                Assert.That(3, Is.EqualTo(2));
            }
        );
    }

    [Test]
    public void TestMultiple2()
    {
        Assert.That(1, Is.EqualTo(2));
        Assert.That(2, Is.EqualTo(2));
    }

    [Test]
    public void TestFields()
    {
        Driver.Navigate().GoToUrl("https://formy-project.herokuapp.com/autocomplete");

        var addressField = Driver.FindElement(By.Id("autocomplete"));

        addressField.SendKeys("Tbilisi");

        addressField.Click();
        addressField.SendKeys("Tbilisi");

        addressField.Click();
        addressField.Clear();
        addressField.SendKeys("Tbilisi");
    }

    [Test]
    public void TestDropDown()
    {
        Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");

        var selectWebElement = Driver.FindElement(By.Id("dropdown"));
        var select = new SelectElement(selectWebElement);
        select.SelectByText("Option 2");
        ClassicAssert.IsTrue(select.SelectedOption.GetAttribute("value").Equals("2"));
    }

    [Test]
    public void TestDropDown1()
    {
        Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");

        var dropdown = Driver.FindElement(By.Id("dropdown"));
        var options = dropdown.FindElements(By.TagName("option1"));

        ClassicAssert.IsNotNull(options);
    }

    [TearDown]
    public void OneTimeTearDown()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}