using Allure.Commons;
using NLog;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TestMo_TMS.Core;
using TestMo_TMS.Pages;
using TestMo_TMS.Utilites.Configuration;

namespace TestMo_TMS.Tests.UI
{
    [AllureNUnit]
    public class BaseTest
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        protected IWebDriver Driver;
        protected WaitService? WaitService;
        private AllureLifecycle _allure;
        public LoginPage LoginPage { get; set; }


        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            WaitService = new WaitService(Driver);
            _allure = AllureLifecycle.Instance;
            LoginPage = new LoginPage(Driver);

            LoginPage.OpenPage();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                _allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }

            Driver.Quit();
            Driver.Dispose();
        }
    }
}