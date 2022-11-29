using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
//no automation keywords used
namespace Fujitsu.OrangeAutomation.Pages
{
    public class LoginPage
    {
        private By _usernameLocator = By.Name("username");
        private By _passwordLocator = By.CssSelector("[name='password']");
        private By _loginLocator = By.XPath("//button[normalize-space()='Login']");
        private By _errorLocator = By.XPath("//p[contains(@class,'oxd-alert')]");

        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void EnterUsername(string username)
        {
            _driver.FindElement(_usernameLocator).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(_passwordLocator).SendKeys(password);
        }

        public void ClickOnLogin()
        {
            _driver.FindElement(_loginLocator).Click();
        }

        public string GetInvalidLoginErrorMessage()
        {
            return _driver.FindElement(_errorLocator).Text;
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



