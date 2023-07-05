using Allure.Commons;
using AngleSharp.Html;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
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
    public class PtojectTestPositive : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            LoginPage.TryToLogin(Configurator.Admin);
        }

        [Test(Description = "Success Add Project"), Order(1)]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kseniya")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("SuccessAddProject")]
        [AllureIssue("TMS-1")]
        [AllureTms("TMS-2")]
        [AllureTag("Smoke")]
        [AllureLink("https://teachmeskills.testmo.net/")]
        public void SuccessAddProject()
        {
            Project project = new ProjectBuilder()
                .SetName("Test Project 1")
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

        [Test(Description = "Check Dialog Window"), Order(2)]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kseniya")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("CheckDialogWindow")]
        [AllureIssue("TMS-1")]
        [AllureTms("TMS-2")]
        [AllureTag("Smoke")]
        [AllureLink("https://teachmeskills.testmo.net/")]
        public void CheckDialogWindow()
        {
            var projectsPage = new ProjectsPage(Driver);

            projectsPage.OpenPage();
            projectsPage.ProjectButton().Click();
            
            Assert.That(projectsPage.WaitDialogWindow(), Is.EqualTo(true));
        }

        [Test(Description = "CheckBoundaryValues"), Order(3)]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kseniya")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Check Boundary Values")]
        [AllureIssue("TMS-1")]
        [AllureTms("TMS-2")]
        [AllureTag("Smoke")]
        [AllureLink("https://teachmeskills.testmo.net/")]
        [TestCase("")]
        [TestCase("s")]
        [TestCase("Check 40 symbols. Check 40 symbols. 1234")]
        [TestCase("Check 80 symbols. Check 80 symbols. Check 80 symbols. Check 80 symbols. !@#$%^&*")]
        [TestCase("Check 81 symbols. Check 81 symbols. Check 81 symbols. Check 81 symbols. !@#$%^&*1")]
        public void CheckBoundaryValues(string summary)
        {
            var expectedSummary = "Check 81 symbols. Check 81 symbols. Check 81 symbols. Check 81 symbols. !@#$%^&*";
            var projectsPage = new ProjectsPage(Driver);

            projectsPage.OpenPage();
            projectsPage.ProjectButton().Click();
            projectsPage.WaitDialogWindow();
            projectsPage.SummaryInput().SendKeys(summary);

            if (summary.Length <= 80)
            {
                Assert.That(projectsPage.GetSummaryInDialog(), Is.EqualTo(summary));
            }
            else
            {
                Assert.Multiple(() =>
                {
                    Assert.That(projectsPage.GetSummaryInDialog().Length, Is.EqualTo(80));
                    Assert.That(projectsPage.GetSummaryInDialog(), Is.EqualTo(expectedSummary));
                });
            }
        }

        [Test(Description = "Success Remove Project"), Order(4)]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kseniya")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("SuccessRemoveProject")]
        [AllureIssue("TMS-1")]
        [AllureTms("TMS-2")]
        [AllureTag("Smoke")]
        [AllureLink("https://teachmeskills.testmo.net/")]
        public void SuccessRemoveProject()
        {
            Project project = new ProjectBuilder()
                .SetName("ProjectNameForDelete")
                .SetSummary("ProjectSummaryForDelete")
                .Build();

            var projectsPage = new ProjectsPage(Driver);

            List<Project> oldProjects = projectsPage.GetProjectsList();

            projectsPage.CreateProject(project);
            Thread.Sleep(1000);
            projectsPage.DeleteProject(project);
            Thread.Sleep(15000);

            List<Project> newProjects = projectsPage.GetProjectsList();
            oldProjects.Remove(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.That(newProjects, Is.EqualTo(oldProjects));
        }

        [Test(Description = "Check Tooltip"), Order(6)]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kseniya")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("CheckTooltip")]
        [AllureIssue("TMS-1")]
        [AllureTms("TMS-2")]
        [AllureTag("Smoke")]
        [AllureLink("https://teachmeskills.testmo.net/")]
        public void CheckTooltip()
        {
            string expectedMessage = "The project has been marked for deletion and will be removed shortly.";

            Project project = new ProjectBuilder()
                .SetName("ProjectNameForTooltip")
                .SetSummary("ProjectSummaryForTooltip")
                .Build();

            var projectsPage = new ProjectsPage(Driver);

            projectsPage.CreateProject(project);
            projectsPage.DeleteProject(project);
            Thread.Sleep(1000);
            projectsPage.ClickBlockIcon();
            string actualMessage = projectsPage.GetTooltipText();
            
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [Test(Description = "Check UploadFile"), Order(5)]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kseniya")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("CheckUploadFile")]
        [AllureIssue("TMS-1")]
        [AllureTms("TMS-2")]
        [AllureTag("Smoke")]
        [AllureLink("https://teachmeskills.testmo.net/")]
        public void CheckUploadFile()
        {
            var message = "https://teachmeskills.testmo.net/attachments/view/";
            var projectsPage = new ProjectsPage(Driver);

            string image = "C:/Users/kgrebenyuk/source/repos/TestMo_TMS/TestMo_TMS/girl.png";
            projectsPage.UploadFile(image);
            projectsPage.GetSrcPath();
            Thread.Sleep(1000);

            var srcPath = projectsPage.GetSrcPath().StartsWith(message);

            Assert.That(srcPath, Is.EqualTo(true));
        }
    }
}
