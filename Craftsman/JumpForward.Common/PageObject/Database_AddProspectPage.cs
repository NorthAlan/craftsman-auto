using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Craftsman.Core;
using Craftsman.Core.Component;
using JumpForward.Common.Component;
using JumpForward.Common.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JumpForward.Common.PageObject
{
    public class Database_AddProspectPage : CoachPageBase
    {
        #region Internal Components

        #region Prospect Details 
        protected TextBox txtFirstName;
        protected TextBox txtLastName;
        protected SelectElement ddlGradYear;
        //protected Select ddlGradYear;
        //protected Select ddlRecruitedPosition;
        //protected Select ddlHeight;
        protected TextBox txtWeight;
        protected TextBox txtJersey;
        //protected Select ddlRating;
        //protected Select ddlTag;
        protected TextBox txtTag;
        #endregion Prospect Details

        #region Contact Info
        #endregion Contact Info

        #region School
        #endregion School

        #region Club
        #endregion Club

        protected TextArea txtSuccessMessage;
        protected Link lnkClickHere;
        //Notes
        //save Prospect Button
        protected Button btnSaveProspect;

        //protected TextArea txtSuccessMessage;

        #endregion Internal Components

        public Database_AddProspectPage(IWebDriver driver) : base(driver)
        {
            #region Prospect Details 
            txtFirstName = new TextBox(driver, By.Id("cphMain_cphMainContent_txtFirstName"));
            txtLastName = new TextBox(driver, By.Id("cphMain_cphMainContent_txtLastName"));
            ddlGradYear = new SelectElement(driver.FindElement(By.Id("cphMain_cphMainContent_ddlGradYear")));
            //ddlGradYear = new Select(driver, By.Id("cphMain_cphMainContent_ddlGradYear"));
            //ddlRecruitedPosition = new Select(driver, By.id("cphMain_cphMainContent_selRecruitedPosition"));
            //ddlHeight = new Select(driver, By.Id("cphMain_cphMainContent_selHeight"));
            txtWeight = new TextBox(driver, By.Id("cphMain_cphMainContent_txtWeight"));
            txtJersey = new TextBox(driver, By.Id("cphMain_cphMainContent_txtJerseyNumber"));
            //ddlRating = new Select(driver, By.Id("cphMain_cphMainContent_selRating"));
            //ddlTag = new Select(driver, By.Id("cphMain_cphMainContent_dropTags"));
            this.txtTag = new TextBox(driver, By.Id("cphMain_cphMainContent_txtTag"));
            #endregion Prospect Details

            #region Contact Info
            #endregion Contact Info

            #region School
            #endregion School

            #region Club
            #endregion Club

            //Notes
            //Save Prospect button
            btnSaveProspect = new Button(driver, By.XPath("//*[@id='mainContainer']/div//input[@value='Save Prospect' and @type='button']"));

            //var txtSuccessMessage = new TextArea(driver, By.XPath("//h2[contains(.,'Prospect Saved Successfully - Click Here to view the profile')]"));
            txtSuccessMessage = new TextArea(driver, By.XPath("//h2[contains(.,'Prospect Saved Successfully - Click Here to view the profile')]"));
            lnkClickHere = new Link(driver, By.XPath("//a[contains(.,'Click Here')]"));
        }

        #region Action Methods

        public Database_AddProspectPage SetProspectDetails(ProspectModel prospect)
        {
            // Set prospect details
            txtFirstName.SendKeys(prospect.FirstName);
            txtLastName.SendKeys(prospect.LastName);
            ddlGradYear.SelectByValue(prospect.GradYear);
            //ddlRecruitedPosition.SelectByValue(prospect.RecruitedPosition);
            //ddlHeight.SelectByValue(prospect.Height);
            txtWeight.SendKeys(prospect.Weight);
            txtJersey.SendKeys(prospect.Jersey);
            //ddlRating.SelectByValue(prospect.Rating);
            //ddlTag.SelectByValue(prospect.Tag);
            txtTag.SendKeys(prospect.TagM);
            return this;
        }

        public Database_AddProspectPage ClickSaveProspectButton()
        {
            btnSaveProspect.Click();
            return this;
            //return new Database_AddProspect_SuccessPage(this.Driver);
        }

        public bool IsProspectAddedSuccessfully(ProspectModel prospect)
        {
            var msg = txtSuccessMessage.Text;
            return (msg.Contains("Prospect Saved Successfully") && msg.Contains(prospect.FirstName));
        }

        public DatabaseProspectDetailsPage ClickClickHereButton()
        {
            lnkClickHere.Click();
            return new DatabaseProspectDetailsPage(Driver);
        }

        #endregion Action Methods

    }
}
