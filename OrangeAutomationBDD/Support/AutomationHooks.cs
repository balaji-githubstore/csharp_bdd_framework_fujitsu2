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

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
