using Craftsman.Core.Factory;
using Craftsman.Core.Utilities;
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
        public RosterCoachesAddPage(IWebDriver driver) : base(driver)
        {
            WaitSelector.WaitingFor_ElementExists(this.Driver, By.Id("cphMain_btnUpdate")); 
        }

        #region
        [FindsBy(How = How.Id, Using = "cphMain_txtFirstName")]
        protected IWebElement txtFirstName;

        [FindsBy(How = How.Id, Using = "cphMain_txtMiddleName")]
        protected IWebElement txtMiddleName;

        [FindsBy(How = How.Id, Using = "cphMain_txtLastName")]
        protected IWebElement txtLastName;

        [FindsBy(How = How.Id, Using = "cphMain_radMale")]
        protected IWebElement radMale;

        [FindsBy(How = How.Id, Using = "cphMain_radFemale")]
        protected IWebElement radFemale;

        [FindsBy(How = How.Id, Using = "cphMain_txtTitle")]
        protected IWebElement txtTitle;

        [FindsBy(How = How.Id, Using = "cphMain_txtEmailId")]
        protected IWebElement txtEmail;

        [FindsBy(How = How.Id, Using = "cphMain_txtAddress1")]
        protected IWebElement txtAddress1;

        [FindsBy(How = How.Id, Using = "cphMain_txtAddress2")]
        protected IWebElement txtAddress2;

        [FindsBy(How = How.Id, Using = "cphMain_txtCity")]
        protected IWebElement txtCity;

        [FindsBy(How = How.Id, Using = "cphMain_selCountry")]
        protected IWebElement ddlCountry;

        [FindsBy(How = How.Id, Using = "cphMain_selState")]
        protected IWebElement ddlState;

        [FindsBy(How = How.Id, Using = "cphMain_txtZip")]
        protected IWebElement txtZip;

        [FindsBy(How = How.Id, Using = "cphMain_txtPhone")]
        protected IWebElement txtPhone;

        [FindsBy(How = How.Id, Using = "cphMain_drpStatusForCoach")]
        protected IWebElement ddlStatus;

        [FindsBy(How = How.Id, Using = "cphMain_radAllowSignOnYes")]
        protected IWebElement radAllowSignOnYes;

        [FindsBy(How = How.Id, Using = "cphMain_radAllowSignOnNo")]
        protected IWebElement radAllowSignOnNo;

        [FindsBy(How = How.Id, Using = "cphMain_drpCoachSiteAccess")]
        protected IWebElement ddlCoachSiteAccess;

        [FindsBy(How = How.Id, Using = "cphMain_drpRequestNewCoach")]
        protected IWebElement ddlRequestNewCoach;

        [FindsBy(How = How.Id, Using = "cphMain_drpPlayingSeasonSetup")]
        protected IWebElement ddlPlayingSeasonSetup;

        [FindsBy(How = How.Id, Using = "cphMain_txtComment")]
        protected IWebElement txtComment;

        [FindsBy(How = How.Id, Using = "cphMain_selCoachType")]
        protected IWebElement ddlCoachCategory; 

        [FindsBy(How = How.Id, Using = "cphMain_btnUpdate")]
        protected IWebElement btnSave;

        [FindsBy(How = How.Id, Using = "cphMain_btnBack")]
        protected IWebElement btnBack;
        #endregion

        public RosterPage Back()
        {
            this.btnBack.Click();
            return new RosterPage(this.Driver);
        }

        public RosterPage Save(string firstName, string lastName, string emial)
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

            SelectElement ddlStateSelect = new SelectElement(ddlState);
            ddlStateSelect.SelectByIndex(1);
            SelectElement ddlStatusSelect = new SelectElement(ddlStatus);
            ddlStatusSelect.SelectByText("Active");
            SelectElement ddlAccessSelect = new SelectElement(ddlCoachSiteAccess);
            ddlAccessSelect.SelectByText("Edit");
            SelectElement ddlNewCoachSelect = new SelectElement(ddlRequestNewCoach);
            ddlNewCoachSelect.SelectByText("Full Adding Authority");
            SelectElement ddlPlaySeasonSelect = new SelectElement(ddlPlayingSeasonSetup);
            ddlPlaySeasonSelect.SelectByText("Setup Season");
            SelectElement ddlCoachCategorySelect = new SelectElement(ddlCoachCategory);
            ddlCoachCategorySelect.SelectByText("Head");   
            
            this.btnSave.Click();
            return new RosterPage(this.Driver);
        }
    }
}
