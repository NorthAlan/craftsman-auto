using Craftsman.Core.Factory;
using Craftsman.Core.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.PageObject
{

    public class CoachSignInPage : PageObjectBase
    {
        public CoachSignInPage(IWebDriver driver) : base(driver)
        {
            WebElementKeeper.WaitingFor_ElementExists(this.Driver, By.Id("ContentPlaceHolder1_txtUsername"));
        }
        #region Page elements
        [FindsBy(How = How.Id, Using = "ContentPlaceHolder1_txtUsername")]
        protected IWebElement txtUserName;

        [FindsBy(How = How.Id, Using = "ContentPlaceHolder1_txtPassword")]
        protected IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = ".//button[text()='Sign in']")]
        protected IWebElement btnSignIn;

        #endregion Page elements

        #region Action for test case
        /// <summary>
        /// Sign In for Dashboard
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        public void SignIn(string userName, string password)
        {
            this.txtUserName.Clear();
            this.txtPassword.Clear();

            this.txtUserName.SendKeys(userName);
            this.txtPassword.SendKeys(password);

            this.btnSignIn.Click();
        }
        #endregion
    }
}
