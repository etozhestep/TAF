using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WebDriverProject.Models;

public class AddProjectModel
{
    [JsonPropertyName("name")]public string ProjectName { get; set; }
    [JsonPropertyName("title")] public string ProjectTitle { get; set; }
}