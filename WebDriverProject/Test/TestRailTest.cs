using NLog;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text.Json;
using WebDriverProject.Models;
using WebDriverProject.Services;
using WebDriverProject.Utils;

namespace WebDriverProject.Test;

public class TestRailTest
{
    private Logger _logger = LogManager.GetCurrentClassLogger();

    [Test]
    public void SimpleGetTest()
    {
        const string endPoint = "/index.php?/api/v2/get_user/1";
        var apiServices = new ApiServices();

        var restOption = apiServices.CreateOptions(Configurator.ReadConfiguration().Email,
            Configurator.ReadConfiguration().Password);
        var response = apiServices.CreateGetRequest(endPoint, new RestClient(restOption));

        _logger.Info(response.Content);
        Assert.That(response.StatusCode == HttpStatusCode.OK);
    }

    [Test]
    public void AdvancedGetTest()
    {
        const string endPoint = "/index.php?/api/v2/get_user/{user_id}";
        var restOption = new RestClientOptions(Configurator.ReadConfiguration().TestRailBaseUrl)
        {
            Authenticator = new HttpBasicAuthenticator(
                Configurator.ReadConfiguration().Email,
                Configurator.ReadConfiguration().Password
            )
        };

        var client = new RestClient(restOption);

        var request = new RestRequest(endPoint);
        request.AddUrlSegment("user_id", 1);

        var response = client.ExecuteGet(request);

        _logger.Info(response.Content);
        Assert.That(response.StatusCode == HttpStatusCode.OK);
    }

    [Test]
    public void SimplePostTest()
    {
        const string endPoint = "/index.php?/api/v2/add_project";
        Dictionary<string, object> json = new Dictionary<string, object>();
        json.Add("name", "ASciapaniuk_1");
        json.Add("announcement", "test");
        json.Add("show_announcement", true);
        json.Add("suite_mode", 1);

        var restOption = new RestClientOptions(Configurator.ReadConfiguration().TestRailBaseUrl)
        {
            Authenticator = new HttpBasicAuthenticator(
                Configurator.ReadConfiguration().Email,
                Configurator.ReadConfiguration().Password
            )
        };

        var client = new RestClient(restOption);

        var request = new RestRequest(endPoint)
            .AddJsonBody(JsonSerializer.Serialize(json));

        var response = client.ExecutePost(request);

        _logger.Info(response.Content);

        dynamic responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
        var projectId = responseObject.id;

        _logger.Info($"Project ID is: {projectId}");
    }

    [Test]
    public void AdvancedPostTest()
    {
        const string endPoint = "/index.php?/api/v2/add_project";

        ProjectModel expectedProject = new ProjectModel()
        {
            Name = "ASciapaniuk_",
            Announcement = "test",
            IsShowAnnouncement = true,
            ProjectType = 1
        };

        var apiServices = new ApiServices();
        var restOption = apiServices.CreateOptions(Configurator.ReadConfiguration().Email,
            Configurator.ReadConfiguration().Password);

        var client = new RestClient(restOption);
        var request = new RestRequest(endPoint).AddJsonBody(expectedProject);

        var response = client.ExecutePost<ProjectModel>(request);
        var actualProject = response.Data;

        _logger.Info(actualProject.Id);
        Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode == HttpStatusCode.OK);
                Assert.That(expectedProject.Equals(actualProject));
            }
        );
    }

    [Test]
    public void PostTest()
    {
        var expectedProject = new ProjectModel()
        {
            Name = "ASciapaniuk_5",
            Announcement = "test",
            IsShowAnnouncement = true,
            ProjectType = 1
        };

        var apiSteps = new ApiSteps();
        var actualId = apiSteps.CreateProjectAndReturnId(expectedProject);

        _logger.Info(actualId);
        Assert.That(actualId == 220);
    }
}