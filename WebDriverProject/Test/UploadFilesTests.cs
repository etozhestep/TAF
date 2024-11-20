using System.Reflection;
using OpenQA.Selenium;

namespace WebDriverProject.Test;

public class UploadFilesTests : BaseTest
{
    [SetUp]
    public void Setup()
    {
        Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");
    }

    [Test]
    public void UploadFile()
    {
        var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources",
            "test1.txt");
        Driver.FindElement(By.Id("file-upload")).SendKeys(filePath);
        Driver.FindElement(By.Id("file-submit")).Click();

        Assert.Multiple(() =>
        {
            Assert.That(Driver.FindElement(By.TagName("h3")).Text, Is.EqualTo("File Uploaded!"));
            Assert.That(Driver.FindElement(By.Id("uploaded-files")).Text, Is.EqualTo(Path.GetFileName(filePath)));
        });
    }
}