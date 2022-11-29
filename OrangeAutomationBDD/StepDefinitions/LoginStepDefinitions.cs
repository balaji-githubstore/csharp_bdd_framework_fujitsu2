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
        private readonly AutomationHooks _hooks;
        private readonly ScenarioContext _scenarioContext;

        public LoginStepDefinitions(AutomationHooks hooks,ScenarioContext scenarioContext)
        {
            _hooks = hooks;
            _scenarioContext = scenarioContext;
        }

        //[Scope(Feature = "Login")]
        //[Scope(Tag ="login")]
        [Given(@"I open browser with OrangeHRM application")]
        [Given(@"I have browser with OrangeHRM application")]
        public void GivenIHaveBrowserWithOrangeHRMApplication()
        {
            _hooks.driver = new ChromeDriver();
            _hooks.driver.Manage().Window.Maximize();
            _hooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _hooks.driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }
        //[Scope(Feature = "Login")]
        [When(@"I enter username as '(.*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            //load the record in keyvalue pair which will be available only for current scenario
            _scenarioContext.Add("currentUser", username);
            //Console.WriteLine(username);
            _hooks.driver.FindElement(By.Name("username")).SendKeys(username);
        }

        [When(@"I enter password as '(.*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            _hooks.driver.FindElement(By.Name("password")).SendKeys(password);
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            _hooks.driver.FindElement(By.XPath("//button[normalize-space()='Login']")).Click();
        }

        [Then(@"I should get access to the dashboard with url as '(.*)'")]
        public void ThenIShouldGetAccessToTheDashboardWithUrlAs(string expectedUrl)
        {
            //wait for page load
            Assert.That(_hooks.driver.Url, Is.EqualTo(expectedUrl));
        }

        [Then(@"I should not get access to portal with error messgae as '([^']*)'")]
        public void ThenIShouldNotGetAccessToPortalWithErrorMessgaeAs(string expectedError)
        {
            string actualError = _hooks.driver.FindElement(By.XPath("//p[contains(@class,'oxd-alert-content')]")).Text;
            Assert.That(actualError, Is.EqualTo(expectedError));
        }

    }
}
