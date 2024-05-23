using OpenQA.Selenium;
using WebDriverProject.BaseEntites;

namespace WebDriverProject.Pages;

public class LoginPage : BasePage
{
    private static readonly By UserNameFieldBy = By.XPath("//input[@data-test='username']");
    private static readonly By PasswordFieldBy = By.CssSelector("[placeholder='Password']");
    private static readonly By LoginButtonBy = By.CssSelector(".submit-button.btn_action");
    private static readonly By ErrorTitleBy = By.TagName("h3");
    private readonly string _endPoint = "";


    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    public override string GetEndpoint()
    {
        return _endPoint;
    }

    public IWebElement UserNameField()
    {
        return Driver.FindElement(UserNameFieldBy);
    }

    public IWebElement PasswordField()
    {
        return Driver.FindElement(PasswordFieldBy);
    }

    public IWebElement LoginButton()
    {
        return Driver.FindElement(LoginButtonBy);
    }

    public IWebElement ErrorTitle()
    {
        return Driver.FindElement(ErrorTitleBy);
    }

    protected override bool EvaluateLoadedStatus()
    {
        return LoginButton().Displayed;
    }
}