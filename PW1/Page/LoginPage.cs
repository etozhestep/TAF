using Microsoft.Playwright;
using WebDriverProject.Utils;

namespace PW1.Page;

public class LoginPage : BasePage
{
    public LoginPage(IPage page) : base(page)
    {
    }

    public override async Task NavigateAsync()
    {
        await Page.GotoAsync(Configurator.ReadConfiguration().SauceDemoUrl);
    }

    public async Task<ProductsPage> LoginAsync(string usernname, string password)
    {
        await Page.FillAsync("xpath=//input[@data-test='username']", usernname);
        await Page.FillAsync("css=[placeholder='Password']", password);
        await Page.ClickAsync("css=.submit-button.btn_action");
        return new ProductsPage(Page);
    }
}