using OpenQA.Selenium;
using WebDriverProject.Element;

namespace WebDriverProject.Test;

public class Wrappers : BaseTest
{
    [Test]
    public void RadioButtonSelectByIndex()
    {
        Driver.Navigate().GoToUrl("https://qac0402.testrail.io/");

        Driver.FindElement(By.CssSelector("[data-testid='loginIdName']")).SendKeys("workandreystep@gmail.com");
        Driver.FindElement(By.CssSelector("[data-testid='loginPasswordFormDialog']")).SendKeys("tmsQAC0401?");
        Driver.FindElement(By.CssSelector("[data-testid='loginButtonPrimary']")).Click();


        Driver.FindElement(By.CssSelector("[data-testid='sidebarProjectsAddButton']")).Click();

        var radioButton = new RadioButton(Driver, By.Name("suite_mode"));
        radioButton.SelectByIndex(1);
        radioButton.SelectByValue("3");
        radioButton.SelectByText("Use a single repository for all cases (recommended)"); 
    }
}