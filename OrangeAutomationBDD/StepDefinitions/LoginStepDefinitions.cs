using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrangeAutomationBDD.Support;
using System;
using TechTalk.SpecFlow;

namespace OrangeAutomationBDD.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        [Scope(Feature = "Login")]
        //[Scope(Tag ="login")]
        [Given(@"I have browser with OrangeHRM application")]
        public void GivenIHaveBrowserWithOrangeHRMApplication()
        {
            AutomationHooks.driver = new ChromeDriver();
            AutomationHooks.driver.Manage().Window.Maximize();
            AutomationHooks.driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            AutomationHooks.driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

        [When(@"I enter username as '(.*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            //Console.WriteLine(username);
            AutomationHooks.driver.FindElement(By.Name("username")).SendKeys(username);
        }

        [When(@"I enter password as '(.*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            AutomationHooks.driver.FindElement(By.Name("password")).SendKeys(password);
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            AutomationHooks.driver.FindElement(By.XPath("//button[normalize-space()='Login']")).Click();
        }

        [Then(@"I should get access to the dashboard with url as '(.*)'")]
        public void ThenIShouldGetAccessToTheDashboardWithUrlAs(string expectedUrl)
        {
            //wait for page load
            Assert.That(AutomationHooks.driver.Url,Is.EqualTo(expectedUrl));
        }

        [Then(@"I should not get access to portal with error messgae as '([^']*)'")]
        public void ThenIShouldNotGetAccessToPortalWithErrorMessgaeAs(string expectedError)
        {
            string actualError = AutomationHooks.driver.FindElement(By.XPath("//p[contains(@class,'oxd-alert-content')]")).Text;
            Assert.That(actualError, Is.EqualTo(expectedError));
        }

    }
}
