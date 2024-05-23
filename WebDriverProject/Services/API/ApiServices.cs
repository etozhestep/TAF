using OpenQA.Selenium.DevTools.V121.Debugger;
using RestSharp;
using System.Net;
using RestSharp.Authenticators;
using WebDriverProject.Utils;
using WebDriverProject.Models;

namespace WebDriverProject.Services.API;

public class ApiServices
{
    public RestClient SetUpClient(RestClientOptions options)
    {
        return new RestClient(options);
    }

    public RestResponse CreateGetRequest(string endPoint, RestClient client)
    {
        return client.ExecuteGet(new RestRequest(endPoint));
    }

    public RestResponse CreatePostRequest(string endPoint, RestClient client, string body)
    {
        return client.ExecutePost(new RestRequest(endPoint).AddJsonBody(body));
    }

    public RestClientOptions CreateOptions(string email, string password)
    {
        return new RestClientOptions(Configurator.ReadConfiguration().TestRailBaseUrl)
        {
            Authenticator = new HttpBasicAuthenticator(email, password)
        };
    }
}