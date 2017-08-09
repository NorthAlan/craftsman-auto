using Craftsman.Core.Factory;
using Craftsman.Core.Utilities;
using Craftsman.Core.Component;
using JumpForward.Common.Component;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class RosterCoachesAddPage : PageObjectBase
    {
        #region
        protected TextBox txtFirstName; 
        protected TextBox txtMiddleName; 
        protected TextBox txtLastName; 
        protected RadioButton radMale; 
        protected RadioButton radFemale;
        protected TextBox txtTitle; 
        protected TextBox txtEmail;        
        protected TextBox txtAddress1;        
        protected TextBox txtAddress2;        
        protected TextBox txtCity;
        protected Select ddlCountry;
        protected Select ddlState;
        protected TextBox txtZip;
        protected TextBox txtPhone;
        protected Select ddlStatus;
        protected RadioButton radAllowSignOnYes;
        protected RadioButton radAllowSignOnNo;
        protected Select ddlCoachSiteAccess;
        protected Select ddlRequestNewCoach;
        protected Select ddlPlayingSeasonSetup;
        protected TextBox txtComment;
        protected Select ddlCoachCategory;
        protected Button btnSave;
        protected Button btnBack;
        #endregion

        public RosterCoachesAddPage(IWebDriver driver) : base(driver)
        {
            WaitSelector.WaitingFor_ElementExists(driver, By.Id("cphMain_btnUpdate"));

            txtFirstName = new TextBox(driver, By.Id("cphMain_txtFirstName"));
            txtMiddleName = new TextBox(driver, By.Id("cphMain_txtMiddleName"));
            txtLastName = new TextBox(driver, By.Id("cphMain_txtLastName"));
            radMale = new RadioButton(driver, By.Id("cphMain_radMale"));
            radFemale = new RadioButton(driver, By.Id("cphMain_radFemale"));
            txtTitle = new TextBox(driver, By.Id("cphMain_txtTitle"));
            txtEmail = new TextBox(driver, By.Id("cphMain_txtEmailId"));
            txtAddress1 = new TextBox(driver, By.Id("cphMain_txtAddress1"));
            txtAddress2 = new TextBox(driver, By.Id("cphMain_txtAddress2"));
            txtCity = new TextBox(driver, By.Id("cphMain_txtCity"));
            ddlCountry = new Select(driver, By.Id("cphMain_selCountry"));
            ddlState = new Select(driver, By.Id("cphMain_selState"));
            txtZip = new TextBox(driver, By.Id("cphMain_txtZip"));
            txtPhone = new TextBox(driver, By.Id("cphMain_txtPhone"));
            ddlStatus = new Select(driver, By.Id("cphMain_drpStatusForCoach"));
            radAllowSignOnYes = new RadioButton(driver, By.Id("cphMain_radAllowSignOnYes"));
            radAllowSignOnNo = new RadioButton(driver, By.Id("cphMain_radAllowSignOnNo"));
            ddlCoachSiteAccess = new Select(driver, By.Id("cphMain_drpCoachSiteAccess"));
            ddlRequestNewCoach = new Select(driver, By.Id("cphMain_drpRequestNewCoach"));
            ddlPlayingSeasonSetup = new Select(driver, By.Id("cphMain_drpPlayingSeasonSetup"));
            txtComment = new TextBox(driver, By.Id("cphMain_txtComment"));
            ddlCoachCategory = new Select(driver, By.Id("cphMain_selCoachType"));
            btnSave = new Button(driver, By.Id("cphMain_btnUpdate"));
            btnBack = new Button(driver, By.Id("cphMain_btnBack"));
        }

        public RosterCoachesAddPage SetCoachInfo(string firstName, string lastName, string emial)
        {
            this.txtFirstName.SendKeys(firstName);
            this.txtMiddleName.SendKeys("A");
            this.txtLastName.SendKeys(lastName);
            this.radMale.Click();
            this.txtTitle.SendKeys("Automation Test");
            this.txtEmail.SendKeys(emial);
            this.txtAddress1.SendKeys(firstName + " Home");
            this.txtCity.SendKeys("Test City");
            this.txtZip.SendKeys("56894");
            this.radAllowSignOnYes.Click();
            this.ddlState.SelectByText("Illinois");
            this.ddlStatus.SelectByText("Active");
            this.ddlCoachSiteAccess.SelectByText("Edit");
            this.ddlRequestNewCoach.SelectByText("Full Adding Authority");
            this.ddlPlayingSeasonSetup.SelectByText("Setup Season");
            this.ddlCoachCategory.SelectByText("Head");
            return this;
        }

        public RosterPage Back()
        {
            this.btnBack.Click();
            return new RosterPage(this.Driver);
        }

        public RosterPage Save()
        {   
            this.btnSave.Click();
            return new RosterPage(this.Driver);
        }
    }
}
