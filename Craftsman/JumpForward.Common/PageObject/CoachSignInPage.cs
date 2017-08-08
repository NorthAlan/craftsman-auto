using Craftsman.Core;
using Craftsman.Core.Component;
using Craftsman.Core.Factory;
using Craftsman.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class CoachSignInPage : PageObjectBase
    {
        public CoachSignInPage(IWebDriver driver) : base(driver)
        {
            WaitSelector.WaitingFor_ElementExists(this.Driver, By.Id("ContentPlaceHolder1_txtUsername"));

            txtUserName = new TextBox(driver, By.Id("ContentPlaceHolder1_txtUsername"));
            txtPassword = new TextBox(driver, By.Id("ContentPlaceHolder1_txtPassword"));
            btnSignIn = new Button(driver, By.XPath(".//input[@value='Sign In']"));
            txaLoadIcon = new TextArea(driver, By.Id("grid-loader-holder"));
        }
        #region Page elements     
        
        protected TextBox txtUserName;
        protected TextBox txtPassword;
        protected Button btnSignIn;
        /// <summary>
        /// move to base
        /// </summary>
        protected TextArea txaLoadIcon;
        #endregion Page elements

        #region Action for test case
        /// <summary>
        /// Sign In
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        private void SignIn(string userName, string password)
        {
            this.txtUserName.Clear();
            this.txtPassword.Clear();

            this.txtUserName.SendKeys(userName);
            this.txtPassword.SendKeys(password);

            this.btnSignIn.Click();
            txaLoadIcon.Waiting(For.Invisibility);
            //WaitSelector.WaitingFor_InvisibilityOfElementLocated(this.Driver, By.Id("grid-loader-holder"));
        }

        /// <summary>
        /// Coach Login
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public DatabaseProspectsPage CoachSignIn(string userName, string password)
        {
            this.SignIn(userName, password);
            WaitSelector.WaitingFor_InvisibilityOfElementLocated(this.Driver, By.Id("grid-loader-holder"));
            return new DatabaseProspectsPage(this.Driver);
        }

        /// <summary>
        /// Compliance login
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public ComplianceHomePage ComplianceSignIn(string userName, string password)
        {
            this.SignIn(userName, password);
            //WebElementKeeper.WaitingFor_InvisibilityOfElementLocated(this.Driver, By.Id("grid-loader-holder"));
            return new ComplianceHomePage(this.Driver);
        }
        #endregion
    }
}
