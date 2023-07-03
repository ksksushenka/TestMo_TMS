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
        public Run expectedRun1 = TestDataHelper.GetTestRun("GetRun.json");
        public Run expectedRun2 = TestDataHelper.AddTestRun("CreateRun.json");

        [Test]
        public void SuccessGetRun()
        {
            var actualRun = _runService.GetRun(expectedRun1.Id);

            Assert.Multiple(() =>
            {
                Assert.That(actualRun.Name, Is.EqualTo(expectedRun1.Name));
                Assert.That(actualRun.ProjectId, Is.EqualTo(expectedRun1.ProjectId));
            });
        }

        [Test]
        public void SuccessAddRun()
        {
            var actualRun = _runService.AddRun(expectedRun2.Name, expectedRun2.Source, expectedRun2.ProjectId);

            Assert.That(actualRun.StatusCode.ToString(), Is.EqualTo("OK"));
        }
    }
}
