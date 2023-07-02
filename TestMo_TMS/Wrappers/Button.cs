using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMo_TMS.Wrappers
{
    public class Button
    {
        private readonly UIElement _uiElement;

        public Button(IWebDriver? driver, By @by)
        {
            _uiElement = new UIElement(driver, @by);
        }

        public void Click() => _uiElement.Click();

        public string Text => _uiElement.Text;

        public bool Displayed => _uiElement.Displayed;
    }
}