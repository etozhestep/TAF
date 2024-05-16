using System.Text.Json;
using System.Text.Json.Nodes;
using WebDriverProject.Models;

namespace WebDriverProject.Test;

public class JsonTest
{
    [Test]
    public void FirstTest()
    {
        var json = new JsonObject1()
        {
            FirstPersoneName = "Test Name",
            SecondName = "Test Last Name",
            Identifier = 76,
            Age = 30
        };

        var jsonAsString = JsonSerializer.Serialize<JsonObject1>(json);
        Console.WriteLine(jsonAsString);
    }

    [Test]
    public void SecondTest()
    {
        var jsonAsString = "{\"Name\":\"Test Name\",\"LastName\":\"Test Last Name\",\"Id\":76,\"Age\":30}";

        JsonObject1 jsonObject = JsonSerializer.Deserialize<JsonObject1>(jsonAsString);

        Console.WriteLine(jsonObject.Age);
        Console.WriteLine(jsonObject.Identifier);
        Console.WriteLine(jsonObject.SecondName);
        Console.WriteLine(jsonObject.FirstPersoneName);
    }

    [Test]
    public void ThirdTest()
    {
        using FileStream fs = new FileStream(@"Resources/testObject1.json", FileMode.Open);
        JsonObject1 jsonObject = JsonSerializer.Deserialize<JsonObject1>(fs);

        Console.WriteLine(jsonObject.Age);
        Console.WriteLine(jsonObject.Identifier);
        Console.WriteLine(jsonObject.SecondName);
        Console.WriteLine(jsonObject.FirstPersoneName);
    }

    [Test]
    public void ValidateFields()
    {
        using FileStream fs = new FileStream(@"Resources/testObject1.json", FileMode.Open);
        AddProjectModel jsonObject = JsonSerializer.Deserialize<AddProjectModel>(fs);

        //Assert.That(AddProjectPage.GetNameFieldName(), jsonObject.ProjectName);
    }

    [Test]
    public void Validate()
    {
        var projectModel = new ProjectModel()
        {
            Age = 11,
            Announcement = "a",
            Identifier = 1,
            FirstPersoneName = "Name",
            IsEnableTestCase = true,
            IsShowAnnouncement = false,
            Name = "Name",
            ProjectType = "3",
            SecondName = "sec name"
        };
    }
}