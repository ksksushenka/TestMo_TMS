using OpenQA.Selenium;
using TestMo_TMS.Models;
using TestMo_TMS.Tests.UI;
using TestMo_TMS.Wrappers;

namespace TestMo_TMS.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "auth/login";

        private static readonly By EmailInputBy = By.Name("email");
        private static readonly By PswInputBy = By.Name("password");
        private static readonly By LoginInButtonBy = By.XPath("//button[@type='submit']");

        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        public LoginPage(IWebDriver driver) : base(driver, false)
        {
        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(LoginInButtonBy) != null;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }

        public Input EmailInput()
        {
            return new Input(Driver, EmailInputBy);
        }

        public Input PswInput()
        {
            return new Input(Driver, PswInputBy);
        }

        public Button LoginInButton()
        {
            return new Button(Driver, LoginInButtonBy);
        }

        public void TryToLogin(User user)
        {
            EmailInput().SendKeys(user.Username);
            PswInput().SendKeys(user.Password);
            LoginInButton().Click();
        }
    }
}
