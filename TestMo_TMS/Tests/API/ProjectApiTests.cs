using Newtonsoft.Json.Linq;
using TestMo_TMS.Models;
using TestMo_TMS.Utilites.Helpers;
using RestSharp;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NLog;

namespace TestMo_TMS.Tests.API
{
    public class ProjectApiTests : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public Project actualRequest = TestDataHelper.GetProjectRequest("GetProjectRequest.json");
        public ResultProject expectedResponse = TestDataHelper.GetProjectResponse("GetProjectResponse.json");

        public Project actualRequest2 = TestDataHelper.GetProjectRequest("GetInvalidProjectRequest.json");
        public Project expectedResponse2 = TestDataHelper.GetInvalidProjectResponse("GetInvalidProjectResponse.json");

        [Test(Description = "Success Get Project")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kseniya")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("SuccessGetProject")]
        [AllureIssue("TMS-1")]
        [AllureTms("TMS-2")]
        [AllureTag("Smoke")]
        [AllureLink("https://teachmeskills.testmo.net/")]
        public void SuccessGetProject()
        {
            var actualProject = _projectService.GetProject(actualRequest.Id);
            _logger.Info("Actual Project: " + actualProject);
            _logger.Info("Expected Project: " + expectedResponse);

            Assert.Multiple(() =>
            {
                Assert.That(actualProject.Result.Id, Is.EqualTo(expectedResponse.Result.Id));
                Assert.That(actualProject.Result.Name, Is.EqualTo(expectedResponse.Result.Name));
                Assert.That(actualProject.Result.Note, Is.EqualTo(expectedResponse.Result.Note));
            });
        }

        [Test(Description = "Invalid Get Project")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kseniya")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("InvalidGetProject")]
        [AllureIssue("TMS-1")]
        [AllureTms("TMS-2")]
        [AllureTag("Smoke")]
        [AllureLink("https://teachmeskills.testmo.net/")]
        public void GetInvalidProject()
        {
            var actualProject = _projectService.GetInvalidProject(expectedResponse2.Id);
            _logger.Info("Actual Project: " + actualProject);
            _logger.Info("Expected Project: " + expectedResponse2);

            Assert.That(actualProject.Message, Is.EqualTo(expectedResponse2.Message));
        }
    }
}
