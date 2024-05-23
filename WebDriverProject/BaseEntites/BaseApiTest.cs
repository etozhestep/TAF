using RestSharp;
using RestSharp.Authenticators;
using WebDriverProject.Services.API;
using WebDriverProject.Utils;

namespace WebDriverProject.BaseEntites;

public class BaseApiTest
{
    protected ApiServices ApiServices { get; private set; }
    protected ApiSteps ApiSteps { get; private set; }
    protected RestClient Client { get; private set; }
    private RestClientOptions _restOption;

    [SetUp]
    public void SetupApi()
    {
        ApiServices = new ApiServices();
        ApiSteps = new ApiSteps();

        _restOption = ApiServices.CreateOptions(Configurator.ReadConfiguration().Email,
            Configurator.ReadConfiguration().Password);
        Client = ApiServices.SetUpClient(_restOption);
    }

    [TearDown]
    public void TearDownApi()
    {
        Client.Dispose();
    }
}