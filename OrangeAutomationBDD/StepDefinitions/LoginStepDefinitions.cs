using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace OrangeAutomationBDD.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        IWebDriver driver;

        [Given(@"I have browser with OrangeHRM application")]
        public void GivenIHaveBrowserWithOrangeHRMApplication()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

        [When(@"I enter username as '(.*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            //Console.WriteLine(username);
            driver.FindElement(By.Name("username")).SendKeys(username);
        }

        [When(@"I enter password as '(.*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            driver.FindElement(By.Name("password")).SendKeys(password);
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            driver.FindElement(By.XPath("//button[normalize-space()='Login']")).Click();
        }

        [Then(@"I should get access to the dashboard with url as '(.*)'")]
        public void ThenIShouldGetAccessToTheDashboardWithUrlAs(string expectedUrl)
        {
            //wait for page load
            Assert.That(driver.Url,Is.EqualTo(expectedUrl));
        }

        [Then(@"I should not get access to portal with error messgae as '([^']*)'")]
        public void ThenIShouldNotGetAccessToPortalWithErrorMessgaeAs(string expectedError)
        {
            string actualError = driver.FindElement(By.XPath("//p[contains(@class,'oxd-alert-content')]")).Text;
            Assert.That(actualError, Is.EqualTo(expectedError));
        }

    }
}
