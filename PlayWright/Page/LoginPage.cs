using Microsoft.Playwright;
using WebDriverProject.Utils;

namespace PlayWright.Page;

public class LoginPage : BasePage
{
    private string userNameField = "xpath=//input[@data-test='username']";
    private string passwordField = "css=[placeholder='Password']";
    private string loginButton = "css=.submit-button.btn_action";

    public LoginPage(IPage page) : base(page)
    {
    }

    public override async Task NavigateAsync()
    {
        await Page.GotoAsync(Configurator.ReadConfiguration().SauceDemoUrl);
    }

    public async Task<ProductsPage> LoginAsync(string username, string password)
    {
        await Page.FillAsync(userNameField, username);
        await Page.FillAsync(passwordField, password);
        await Page.ClickAsync(loginButton);
        return new ProductsPage(Page);
    }
}