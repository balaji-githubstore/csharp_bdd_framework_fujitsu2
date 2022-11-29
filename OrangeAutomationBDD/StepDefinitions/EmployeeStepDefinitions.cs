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
        private static Table _empTable;
        private readonly AutomationHooks _hooks;

        public EmployeeStepDefinitions(AutomationHooks hooks)
        {
            this._hooks = hooks;
        }

        [When(@"I click on PIM menu")]
        public void WhenIClickOnPIMMenu()
        {
            _hooks.driver.FindElement(By.XPath("//span[text()='PIM']")).Click();
        }

        [When(@"I click on Add Employee")]
        public void WhenIClickOnAddEmployee()
        {
            _hooks.driver.FindElement(By.LinkText("Add Employee")).Click();
        }

        [When(@"I fill new employee detail")]
        public void WhenIFillNewEmployeeDetail(Table table)
        {
            //load the employee table in static variable
            _empTable = table;

            string fName = _empTable.Rows[0]["firstname"];
            string mName = _empTable.Rows[0]["middlename"];
            string lName = _empTable.Rows[0]["lastname"];

            _hooks.driver.FindElement(By.XPath("//input[@placeholder='First Name']")).SendKeys(fName);
            _hooks.driver.FindElement(By.XPath("//input[@placeholder='Middle Name']")).SendKeys(mName);
            _hooks.driver.FindElement(By.XPath("//input[@placeholder='Last Name']")).SendKeys(lName);
        }

        [When(@"I click on save employee")]
        public void WhenIClickOnSaveEmployee()
        {
            _hooks.driver.FindElement(By.XPath("//button[normalize-space()='Save']")).Click();
        }

        [Then(@"I should be taken to '(.*)' section")]
        public void ThenIShouldBeTakenToSection(string expectedHeader)
        {
            string actualHeader = _hooks.driver.FindElement(By.XPath("//h6[text()='Personal Details']")).Text;
            Assert.That(actualHeader, Is.EqualTo(expectedHeader));
        }

        [Then(@"I should be able to see the added employee record")]
        public void ThenIShouldBeAbleToSeeTheAddedEmployeeRecord()
        {
            Thread.Sleep(5000);
            string fName = _empTable.Rows[0]["firstname"];
            string lName = _empTable.Rows[0]["lastname"];
            string expectedEmployeeNameHeader = fName + " " + lName;

            string actualEmployeeNameHeader = _hooks.driver.FindElement(By.XPath("//div[@class='orangehrm-edit-employee-name']//h6")).Text;

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
