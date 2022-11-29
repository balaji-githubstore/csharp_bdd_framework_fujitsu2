using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation.Pages
{
    public class PIMPage
    {
        private By _addEmployeeLocator = By.LinkText("Add Employee");

        private IWebDriver _driver;

        public PIMPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickOnAddEmployee()
        {
            _driver.FindElement(_addEmployeeLocator).Click();
        }
    }
}
