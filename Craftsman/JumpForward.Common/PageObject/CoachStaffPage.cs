using Craftsman.Core.Tools;
using JumpForward.Common.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class CoachStaffPage: CoachPageBase
    {
        public CoachStaffPage(IWebDriver driver) : base(driver)
        {
            //WaitSelector.WaitingFor_ElementExists(this.Driver, By.Id("ContentPlaceHolder1_txtUsername"));
            //Init element.
        }

        #region Page elements
        [FindsBy(How = How.Id, Using = "roster-staff-add-user")]
        protected IWebElement btnAddUser;

        #region add user popup
        //[FindsBy(How = How.Id, Using = "coach-user-first")]
        protected IWebElement txtFirstName { get { return this.Driver.FindElement(By.Id("coach-user-first")); } }

        //[FindsBy(How = How.Id, Using = "coach-user-last")]
        protected IWebElement txtLastName { get { return this.Driver.FindElement(By.Id("coach-user-last")); } }

        //[FindsBy(How = How.Id, Using = "coach-user-last")]
        //protected IWebElement ddlGender; 

        //[FindsBy(How = How.Id, Using = "coach-user-title")]
        protected IWebElement txtTitle { get { return this.Driver.FindElement(By.Id("coach-user-title")); } }

        //[FindsBy(How = How.Id, Using = "coach-user-email")]
        protected IWebElement txtEmailAddress { get { return this.Driver.FindElement(By.Id("coach-user-email")); } }

        //[FindsBy(How = How.Id, Using = "coach-user-phone")]
        protected IWebElement txtPhoneNumber { get { return this.Driver.FindElement(By.Id("coach-user-phone")); } }

        //[FindsBy(How = How.Id, Using = "coach-user-comment")]
        protected IWebElement txtComment { get { return this.Driver.FindElement(By.Id("coach-user-comment")); } }


        //protected const string CST_BTN_ASSIGN_SPORTS = ".//button/span[normalize-space(text())='Assign Sports']";
        //[FindsBy(How = How.XPath, Using = ".//button/span[normalize-space(text())='Assign Sports']")]
        protected IWebElement btnAssignSports { get { return this.Driver.FindElement(By.XPath(".//button/span[normalize-space(text())='Assign Sports']")); } }

        //[FindsBy(How = How.Id, Using = "//div[contains(@class,'k-multiselect-wrap k-floatwrap')]")]
        protected IWebElement ddlChooseSportsInput { get { return this.Driver.FindElement(By.XPath("//*[@id='coach-available-sports_taglist']/parent::*")); } }
        protected SelectElement ddlChooseSportsSelect { get { return (SelectElement) this.Driver.FindElement(By.Id("coach-available-sports")); } }

        protected IWebElement btnPopupAddUser { get { return this.Driver.FindElement(By.XPath(".//button/span[normalize-space(text())='Add User']")); } }
        protected IWebElement btnPopupOk { get { return this.Driver.FindElement(By.XPath(".//button/span[normalize-space(text())='Ok']")); } }
        #endregion add user popup

        #endregion Page elements

        #region actions
        public CoachStaffPage AddNewUser(CoachUserModel model)
        {
            this.btnAddUser.Click();

            //input information.
            WaitSelector.WaitingFor_ElementExists(this.Driver, By.Id("add-coach-user-dialog"));
            this.txtFirstName.SendKeys(model.FirstName);
            this.txtLastName.SendKeys(model.LastName);
            //this.ddlGender.SendKeys(model.Gender);
            this.txtTitle.SendKeys(model.Title);
            this.txtEmailAddress.SendKeys(model.EmailAddress);
            this.txtPhoneNumber.SendKeys(model.PhoneNumber);
            //this.txtPhoneNumberType.SendKeys(model.PhoneNumberType);
            this.txtComment.SendKeys(model.Comment);

            btnAssignSports.Click();

            //ddlChooseSportsInput.Click();
            //ddlChooseSportsInput.SendKeys("Men's Football");
            var action = new Actions(this.Driver);
            action.MoveToElement(ddlChooseSportsInput)
                .Click()
                .SendKeys("Men's Basketball")
                .SendKeys(Keys.Enter)
                .Perform();

            WaitSelector.HardWait(TimeSpan.FromSeconds(1));            
            btnPopupAddUser.Click();
            WaitSelector.HardWait(TimeSpan.FromSeconds(1));
            btnPopupOk.Click();

            return this;
        }
        #endregion actions
    }
}
