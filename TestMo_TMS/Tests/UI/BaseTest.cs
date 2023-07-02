using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TestMo_TMS.Core;
using TestMo_TMS.Pages;
using TestMo_TMS.Utilites.Configuration;

namespace TestMo_TMS.Tests.UI
{
    public class BaseTest
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        protected IWebDriver Driver;
        protected WaitService? WaitService;
        public LoginPage LoginPage { get; set; }


        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            WaitService = new WaitService(Driver);
            LoginPage = new LoginPage(Driver);

            LoginPage.OpenPage();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}