using System.Text.Json;
using RestSharp;
using WebDriverProject.Models;
using WebDriverProject.Utils;

namespace WebDriverProject.Services;

public class ApiSteps
{
    public int CreateProjectAndReturnId(ProjectModel expectedProject)
    {
        const string endPoint = "/index.php?/api/v2/add_project";

        var apiServices = new ApiServices();
        var restOption = apiServices.CreateOptions(Configurator.ReadConfiguration().Email,
            Configurator.ReadConfiguration().Password);
        var client = new RestClient(restOption);
        var response = apiServices.CreatePostRequest(endPoint, client, JsonSerializer.Serialize(expectedProject));
        var actualProject = JsonSerializer.Deserialize<ProjectModel>(response.Content);
        return actualProject.Id;
    }
}