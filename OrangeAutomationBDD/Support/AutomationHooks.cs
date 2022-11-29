using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
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
        public IWebDriver driver;

        public void LaunchBrowser(string browserName = "ch")
        {
            if (browserName.ToLower().Equals("edge"))
            {
                driver = new EdgeDriver();
            }
            else if (browserName.ToLower().Equals("ff"))
            {
                driver = new FirefoxDriver();
            }
            else
            {
                driver = new ChromeDriver();
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
