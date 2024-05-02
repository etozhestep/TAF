using WebDriverProject.Core;

namespace BDD.Hooks;

[Binding]
public class Hook
{
    private readonly Browser _browser;

    public Hook(Browser browser)
    {
        _browser = browser;
    }

    [AfterScenario]
    public void CloseDriver()
    {
        _browser.Driver.Quit();
    }

}