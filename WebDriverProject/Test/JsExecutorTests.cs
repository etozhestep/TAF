using AngleSharp.Html;
using OpenQA.Selenium;
using WebDriverProject.Utils;

namespace WebDriverProject.Test;

public class JsExecutorTests : BaseTest
{
    [SetUp]
    public void OpenSite()
    {
        Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().HerokuappUrl + "checkboxes");
    }


    [Test]
    public void ClickCheckboxWithJs()
    {
        var javaScriptExecutor = (IJavaScriptExecutor)Driver;
        var checkboxes = Driver.FindElements(By.CssSelector("[type='checkbox']"));
        javaScriptExecutor.ExecuteScript("arguments[0].click();", checkboxes[0]);

        javaScriptExecutor.ExecuteScript("arguments[0].click();", checkboxes[0]);
    }

    [Test]
    public void ScrollToJs()
    {
        Driver.Navigate().GoToUrl("https://teachmeskills.by/");
        var javaScriptExecutor = (IJavaScriptExecutor)Driver;
        var frontendLink =
            Driver.FindElements(By.XPath("(//a[@href='/kursy/frontend-html-css-javascript-online'])[1]"));
        javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", frontendLink);
    }
}