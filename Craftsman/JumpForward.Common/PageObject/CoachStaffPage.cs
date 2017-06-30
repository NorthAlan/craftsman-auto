using Craftsman.Core.Component;
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
            //WaitSelector.WaitingFor_PageLoad

            //Init element.
            txtFirstName = new TextInput(driver, By.Id("coach-user-first"));
            txtLastName = new TextInput(driver, By.Id("coach-user-last"));
            txtTitle = new TextInput(driver, By.Id("coach-user-title"));
            txtEmailAddress = new TextInput(driver, By.Id("coach-user-email"));
            txtPhoneNumber = new TextInput(driver, By.Id("coach-user-phone"));
            txtComment = new TextInput(driver, By.Id("coach-user-comment"));

            btnAddUser = new Button(driver, By.Id("roster-staff-add-user"));
            btnAssignSports = new Button(driver, By.XPath(".//button/span[normalize-space(text())='Assign Sports']"));
            btnPopupAddUser = new Button(driver, By.XPath(".//button/span[normalize-space(text())='Add User']"));
            btnPopupOk = new Button(driver, By.XPath(".//button/span[normalize-space(text())='Ok']"));

        }

        #region Page elements
        protected Button btnAddUser;

        #region add user popup
        protected TextInput txtFirstName;
        protected TextInput txtLastName;
        protected TextInput txtTitle;
        protected TextInput txtEmailAddress;
        protected TextInput txtPhoneNumber;
        protected TextInput txtComment;

        protected Button btnAssignSports;
        protected Button btnPopupAddUser;
        protected Button btnPopupOk;

        //[FindsBy(How = How.Id, Using = "coach-user-last")]
        //protected IWebElement ddlGender; 

        //[FindsBy(How = How.Id, Using = "//div[contains(@class,'k-multiselect-wrap k-floatwrap')]")]
        protected IWebElement ddlChooseSportsInput { get { return this.Driver.FindElement(By.XPath("//*[@id='coach-available-sports_taglist']/parent::*")); } }
        protected SelectElement ddlChooseSportsSelect { get { return (SelectElement) this.Driver.FindElement(By.Id("coach-available-sports")); } }
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

            var action = new Actions(this.Driver);
            action.MoveToElement(ddlChooseSportsInput)
                .Click()
                .SendKeys("Men's Basketball")
                .SendKeys(Keys.Enter)
                .Perform();

            WaitSelector.HardWait(TimeSpan.FromSeconds(3));            
            btnPopupAddUser.Click();
            WaitSelector.HardWait(TimeSpan.FromSeconds(3));
            btnPopupOk.Click();

            return this;
        }
        #endregion actions
    }
}
