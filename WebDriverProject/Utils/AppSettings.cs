using Newtonsoft.Json;

namespace WebDriverProject.Utils;

public class AppSettings
{
    public string? BrowserType { get; set; }
    public double TimeOut { get; set; }
    public string SauceDemoUrl { get; set; }
    public string UserNameSauceDemo { get; set; }
    public string PasswordSauceDemo { get; set; }
    public string ReqresUrl { get; set; }
    public string TestRailBaseUrl { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}