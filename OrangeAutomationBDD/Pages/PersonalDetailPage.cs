using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation.Pages
{
    public class PersonalDetailPage
    {
        private By PersonalDetailHeaderLocator=By.XPath("//h6[text()='Personal Details']");
        private IWebDriver _driver;

        public PersonalDetailPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetPersonlDetailHeader()
        {
            return _driver.FindElement(PersonalDetailHeaderLocator).Text;
        }
    }
}
