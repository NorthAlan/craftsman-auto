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

   public class DatabaseAddProspectPage: CoachPageBase
    {
#region Internal Component
        #region Prospect Details
        protected TextBox txtFirstName;
        protected TextBox txtLastName;
        //protected Select ddlGradYear;
        protected SelectElement ddlGradYear;
        //protected Select ddlRecruitedPosition;
        //protected Select ddlHeight;
        protected TextBox txtWeight;
        protected TextBox txtJersey;
        //protected Select ddlRating;
        //protected Select ddlTag;
        protected TextBox txtTag;
        #endregion Prospect Details

        protected Button btnSaveProspect;

        #endregion Internal component

        public DatabaseAddProspectPage(IWebDriver driver) : base(driver)
        {
            #region Prospect Details
            txtFirstName = new TextBox(driver, By.Id("cphMain_cphMainContent_txtFirstName"));
            txtLastName = new TextBox(driver, By.Id("cphMain_cphMainContent_txtLastName"));
            ddlGradYear = new SelectElement(driver.FindElement(By.Id("cphMain_cphMainContent_ddlGradYear")));
            //ddlRecruitedPosition
            //ddlHeight
            txtWeight = new TextBox(driver, By.Id("cphMain_cphMainContent_txtWeight"));
            txtJersey = new TextBox(driver, By.Id("cphMain_cphMainContent_txtJerseyNumber"));
            //ddlRating
            //ddlTag
            txtTag = new TextBox(driver, By.Id("cphMain_cphMainContent_txtTag"));
            #endregion Prospect Details

            btnSaveProspect = new Button(driver, By.XPath("//*[@id='mainContainer']/div//input[@value='Save Prospect' and @type='button']"));
        }

#region Action Method

        //public DatabaseAddProspectPage SetProspectDetails(ProspectModel prospect)
        //{

        //    return this;
        //}

#endregion Action Method
    }
}
