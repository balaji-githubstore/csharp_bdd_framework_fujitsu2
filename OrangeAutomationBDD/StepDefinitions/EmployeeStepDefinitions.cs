using Fujitsu.OrangeAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OrangeAutomationBDD.Support;
using System;
using TechTalk.SpecFlow;

namespace OrangeAutomationBDD.StepDefinitions
{
    [Binding]
    public class EmployeeStepDefinitions
    {
        //private static Table _empTable;
        private readonly AutomationHooks _hooks;
        private readonly ScenarioContext _scenarioContext;

        private MainPage mainPage;
        private PIMPage pimPage;
        private AddEmployeePage addEmployeePage;
        private PersonalDetailPage personalDetailPage;

        public EmployeeStepDefinitions(AutomationHooks hooks, ScenarioContext scenarioContext)
        {
            this._hooks = hooks;
            _scenarioContext = scenarioContext;
            InitPageObjects();
        }

        public void InitPageObjects()
        {
            mainPage = new MainPage(_hooks.driver);
            pimPage = new PIMPage(_hooks.driver);
            addEmployeePage = new AddEmployeePage(_hooks.driver);
            personalDetailPage = new PersonalDetailPage(_hooks.driver);
        }

        [When(@"I click on PIM menu")]
        public void WhenIClickOnPIMMenu()
        {
            string user = _scenarioContext.Get<string>("currentUser");
            Console.WriteLine(user);
            mainPage.ClickOnPIMMenu();
        }

        [When(@"I click on Add Employee")]
        public void WhenIClickOnAddEmployee()
        {
            pimPage.ClickOnAddEmployee();
        }

        [When(@"I fill new employee detail")]
        public void WhenIFillNewEmployeeDetail(Table table)
        {
            //load the employee table in static variable
            //_empTable = table;
            _scenarioContext.Add("empTable", table);

            string fName = table.Rows[0]["firstname"];
            string mName = table.Rows[0]["middlename"];
            string lName = table.Rows[0]["lastname"];

            addEmployeePage.EnterFirstName(fName);
            addEmployeePage.EnterMiddleName(mName);
            //_hooks.driver.FindElement(By.XPath("//input[@placeholder='Middle Name']")).SendKeys(mName);
            //add in AddEmployeePage
            _hooks.driver.FindElement(By.XPath("//input[@placeholder='Last Name']")).SendKeys(lName);
        }

        [When(@"I click on save employee")]
        public void WhenIClickOnSaveEmployee()
        {
            //add in AddEmployeePage
            _hooks.driver.FindElement(By.XPath("//button[normalize-space()='Save']")).Click();
        }

        [Then(@"I should be taken to '(.*)' section")]
        public void ThenIShouldBeTakenToSection(string expectedHeader)
        {
            //add in PersonalDetailPage
            string actualHeader = personalDetailPage.GetPersonlDetailHeader();
            Assert.That(actualHeader, Is.EqualTo(expectedHeader));
        }

        [Then(@"I should be able to see the added employee record")]
        public void ThenIShouldBeAbleToSeeTheAddedEmployeeRecord()
        {
            Thread.Sleep(5000);

            Table empTable = _scenarioContext.Get<Table>("empTable");

            string fName = empTable.Rows[0]["firstname"];
            string lName = empTable.Rows[0]["lastname"];
            string expectedEmployeeNameHeader = fName + " " + lName;

            //add in PersonalDetailPage
            string actualEmployeeNameHeader = _hooks.driver.FindElement(By.XPath("//div[@class='orangehrm-edit-employee-name']//h6")).Text;

            //add in PersonalDetailPage
            string actualFirstNameInTextBox = _hooks.driver.FindElement(By.Name("firstName")).GetAttribute("value");

            Assert.Multiple(() =>
            {
                Assert.That(actualEmployeeNameHeader.ToLower(), Is.EqualTo(expectedEmployeeNameHeader.ToLower()));
                Assert.That(actualFirstNameInTextBox.ToLower(), Is.EqualTo(fName.ToLower()));
            }
          );
        }
    }
}
