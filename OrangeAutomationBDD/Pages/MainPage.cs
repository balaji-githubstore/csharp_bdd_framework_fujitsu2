using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation.Pages
{
    public class MainPage
    {
        private By _pimLocator = By.XPath("//span[text()='PIM']");

        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetMainPageURL()
        {
            return _driver.Url;
        }

        public void ClickOnPIMMenu()
        {
            _driver.FindElement(_pimLocator).Click();
        }
    }
}
