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

        [Test]
        public void InvalidDataInNameField()
        {
            string expectedMessage = "The name field is required.";
            Project project = new ProjectBuilder()
                .SetName("    ")
                .SetSummary("Summary for Test Project 1")
                .Build();

            var projectsPage = new ProjectsPage(Driver);

            projectsPage.CreateProject(project);
            projectsPage.WaitRequiredNameMessage();
            string actualMessage = projectsPage.GetRequiredNameMessage();

            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void InvalidDataInSymmaryField()
        {
            var expectedSummary = "Check 81 symbols. Check 81 symbols. Check 81 symbols. Check 81 symbols. !@#$%^&*";
            var actualSummary = "Check 81 symbols. Check 81 symbols. Check 81 symbols. Check 81 symbols. !@#$%^&*1";

            var projectsPage = new ProjectsPage(Driver);

            projectsPage.OpenPage();
            projectsPage.ProjectButton().Click();
            projectsPage.WaitDialogWindow();
            projectsPage.SummaryInput().SendKeys(actualSummary);

            Assert.Multiple(() =>
            {
                Assert.That(projectsPage.GetSummaryInDialog().Length, Is.EqualTo(80));
                Assert.That(projectsPage.GetSummaryInDialog(), Is.EqualTo(expectedSummary));
            });
        }

        [Test]
        public void CheckABug()
        {
            Project project = new ProjectBuilder()
                .SetName("")
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
    }
}
