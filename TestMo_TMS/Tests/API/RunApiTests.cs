using Allure.Commons;
using NLog;
using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMo_TMS.Models;
using TestMo_TMS.Utilites.Helpers;

namespace TestMo_TMS.Tests.API
{
    public class RunApiTests : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public Run actualRequest = TestDataHelper.GetRunRequest("GetRunRequest.json");
        public ResultRun expectedResponse = TestDataHelper.GetRunResponse("GetRunResponse.json");

        public Run expectedResponse2 = TestDataHelper.AddTestRun("CreateRun.json");

        [Test(Description = "Success Get Run")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kseniya")]
        [AllureSuite("SuccessGetRun")]
        [AllureSubSuite("InvalidGetProject")]
        [AllureIssue("TMS-1")]
        [AllureTms("TMS-2")]
        [AllureTag("Smoke")]
        [AllureLink("https://teachmeskills.testmo.net/")]
        public void SuccessGetRun()
        {
            var actualRun = _runService.GetRun(actualRequest.Id);
            _logger.Info("Actual Run: " + actualRun);
            _logger.Info("Expected Run: " + expectedResponse);

            Assert.Multiple(() =>
            {
                Assert.That(actualRun.Result.Name, Is.EqualTo(expectedResponse.Result.Name));
                Assert.That(actualRun.Result.Project_Id, Is.EqualTo(expectedResponse.Result.Project_Id));
            });
        }

        [Test(Description = "Success Add Run")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kseniya")]
        [AllureSuite("SuccessAddRun")]
        [AllureSubSuite("InvalidGetProject")]
        [AllureIssue("TMS-1")]
        [AllureTms("TMS-2")]
        [AllureTag("Smoke")]
        [AllureLink("https://teachmeskills.testmo.net/")]
        public void SuccessAddRun()
        {
            var actualRun = _runService.AddRun(expectedResponse2);
            _logger.Info("Actual Run: " + actualRun);
            _logger.Info("Expected Run: " + expectedResponse2);

            Assert.That(actualRun.StatusCode.ToString(), Is.EqualTo("Created"));
        }
    }
}
