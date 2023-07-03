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

        public Run expectedRun1 = TestDataHelper.GetTestRun("GetRun.json");
        public Run expectedRun2 = TestDataHelper.AddTestRun("CreateRun.json");

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
            var actualRun = _runService.GetRun(expectedRun1.Id);
            _logger.Info("Actual Run: " + actualRun);
            _logger.Info("Expected Run: " + expectedRun1);

            Assert.Multiple(() =>
            {
                Assert.That(actualRun.Name, Is.EqualTo(expectedRun1.Name));
                Assert.That(actualRun.ProjectId, Is.EqualTo(expectedRun1.ProjectId));
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
            var actualRun = _runService.AddRun(expectedRun2.Name, expectedRun2.Source, expectedRun2.ProjectId);
            _logger.Info("Actual Run: " + actualRun);
            _logger.Info("Expected Run: " + expectedRun2);

            Assert.That(actualRun.StatusCode.ToString(), Is.EqualTo("OK"));
        }
    }
}
