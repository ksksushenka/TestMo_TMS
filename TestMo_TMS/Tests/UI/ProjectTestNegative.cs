using Allure.Commons;
using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMo_TMS.Models;
using TestMo_TMS.Pages;
using TestMo_TMS.Utilites.Configuration;

namespace TestMo_TMS.Tests.UI
{
    public class ProjectTestNegative : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            LoginPage.TryToLogin(Configurator.Admin);
        }

        [Test(Description = "Set invalid data in name's field")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kseniya")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("InvalidDataInNameField")]
        [AllureIssue("TMS-1")]
        [AllureTms("TMS-2")]
        [AllureTag("Smoke")]
        [AllureLink("https://teachmeskills.testmo.net/")]
        public void InvalidDataInNameField()
        {
            string expectedMessage = "The name field is required.";
            Project project = new ProjectBuilder()
                .SetName("    ")
                .SetSummary("Note for Test Project 1")
                .Build();

            var projectsPage = new ProjectsPage(Driver);
            var projectModalWindow = new ProjectModalWindow(Driver);

            projectsPage.CreateProject(project);
            projectModalWindow.WaitRequiredNameMessage();
            string actualMessage = projectModalWindow.GetRequiredNameMessage();

            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [Test(Description = "Set invalid data in summary's field")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kseniya")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("InvalidDataInSymmaryField")]
        [AllureIssue("TMS-1")]
        [AllureTms("TMS-2")]
        [AllureTag("Smoke")]
        [AllureLink("https://teachmeskills.testmo.net/")]
        public void InvalidDataInSummaryField()
        {
            var expectedSummary = "Check 81 symbols. Check 81 symbols. Check 81 symbols. Check 81 symbols. !@#$%^&*";
            var actualSummary = "Check 81 symbols. Check 81 symbols. Check 81 symbols. Check 81 symbols. !@#$%^&*1";

            var projectsPage = new ProjectsPage(Driver);
            var projectModalWindow = new ProjectModalWindow(Driver);

            projectsPage.OpenPage();
            projectsPage.ProjectButton().Click();
            projectModalWindow.WaitDialogWindow();
            projectModalWindow.SummaryInput().SendKeys(actualSummary);

            Assert.Multiple(() =>
            {
                Assert.That(projectModalWindow.GetSummaryInDialog().Length, Is.EqualTo(80));
                Assert.That(projectModalWindow.GetSummaryInDialog(), Is.EqualTo(expectedSummary));
            });
        }

        [Test(Description = "Check a bug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kseniya")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("CheckABug")]
        [AllureIssue("TMS-1")]
        [AllureTms("TMS-2")]
        [AllureTag("Smoke")]
        [AllureLink("https://teachmeskills.testmo.net/")]
        public void CheckABug()
        {
            Project project = new ProjectBuilder()
                .SetName("")
                .SetSummary("Note for Test Project 1")
                .Build();

            var projectsPage = new ProjectsPage(Driver);

            List<Project> oldProjects = projectsPage.GetProjectsList();

            projectsPage.CreateProject(project);
            Thread.Sleep(1000);

            List<Project> newProjects = projectsPage.GetProjectsList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.That(newProjects, Is.EqualTo(oldProjects));
        }
    }
}
