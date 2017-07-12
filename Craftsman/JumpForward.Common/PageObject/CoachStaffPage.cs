using Craftsman.Core;
using Craftsman.Core.Component;
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
    public class CoachStaffPage : CoachPageBase
    {
        public CoachStaffPage(IWebDriver driver) : base(driver)
        {
            //WaitSelector.WaitingFor_PageLoad

            //Init element.
            txtFirstName = new TextBox(driver, By.Id("coach-user-first"));
            txtLastName = new TextBox(driver, By.Id("coach-user-last"));
            txtTitle = new TextBox(driver, By.Id("coach-user-title"));
            txtEmailAddress = new TextBox(driver, By.Id("coach-user-email"));
            txtPhoneNumber = new TextBox(driver, By.Id("coach-user-phone"));
            txtComment = new TextBox(driver, By.Id("coach-user-comment"));

            btnAddUser = new Button(driver, By.Id("roster-staff-add-user"));
            btnAssignSports = new Button(driver, By.XPath(".//button/span[normalize-space(text())='Assign Sports']"));
            btnPopupAddUser = new Button(driver, By.XPath(".//button/span[normalize-space(text())='Add User']"));
            btnPopupOk = new Button(driver, By.XPath(".//button/span[normalize-space(text())='Ok']"));

            misChooseSportsInput = new MutiInputSelect(driver, By.XPath("//*[@id='coach-available-sports_taglist']/parent::*"));

            txaDialogTitleNewCoach = new TextArea(driver, By.XPath("//span[@class='ui-dialog-title' and text()='New Coach Profile Information']"));
            txaChooseSports = new TextArea(driver, By.XPath("//h2[text()='Choose Sports']"));
        }

        #region Page elements
        protected Button btnAddUser;

        #region add user popup
        protected TextBox txtFirstName;
        protected TextBox txtLastName;
        protected TextBox txtTitle;
        protected TextBox txtEmailAddress;
        protected TextBox txtPhoneNumber;
        protected TextBox txtComment;

        protected Button btnAssignSports;
        protected Button btnPopupAddUser;
        protected Button btnPopupOk;

        protected MutiInputSelect misChooseSportsInput;

        protected TextArea txaDialogTitleNewCoach;
        protected TextArea txaChooseSports;
        #endregion add user popup

        #endregion Page elements

        #region actions
        public CoachStaffPage AddNewUser(CoachUserModel model)
        {
            this.btnAddUser.Click();
            InputBaseInformation(model);    //input base information.
            ChooseSports(model);            //choose sports.

            //New Coach Profile Information: Message box.
            btnPopupOk.Waiting(For.Clickable);
            btnPopupOk.Click();

            return this;
        }


        protected void InputBaseInformation(CoachUserModel model)
        {
            txaDialogTitleNewCoach.Waiting(For.Exist);
            this.txtFirstName.SendKeys(model.FirstName);
            this.txtLastName.SendKeys(model.LastName);
            //this.ddlGender.SendKeys(model.Gender);
            this.txtTitle.SendKeys(model.Title);
            this.txtEmailAddress.SendKeys(model.EmailAddress);
            this.txtPhoneNumber.SendKeys(model.PhoneNumber);
            //this.txtPhoneNumberType.SendKeys(model.PhoneNumberType);
            this.txtComment.SendKeys(model.Comment);

            btnAssignSports.Waiting(For.Clickable);
            btnAssignSports.Click();
        }

        protected void ChooseSports(CoachUserModel model)
        {
            txaChooseSports.Waiting(For.Exist);
            misChooseSportsInput.SelectByText(model.Sports);

            btnPopupAddUser.Waiting(For.Clickable);
            btnPopupAddUser.Click();
        }
        #endregion actions
    }
}
