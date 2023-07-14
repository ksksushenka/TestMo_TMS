using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestMo_TMS.Core;

namespace TestMo_TMS.Wrappers
{
    public class UIElement : IWebElement
    {
        private IWebElement _webElementImplementation;
        private By _selector;
        private IWebDriver? _driver;
        private Actions _actions;
        protected WaitService _waitService;

        public UIElement(IWebDriver? webDriver, By @by)
        {
            _selector = by;
            _driver = webDriver;
            _waitService = new WaitService(webDriver);
            _actions = new Actions(webDriver);
            _webElementImplementation = webDriver.FindElement(by);
        }

        public UIElement(IWebDriver? webDriver, IWebElement webElement)
        {
            _webElementImplementation = webElement;
            _driver = webDriver;
            _waitService = new WaitService(webDriver);
            _actions = new Actions(webDriver);
        }

        public IWebElement FindElement(By @by)
        {
            return _webElementImplementation.FindElement(@by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return _webElementImplementation.FindElements(@by);
        }

        public void Clear()
        {
            _webElementImplementation.Clear();
        }

        public void SendKeys(string text)
        {
            _webElementImplementation.SendKeys(text);
        }

        public void Submit()
        {
            _webElementImplementation.Submit();
        }

        public void Click()
        {
            _webElementImplementation.Click();
        }

        public string GetAttribute(string attributeName)
        {
            return _webElementImplementation.GetAttribute(attributeName);
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            return _webElementImplementation.GetDomProperty(propertyName);
        }

        public string GetCssValue(string propertyName)
        {
            return _webElementImplementation.GetCssValue(propertyName);
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public void Hover()
        {
            _actions.MoveToElement(_webElementImplementation).Build().Perform();
        }

        public string TagName => _webElementImplementation.TagName;

        public string Text => _webElementImplementation.Text;

        public bool Enabled => _webElementImplementation.Enabled;

        public bool Selected => _webElementImplementation.Selected;

        public Point Location => _webElementImplementation.Location;

        public Size Size => _webElementImplementation.Size;

        public bool Displayed => _webElementImplementation.Displayed;
    }
}