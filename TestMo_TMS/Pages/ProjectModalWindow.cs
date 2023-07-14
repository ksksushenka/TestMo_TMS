using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMo_TMS.Tests.UI;
using TestMo_TMS.Wrappers;

namespace TestMo_TMS.Pages
{
    public class ProjectModalWindow : BasePage
    {
        private static string END_POINT = "admin/projects";

        private static readonly By NameInputBy = By.XPath("//input[@value='']");
        private static readonly By SummaryInputBy = By.TagName("textarea");
        private static readonly By AddProjectButtonBy = By.CssSelector("button.ui.button.primary");
        private static readonly By SelectButtonBy = By.CssSelector("button.ui.compact.fluid.button");
        private static readonly By UploadFileBy = By.CssSelector("input[type=\"file\"]");
        private static readonly By CheckboxBy = By.CssSelector("[data-target=\"confirmationLabel\"]");
        private static readonly By DeleteButtonBy = By.CssSelector("[data-target=\"deleteButton\"]");
        private static readonly By UploadedImageBy = By.XPath("//div/div/img");
        private static readonly By RequiredNameMessageBy = By.ClassName("message-block");

        public ProjectModalWindow(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            _logger.Info("The Project modal window is opened.");
        }
        public ProjectModalWindow(IWebDriver driver) : base(driver, false)
        {
            _logger.Info("The Project modal window is opened.");
        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(NameInputBy) != null;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
            new ProjectsPage(Driver).ProjectButton().Click();
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

        public void UploadFile(string image)
        {
            OpenPage();
            WaitDialogWindow();
            SelectButton().Click();
            UploadFileButton(image);
            WaitUploadedImages();
        }
    }
}
