using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using BaseLander;
using BaseLander.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Test.LanderTestFW.Pages
{

    public class PageLogin : TestBase
    {
        [FindsBy(How = How.Id, Using = "signup_email")]
        private IWebElement Email;

        [FindsBy(How = How.Id, Using = "signup_password")]
        private IWebElement Password;

        [FindsBy(How = How.Id)]
        private IWebElement buttonLogin;

        [FindsBy(How = How.Id)]
        private IWebElement forgotPassword;

        [FindsBy(How = How.Id)]
        private IWebElement resetPasswordSubmit;

        [FindsBy(How = How.Id)]
        private IWebElement resetPasswordSubmitButton;

        [FindsBy(How = How.CssSelector, Using = "label.comment-login.fail")]
        private IWebElement Error;

        [FindsBy(How = How.CssSelector, Using = "[htmlfor=Password]")]
        private IWebElement passwordError;

        [FindsBy(How = How.CssSelector, Using = "label[for=signup_email]")]
        private IWebElement emailError;

        [FindsBy(How = How.ClassName, Using = "field-validation-error")]
        private IWebElement loginError;

        [FindsBy(How = How.CssSelector, Using = "span.error-found.comment-login")]
        private IWebElement Errors;

        [FindsBy(How = How.ClassName, Using = "validationContainer2")]
        private IWebElement sent;

        private IWebDriver driver;

        private WebDriverWait wait; 

        private WebDriverWait wait1; 
		
		
        public PageLogin(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(this.driver, new TimeSpan(0, 0, 30));
        }

        public void setEmail(string value)
        {
            wait.Until((d => Email.Displayed));
            Email.Clear();
            Email.SendKeys(value);
        }

        protected override bool Condition()
        {
            throw new NotImplementedException();
        }

        public void setPassword(string value)
        {
            wait.Until((d => Password.Displayed));
            Password.Clear();
            Password.SendKeys(value);
        }

        public void setNewEmail(string value)
        {
            wait.Until((d => resetPasswordSubmit.Displayed));
            resetPasswordSubmit.Clear();
            resetPasswordSubmit.SendKeys(value);
        }

        public void pressLogInButton()
        {
            wait.Until((d => buttonLogin.Displayed));
            buttonLogin.Click();
        }

        public void pressForgotPassword()
        {
            wait.Until((d => forgotPassword.Displayed));
            forgotPassword.Click();
        }

        public void pressResetPassword()
        {
            wait.Until((d => resetPasswordSubmitButton.Displayed));
            resetPasswordSubmitButton.Click();
        }

        public string getForGotErrorMessage() {
            wait.Until((d => Error.Displayed));
            return Error.Text;
        }

        public string getPasswordErrorMessage()
        {
            wait.Until((d => passwordError.Displayed));
            return passwordError.Text.ToString();
        }

        public string getLoginErrorMessage()
        {
            wait.Until((d => Errors.Displayed));
            return Errors.Text.ToString();
        }
        public string getEmailErrorMessage()
        {
            wait.Until((d => emailError.Displayed));
            return emailError.Text.ToString();
        }

        public string getSentMessage()
        {
            wait.Until((d => sent));
            return sent.Text.ToString();
        }

        public string getloginErrorMessage()
        {
            wait.Until((d => loginError.Displayed));
            return loginError.Text.ToString();
        }

        public OverallPage LogIn(string email,string pass) {
            setEmail(email);
            setPassword(pass);
            pressLogInButton();
            return new OverallPage(this.driver);
        }
    }
}
