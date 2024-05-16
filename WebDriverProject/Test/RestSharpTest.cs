using System.Net;
using NLog;
using RestSharp;
using WebDriverProject.Utils;

namespace WebDriverProject.Test;

public class RestSharpTest
{
    private Logger _logger = LogManager.GetCurrentClassLogger();

    [Test]
    public void SimpleGetTest()
    {
        const string endPoint = "/api/users/2";

        //Create client
        RestClient client = new RestClient(Configurator.ReadConfiguration().ReqresUrl);

        //Create request
        RestRequest request = new RestRequest(endPoint);
        //request.AddHeader("Barrer", "");

        //Get response
        RestResponse response = client.ExecuteGet(request);

        _logger.Info(response.Content);

        Assert.That(response.StatusCode == HttpStatusCode.OK);
    }

    [Test]
    public void SimplePostTest()
    {
        const string endPoint = "/api/users";

        //Create client
        RestClient client = new RestClient(Configurator.ReadConfiguration().ReqresUrl);

        //Create request
        RestRequest request = new RestRequest(endPoint);
        request.AddJsonBody("{\"name\": \"morpheus\",\"job\": \"leader\"}");

        //Get response
        RestResponse response = client.ExecutePost(request);

        _logger.Info(response.Content);

        Assert.That(response.StatusCode == HttpStatusCode.Created);
    }
}