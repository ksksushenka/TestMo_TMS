using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMo_TMS.Core;
using TestMo_TMS.Utilites.Configuration;

namespace TestMo_TMS.Pages
{
    public abstract class BasePage
    {
        protected static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        protected IWebDriver Driver;
        protected WaitService WaitService;

        public BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;
            WaitService = new WaitService(Driver);

            if (openPageByUrl)
            {
                OpenPage();
            }
        }

        public abstract void OpenPage();
        public abstract bool IsPageOpened();
    }
}