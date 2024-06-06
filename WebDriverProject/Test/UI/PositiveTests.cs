﻿using WebDriverProject.BaseEntites;
using WebDriverProject.Models;
using WebDriverProject.Utils;

namespace WebDriverProject.Test.UI;

[TestFixture]
public class PositiveTests : BaseTest
{
    [SetUp]
    public void Setup()
    {
        Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl);
    }

    [Test]
    public void PositiveLogin()
    {
        var admin = new UserModel()
        {
            UserName = Environment.GetEnvironmentVariable("TESTRAIL_EMAIL"),
            Password = Environment.GetEnvironmentVariable("TESTRAIL_PASSWORD")
        };

        Assert.That(UserStep.SuccessfulLogin(admin)
            .ProductsTitle().Displayed, Is.True);
    }


    [Test]
    public void NavigateToProductsTest()
    {
        var admin = new UserModel()
        {
            UserName = Configurator.ReadConfiguration().UserNameSauceDemo,
            Password = Configurator.ReadConfiguration().PasswordSauceDemo
        };

        UserStep.SuccessfulLogin(admin).CartIcon().Click();

       NavigationStep.NavigateToProductsPage();
       ProductsPage.ProductsTitle();
    }

    [Test]
    public void AddProjectTest()
    {
        var project = new ProjectModel()
        {
            Name = "ASciapaniuk_" + Guid.NewGuid(),
            Announcement = "Test",
            IsShowAnnouncement = true,
            ProjectType = 1,
            IsEnableTestCase = true
        };
    }
}