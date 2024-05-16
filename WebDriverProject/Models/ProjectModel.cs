using System.Text.Json.Serialization;

namespace WebDriverProject.Models;

public class ProjectModel
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("announcement")] public string Announcement { get; set; }

    [JsonPropertyName("show_announcement")]
    public bool? IsShowAnnouncement { get; set; }

    [JsonPropertyName("suite_mode")] public int ProjectType { get; set; }
    public bool? IsEnableTestCase { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Announcement)}: {Announcement}, " +
               $"{nameof(IsShowAnnouncement)}: {IsShowAnnouncement}, {nameof(ProjectType)}: {ProjectType}";
    }

    public bool Equals(ProjectModel projectModel)
    {
        return Name == projectModel.Name && Announcement == projectModel.Announcement &&
               IsShowAnnouncement == projectModel.IsShowAnnouncement &&
               ProjectType == projectModel.ProjectType;
    }
}