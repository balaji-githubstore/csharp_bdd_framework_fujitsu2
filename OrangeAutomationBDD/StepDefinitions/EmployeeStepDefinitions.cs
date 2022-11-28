using OpenQA.Selenium;
using OrangeAutomationBDD.Support;
using System;
using TechTalk.SpecFlow;

namespace OrangeAutomationBDD.StepDefinitions
{
    [Binding]
    public class EmployeeStepDefinitions
    {
        [When(@"I click on PIM menu")]
        public void WhenIClickOnPIMMenu()
        {
            AutomationHooks.driver.FindElement(By.XPath("//span[text()='PIM']")).Click();
        }

        [When(@"I click on Add Employee")]
        public void WhenIClickOnAddEmployee()
        {
            AutomationHooks.driver.FindElement(By.LinkText("Add Employee")).Click();
        }

        [When(@"I fill new employee detail")]
        public void WhenIFillNewEmployeeDetail(Table table)
        {
            Console.WriteLine(table.RowCount);
            
            Console.WriteLine(table.Rows[0][0]);
            Console.WriteLine(table.Rows[0][1]);

            Console.WriteLine(table.Rows[0]["firstname"]);
            Console.WriteLine(table.Rows[0]["middlename"]);
        }

        [When(@"I click on save employee")]
        public void WhenIClickOnSaveEmployee()
        {
            
        }

        [Then(@"I should be taken to '(.*)' section")]
        public void ThenIShouldBeTakenToSection(string p0)
        {
            
        }

        [Then(@"I should be able to see the added employee record")]
        public void ThenIShouldBeAbleToSeeTheAddedEmployeeRecord()
        {
            
        }
    }
}
