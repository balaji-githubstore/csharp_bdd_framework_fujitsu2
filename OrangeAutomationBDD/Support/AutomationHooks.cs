using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeAutomationBDD.Support
{
    [Binding]
    public class AutomationHooks
    {
        public static IWebDriver driver;

        [Given(@"I have browser with OrangeHRM application")]
        public void GivenIHaveBrowserWithOrangeHRMApplication()
        {
            Console.WriteLine("hello");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
