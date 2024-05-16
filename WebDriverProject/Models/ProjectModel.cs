using System.Text.Json.Serialization;

namespace WebDriverProject.Models;

public class ProjectModel
{
    public string Name { get; set; }
    public string Announcement { get; set; }
    public bool? IsShowAnnouncement { get; set; }
    public string ProjectType { get; set; }
    public bool? IsEnableTestCase { get; set; }
    [JsonPropertyName("name")] public string FirstPersoneName { get; set; }
    [JsonPropertyName("last name")] public string SecondName { get; set; }
    [JsonPropertyName("id")] public int Identifier { get; set; }
    [JsonPropertyName("age")] public int Age { get; set; }
}