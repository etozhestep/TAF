﻿using OpenQA.Selenium;
using WebDriverProject.Element;
using WebDriverProject.Utils;

namespace WebDriverProject.Pages;

public class LoginPage : BasePage
{
    private static readonly By UserNameFieldBy = By.XPath("//input[@data-test='username']");
    private static readonly By PasswordFieldBy = By.CssSelector("[placeholder='Password']");
    private static readonly By LoginButtonBy = By.CssSelector(".submit-button.btn_action");
    private static readonly By ErrorTitleBy = By.TagName("h3");
    private string _endPoint = "";


    public LoginPage(IWebDriver driver) : base(driver)
    {
        Driver = driver;
    }

    protected IWebDriver Driver { get; set; }

    public override string GetEndpoint()
    {
        return _endPoint;
    }

    public UiElement UserNameField() => new UiElement(Driver, UserNameFieldBy);
    public IWebElement PasswordField() => Driver.FindElement(PasswordFieldBy);
    public IWebElement LoginButton() => Driver.FindElement(LoginButtonBy);
    public IWebElement ErrorTitle() => Driver.FindElement(ErrorTitleBy);

    public ProductsPage SuccessfulLogin(string userName, string password)
    {
        UserNameField().SendKeys(userName);
        PasswordField().SendKeys(password);
        LoginButton().Click();
        return new ProductsPage(Driver);
    }

    public void Login(string userName = "", string password = "")
    {
        UserNameField().SendKeys(userName);
        PasswordField().SendKeys(password);
        LoginButton().Click();
    }
}