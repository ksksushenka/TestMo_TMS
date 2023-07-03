using Newtonsoft.Json.Linq;
using TestMo_TMS.Models;
using TestMo_TMS.Utilites.Helpers;
using RestSharp;
using Allure.Commons;
using NUnit.Allure.Attributes;

namespace TestMo_TMS.Tests.API
{
    public class ProjectApiTests : BaseApiTest
    {
        public Project expectedProject1 = TestDataHelper.GetTestProject("GetProject.json");
        public Project expectedProject2 = TestDataHelper.GetTestProject("GetInvalidProject.json");

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
            var actualProject = _projectService.GetProject(expectedProject1.Id);

            Assert.Multiple(() =>
            {
                Assert.That(actualProject.Name, Is.EqualTo(expectedProject1.Name));
                Assert.That(actualProject.Summary, Is.EqualTo(expectedProject1.Summary));
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
        public void InvalidGetProject()
        {
            var expectedMessage = "The project does not exist or you do not have the permissions to access it.";
            var actualProject = _projectService.GetProject(expectedProject2.Id);

            Assert.That(actualProject.Message, Is.EqualTo(expectedMessage));
        }
    }
}
