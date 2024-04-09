using OpenQA.Selenium;
using WebDriverProject.Utils;

namespace WebDriverProject.Test;

public class IFrameTests : BaseTest
{

    [SetUp]
    public void OpenHerokuApp()
    {
        Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().HerokuappUrl+ "iframe");
    }


    [Test]
    public void GetTextFromFrameTest()
    {
        //Driver.SwitchTo().Frame("mce_0_ifr");
        //Driver.SwitchTo().Frame(0);
        Driver.SwitchTo().Frame(Driver.FindElement(By.Id("mce_0_ifr")));

        var textField = Driver.FindElement(By.XPath("//body[@id='tinymce']//p"));

        Assert.That(textField.Text,Is.EqualTo("Your content goes here."));
    }

    [Test]
    public void ExitFromFrameTest()
    {
        Driver.SwitchTo().Frame(Driver.FindElement(By.Id("mce_0_ifr")));

        Driver.FindElement(By.XPath("//body[@id='tinymce']//p"));

        Driver.SwitchTo().DefaultContent();
        Driver.FindElement(By.XPath("//*[.='Elemental Selenium']")).Click();
       
    }
}