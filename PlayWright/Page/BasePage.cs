using Microsoft.Playwright;

namespace PlayWright.Page;

public abstract class BasePage
{
    protected readonly IPage Page;

    protected BasePage(IPage page)
    {
        Page = page;
    }

    public abstract Task NavigateAsync();
}