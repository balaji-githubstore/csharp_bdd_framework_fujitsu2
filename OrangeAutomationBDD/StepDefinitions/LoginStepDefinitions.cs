using Fujitsu.OrangeAutomation.Pages;
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

        private LoginPage loginPage;
        private MainPage mainPage;

        public LoginStepDefinitions(AutomationHooks hooks, ScenarioContext scenarioContext)
        {
            _hooks = hooks;
            _scenarioContext = scenarioContext;
        }


        public void InitPageObjects()
        {
            loginPage = new LoginPage(_hooks.driver);
            mainPage = new MainPage(_hooks.driver);
        }

        //[Scope(Feature = "Login")]
        //[Scope(Tag ="login")]
        [Given(@"I open browser with OrangeHRM application")]
        [Given(@"I have browser with OrangeHRM application")]
        public void GivenIHaveBrowserWithOrangeHRMApplication()
        {
            _hooks.LaunchBrowser();
            InitPageObjects();
        }

        [Given(@"I have '(.*)' browser with OrangeHRM application")]
        public void GivenIHaveBrowserWithOrangeHRMApplication(string browser)
        {
            _hooks.LaunchBrowser(browser);
            InitPageObjects();
        }

        //[Scope(Feature = "Login")]
        [When(@"I enter username as '(.*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            //load the record in keyvalue pair which will be available only for current scenario
            _scenarioContext.Add("currentUser", username);
            loginPage.EnterUsername(username);
        }

        [When(@"I enter password as '(.*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            loginPage.EnterPassword(password);
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            loginPage.ClickOnLogin();
        }

        [Then(@"I should get access to the dashboard with url as '(.*)'")]
        public void ThenIShouldGetAccessToTheDashboardWithUrlAs(string expectedUrl)
        {
            //wait for page load
            Assert.That(mainPage.GetMainPageURL(), Is.EqualTo(expectedUrl));
        }

        [Then(@"I should not get access to portal with error messgae as '([^']*)'")]
        public void ThenIShouldNotGetAccessToPortalWithErrorMessgaeAs(string expectedError)
        {
            string actualError = loginPage.GetInvalidLoginErrorMessage();
            Assert.That(actualError, Is.EqualTo(expectedError));
        }

    }
}
