using AngleSharp.Html;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
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

        [Test]
        public void SuccessAddProject()
        {
            Project project = new ProjectBuilder()
                .SetName("Test Project 1")
                .SetSummary("Summary for Test Project 1")
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

        [Test]
        public void CheckDialogWindow()
        {
            var projectsPage = new ProjectsPage(Driver);

            projectsPage.OpenPage();
            projectsPage.ProjectButton().Click();
            
            Assert.That(projectsPage.WaitDialogWindow(), Is.EqualTo(true));
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public void CheckUploadFile()
        {
            var message = "https://teachmeskills.testmo.net/attachments/view/";
            var projectsPage = new ProjectsPage(Driver);

            string image = "C:/Users/kgrebenyuk/Downloads/girl.png";
            projectsPage.UploadFile(image);
            projectsPage.GetSrcPath();
            Thread.Sleep(1000);

            var srcPath = projectsPage.GetSrcPath().StartsWith(message);

            Assert.That(srcPath, Is.EqualTo(true));
        }
    }
}
