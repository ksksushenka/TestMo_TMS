using OpenQA.Selenium;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using TestMo_TMS.Core;
using TestMo_TMS.Models;
using TestMo_TMS.Tests.UI;
using TestMo_TMS.Wrappers;

namespace TestMo_TMS.Pages
{
    public class ProjectsPage : BasePage
    {
        private static string END_POINT = "admin/projects";

        private static readonly By ProjectButtonBy = By.CssSelector("button.ui.button");
        private static readonly By DeleteIconBy = By.XPath("//td[4]");
        private static readonly By BlockIconBy = By.CssSelector("i.fas.fa-ban.icon-deleted-entity");
        private static readonly By DeleteTooltipBy = By.CssSelector("div.popup__tooltip__content");
        private static readonly By NameInTableBy = By.XPath("//a[@data-action=\"edit\"]");
        private static readonly By SummaryInTableBy = By.XPath("//td[2]");
        private static readonly By ProjectLineBy = By.CssSelector("tr[data-id]");

        public ProjectsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            _logger.Info("The Project page is opened.");
        }
        public ProjectsPage(IWebDriver driver) : base(driver, false)
        {
            _logger.Info("The Project page is opened.");
        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(ProjectButtonBy) != null;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }

        public Button ProjectButton()
        {
            return new Button(Driver, ProjectButtonBy);
        }

        public void ClickBlockIcon()
        {
            Driver.FindElement(BlockIconBy).Click();
        }

        public void CheckBlockIcon()
        {
            while (WaitService.GetVisibleElement(BlockIconBy) != null)
            {
                OpenPage();
                continue;
            }
        }

        public IList<IWebElement> GetAllProjectsNames()
        {
            return Driver.FindElements(NameInTableBy);
        }

        public IList<IWebElement> GetAllProjectsSummaries()
        {
            return Driver.FindElements(SummaryInTableBy);
        }

        public IList<IWebElement> GetAllDeleteIcons()
        {
            return Driver.FindElements(DeleteIconBy);
        }

        public List<Project> GetProjectsList()
        {
            List<Project> projects = new List<Project>();

            OpenPage();

            var elements = Driver.FindElements(ProjectLineBy);

            for (int i = 0; i < elements.Count; i++)
            {
                var names = GetAllProjectsNames();

                for (int j = i; j == i; j++)
                {
                    var summaries = GetAllProjectsSummaries();

                    for (int k = i; k == i; k++)
                    {
                        projects.Add(new Project(names[j].Text, summaries[k].Text));
                    }
                }
            }
            return projects;
        }

        public void DeleteIconClick(string name)
        {
            OpenPage();

            var elements = Driver.FindElements(ProjectLineBy);

            for (int i = 0; i < elements.Count; i++)
            {
                var delete = GetAllDeleteIcons();

                for (int j = i; j == i; j++)
                {
                    var names = GetAllProjectsNames();

                    for (int k = i; k == i; k++)
                    {
                        if (names[k].Text == name)
                        {
                            delete[k].Click();
                            break;
                        }
                    }
                }
            }
        }

        public string GetTooltipText()
        {
            return Driver.FindElement(DeleteTooltipBy).Text;
        }

        public void CreateProject(Project project)
        {
            OpenPage();
            ProjectButton().Click();
            new ProjectModalWindow(Driver).WaitDialogWindow();
            new ProjectModalWindow(Driver).NameInput().SendKeys(project.Name);
            new ProjectModalWindow(Driver).SummaryInput().SendKeys(project.Note);
            new ProjectModalWindow(Driver).AddProjectButton().Click();
        }

        public void DeleteProject(Project project)
        {
            OpenPage();
            CheckBlockIcon();
            DeleteIconClick(project.Name);
            new ProjectModalWindow(Driver).Checkbox().Click();
            new ProjectModalWindow(Driver).DeleteButton().Click();
        }
    }
}