using OpenQA.Selenium;
using WebDriverProject.BaseEntites;
using WebDriverProject.Models;
using WebDriverProject.Pages;

namespace WebDriverProject.Steps;

public class UserStep : BaseStep
{

    public UserStep(IWebDriver driver) : base(driver)
    {
    }

    public ProductsPage SuccessfulLogin(UserModel userModel)
    {
        Login(userModel);
        return new ProductsPage(_driver);
    }

    public LoginPage UnsuccesfulLoginWithoutPassword(UserModel userModel)
    {
        Login(userModel);
        return LoginPage;
    }

    public LoginPage UnsuccesfulLoginWithoutUserNameAndPassword()
    {
        Login();
        return LoginPage;
    }

    private void Login(UserModel userModel = null)
    {
        if (userModel.UserName == null)
            LoginPage.UserNameField().SendKeys("");
        else
            LoginPage.UserNameField().SendKeys(userModel.UserName);


        if (userModel.Password == null)
            LoginPage.PasswordField().SendKeys("");
        else
            LoginPage.PasswordField().SendKeys(userModel.Password);

        LoginPage.LoginButton().Click();
    }
}