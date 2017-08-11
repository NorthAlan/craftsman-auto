using Craftsman.Core;
using Craftsman.Core.Component;
using Craftsman.Core.Utilities;
using JumpForward.Common.Component;
using JumpForward.Common.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class DatabaseClubsDetailPage : CoachPageBase
    {
        #region Internal component

        #region Base information
        protected TextBox txtClubName;
        protected TextBox txtTeamName;
        protected TextBox txtLocationName;
        protected TextBox txtAddressLine1;
        protected TextBox txtAddressLine2;
        protected TextBox txtAddressLine3;
        protected TextBox txtCity;
        protected TextBox txtCounty;
        protected Select ddlCountry;
        protected Select ddlState;
        protected TextBox txtZipCode;
        protected TextBox txtClubWebsite;
        protected TextBox txtMainPhoneNumber;
        protected TextBox txtSeasonRecord;
        protected TextBox txtRecentGameResults;
        #endregion Base information

        #region Head Coach
        protected TextBox txtHeadCoachTitle;
        protected TextBox txtHeadCoachFirstName;
        protected TextBox txtHeadCoachLastName;
        protected TextBox txtHeadCoachSuffix;
        protected TextBox txtHeadCoachHomePhone;
        protected TextBox txtHeadCoachMobilePhone;
        protected TextBox txtHeadCoachOfficePhone;
        protected TextBox txtHeadCoachEmail;
        #endregion  Head Coach

        #region Other
        protected Button btnSaveTeam;
        protected Button btnBackToClubs;
        #endregion Other

        #endregion Internal component

        public DatabaseClubsDetailPage(IWebDriver driver) : base(driver)
        {
            //Init element.
            #region Base information 
            txtClubName = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtName"));
            //txtClubName = new TextBox(driver, By.XPath(".//input[@id='cphMain_clubDetails_fvClub_txtName']"));
            txtTeamName = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtLeague"));
            txtLocationName = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtLocation"));
            txtAddressLine1 = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtAddress1"));
            txtAddressLine2 = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtAddress2"));
            txtAddressLine3 = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtAddress3"));
            txtCity = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtCity"));
            txtCounty = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtCounty"));
            ddlCountry = new Select(driver, By.Id("cphMain_clubDetails_fvClub_ddlCountry"));
            ddlState = new Select(driver, By.Id("cphMain_clubDetails_fvClub_ddlState"));
            txtZipCode = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtZip"));
            txtClubWebsite = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtWebSite"));
            txtMainPhoneNumber = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_TextBox9"));
            txtSeasonRecord = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtSeasonRecord"));
            txtRecentGameResults = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtRecentGameResults"));
            #endregion Base information 

            #region Head coach information 
            txtHeadCoachTitle = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_TextBox7"));
            txtHeadCoachFirstName = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtFirstName"));
            txtHeadCoachLastName = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtLastName"));
            txtHeadCoachSuffix = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_TextBox8"));
            txtHeadCoachHomePhone = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtPhone"));
            txtHeadCoachMobilePhone = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_txtPhone2"));
            txtHeadCoachOfficePhone = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_TextBox4"));
            txtHeadCoachEmail = new TextBox(driver, By.Id("cphMain_clubDetails_fvClub_TextBox2"));
            #endregion Head coach information

            btnSaveTeam = new Button(driver, By.Id("cphMain_clubDetails_fvClub_btnInsert"));
            btnBackToClubs = new Button(driver, By.Id("btnBack"));
            
        }

        #region Action method 
        public DatabaseClubsDetailPage SetClubBaseInformation(ClubModel club)
        {
            txtClubName.SendKeys(club.Name);
            txtTeamName.SendKeys(club.TeamName);
            txtLocationName.SendKeys(club.Address.LocationName);
            txtAddressLine1.SendKeys(club.Address.AddressLine1);
            txtAddressLine2.SendKeys(club.Address.AddressLine2);
            txtAddressLine3.SendKeys(club.Address.AddressLine3);
            txtCity.SendKeys(club.Address.City);
            txtCounty.SendKeys(club.Address.County);
            ddlCountry.SelectByText(club.Address.Country);
            WaitSelector.HardWait(TimeSpan.FromSeconds(5));
            ddlState.SelectByText(club.Address.State);
            txtZipCode.SendKeys(club.Address.ZipCode);
            txtClubWebsite.SendKeys(club.ClubWebsite);
            txtMainPhoneNumber.SendKeys(club.MainPhoneNumber);
            txtSeasonRecord.SendKeys(club.SeasonRecord);
            txtRecentGameResults.SendKeys(club.RecentGameResults);
            return this;
        }

        public DatabaseClubsDetailPage SetHeadCoachInformation(ClubModel club)
        {
            SetHeadCoachInformation(club.HeadCoach);
            return this;
        }

        public DatabaseClubsDetailPage SetHeadCoachInformation(ClubHeadCoach coach)
        {
            txtHeadCoachTitle.SendKeys(coach.Title);
            txtHeadCoachFirstName.SendKeys(coach.FirstName);
            txtHeadCoachLastName.SendKeys(coach.LastName);
            txtHeadCoachSuffix.SendKeys(coach.Suffix);
            txtHeadCoachHomePhone.SendKeys(coach.HomePhone);
            txtHeadCoachMobilePhone.SendKeys(coach.MobilePhone);
            txtHeadCoachOfficePhone.SendKeys(coach.OfficePhone);
            txtHeadCoachEmail.SendKeys(coach.Email);
            return this;
        }

        public DatabaseClubsDetailPage ClickSaveButton()
        {
            btnSaveTeam.Click();
            WaitSelector.WaitingFor_UrlContains(this.Driver, "ClubDetail.aspx?initialaction=view");
            return this;
        }

        public DatabaseClubsPage ClickBackToClubsButton()
        {
            btnBackToClubs.Click();
            return new DatabaseClubsPage(this.Driver);
        }

        #endregion Action method
    }
}
