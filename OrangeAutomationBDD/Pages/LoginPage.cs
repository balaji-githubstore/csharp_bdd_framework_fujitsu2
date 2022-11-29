using Fujitsu.WebDriverKeywords.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation.Pages
{
    public class LoginPage : AutomationKeywords
    {
        private By _usernameLocator = By.Name("username");
        private By _passwordLocator = By.CssSelector("[name='password']");
        private By _loginLocator = By.XPath("//button[normalize-space()='Login']");
        private By _errorLocator = By.XPath("//p[contains(@class,'oxd-alert')]");

        private IWebDriver _driver;

        public LoginPage(IWebDriver driver):base(driver)
        {
            this._driver = driver;
        }

        public void EnterUsername(string username)
        {
            SendTextByLocator(_usernameLocator, username);
        }

        public void EnterPassword(string password)
        {
            SendTextByLocator(_passwordLocator, password); ;
        }

        public void ClickOnLogin()
        {
            ClickByLocator(_loginLocator);
        }

        public string GetInvalidLoginErrorMessage()
        {
            return GetTextByLocator(_errorLocator);
        }

        public string GetUsernamePlaceholder()
        {
            return _driver.FindElement(_usernameLocator).GetAttribute("placeholder");
        }
        public string GetPasswordPlaceholder()
        {
            return _driver.FindElement(_passwordLocator).GetAttribute("placeholder");
        }

    }
}



