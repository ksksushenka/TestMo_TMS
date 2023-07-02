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
        private static readonly By NameInputBy = By.XPath("//input[@value='']");
        private static readonly By SummaryInputBy = By.TagName("textarea");
        private static readonly By AddProjectButtonBy = By.CssSelector("button.ui.button.primary");
        private static readonly By SelectButtonBy = By.CssSelector("button.ui.compact.fluid.button");
        private static readonly By UploadFileBy = By.CssSelector("input[type=\"file\"]");
        private static readonly By DeleteIconBy = By.XPath("//td[4]");
        private static readonly By CheckboxBy = By.CssSelector("label");
        private static readonly By DeleteButtonBy = By.CssSelector("button.ui.negative.button");
        private static readonly By BlockIconBy = By.CssSelector("i.fas.fa-ban.icon-deleted-entity");
        private static readonly By DeleteTooltipBy = By.CssSelector("div.popup__tooltip__content");
        private static readonly By NameInTableBy = By.XPath("//a[@data-action=\"edit\"]");
        private static readonly By SummaryInTableBy = By.XPath("//td[2]");
        private static readonly By ProjectLineBy = By.CssSelector("tr[data-id]");
        private static readonly By UploadedImageBy = By.XPath("//div/div/img");
        private static readonly By RequiredNameMessageBy = By.CssSelector(".message-block > ul:nth-child(1) > li:nth-child(1)");

        public ProjectsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        public ProjectsPage(IWebDriver driver) : base(driver, false)
        {
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

        public Input NameInput()
        {
            return new Input(Driver, NameInputBy);
        }

        public Input SummaryInput()
        {
            return new Input(Driver, SummaryInputBy);
        }

        public Button AddProjectButton()
        {
            return new Button(Driver, AddProjectButtonBy);
        }

        public Button Checkbox()
        {
            return new Button(Driver, CheckboxBy);
        }

        public Button DeleteButton()
        {
            return new Button(Driver, DeleteButtonBy);
        }

        public Button SelectButton()
        {
            return new Button(Driver, SelectButtonBy);
        }

        public void UploadFileButton(string image)
        {
            Driver.FindElement(UploadFileBy).SendKeys(image);
        }

        public void ClickBlockIcon()
        {
            Driver.FindElement(BlockIconBy).Click();
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

        public string GetSummaryInDialog()
        {
            return Driver.FindElement(SummaryInputBy).GetAttribute("value");
        }

        public string GetSrcPath()
        {
            return Driver.FindElement(UploadedImageBy).GetAttribute("src");
        }

        public string GetRequiredNameMessage()
        {
            return Driver.FindElement(RequiredNameMessageBy).Text;
        }

        public bool WaitDialogWindow()
        {
            return WaitService.GetVisibleElement(NameInputBy) != null;
        }

        public bool WaitUploadedImages()
        {
            return WaitService.GetVisibleElement(UploadedImageBy) != null;
        }

        public bool WaitRequiredNameMessage()
        {
            return WaitService.GetVisibleElement(RequiredNameMessageBy) != null;
        }

        public void CreateProject(Project project)
        {
            OpenPage();
            ProjectButton().Click();
            WaitDialogWindow();
            NameInput().SendKeys(project.Name);
            SummaryInput().SendKeys(project.Summary);
            AddProjectButton().Click();
        }

        public void DeleteProject(Project project)
        {
            OpenPage();
            DeleteIconClick(project.Name);
            Checkbox().Click();
            DeleteButton().Click();
        }

        public void UploadFile(string image)
        {
            OpenPage();
            ProjectButton().Click();
            WaitDialogWindow();
            SelectButton().Click();
            UploadFileButton(image);
            WaitUploadedImages();
        }
    }
}