using Allure.Commons;
using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMo_TMS.Pages;
using TestMo_TMS.Utilites.Configuration;

namespace TestMo_TMS.Tests.UI
{
    public class LoginTest : BaseTest
    {
        [Test(Description = "Success Login Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kseniya")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GUI_Login")]
        [AllureIssue("TMS-1")]
        [AllureTms("TMS-2")]
        [AllureTag("Smoke")]
        [AllureLink("https://teachmeskills.testmo.net/")]
        public void SuccessLoginTest()
        {
            LoginPage.TryToLogin(Configurator.Admin);
        }
    }
}
