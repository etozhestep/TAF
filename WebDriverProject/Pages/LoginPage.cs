using OpenQA.Selenium;

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
        Driver = driver;
    }

    protected IWebDriver Driver { get; set; }

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