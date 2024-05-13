using OpenQA.Selenium;

namespace WebDriverProject.Test;

public class DownloadTests : BaseTest
{
    [SetUp]
    public void OpenSite()
    {
        Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/download");
    }

    [Test]
    public void DownloadFirstItem()
    {
        Driver.FindElement(By.XPath("//*[.='test1.txt']")).Click();
    }

}