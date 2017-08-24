using JumpForward.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Craftsman.Core.Fixture;
using JumpForward.Common.Fixture;
using Xunit;
using JumpForward.Common.PageObject;

namespace JumpForward.TestCase
{
    [Trait("BVT", "Coach.Database")]
    public class CoachDatabaseTest_BVT : JumpForwardTestBase
    {
        public const string cst_DisplayName = "BVT.Coach";
        public CoachDatabaseTest_BVT(TestContextFixture context, JumpForwardServiceFixture service) : base(context, service)
        {

        }

        [Fact(DisplayName = "JF1001." + cst_DisplayName + ".ClubListPage")]
        public void JF1001_ClubListPage_BVT()
        {
            //-->Go to Page.
            var signInPage = Router.GoTo<CoachSignInPage>();
            var objPage = signInPage.SignIn("demicoach@activenetwork.com", "active").NavMenu.Select<CoachDatabaseClubsPage>("Databases", "Clubs");

            //-->Check Point.
            Assert.True(objPage.SearchClubTextBox.IsExist());
            Assert.True(objPage.SearchTeamTextBox.IsExist());
            Assert.True(objPage.ClubsList.ColumnNames.Contains("Club Name"));
            Assert.True(objPage.ClubsList.ColumnNames.Contains("Team Name"));
            Assert.True(objPage.ClubsList.ColumnNames.Contains("City"));
            Assert.True(objPage.ClubsList.ColumnNames.Contains("State"));
            Assert.True(objPage.ClubsList.ColumnNames.Contains("Coach Name"));
            Assert.True(objPage.ClubsList.ColumnNames.Contains("Phone"));
            Assert.True(objPage.ClubsList.ColumnNames.Contains("Email"));
            Assert.True(objPage.ClubsList.ColumnNames.Contains("# of Prospects"));

            objPage.Settings.Logout();
        }

        [Fact(DisplayName = "JF1002." + cst_DisplayName + ".ClubDetailPage")]
        public void JF1002_ClubDetailPage_BVT()
        {
            //-->Go to Page.
            var signInPage = Router.GoTo<CoachSignInPage>();
            var objPage = signInPage
                .SignIn("demicoach@activenetwork.com", "active")
                .NavMenu.Select<CoachDatabaseClubsPage>("Databases", "Clubs").ClickAddClubLink();

            //-->Check Point.
            Assert.True(objPage.ClubNameTextBox.IsExist());
            Assert.True(objPage.TeamNameTextBox.IsExist());
            Assert.True(objPage.AddressLine1TextBox.IsExist());
            Assert.True(objPage.AddressLine2TextBox.IsExist());
            Assert.True(objPage.AddressLine3TextBox.IsExist());
            Assert.True(objPage.CityTextBox.IsExist());
            Assert.True(objPage.CountyTextBox.IsExist());
            Assert.True(objPage.CountryDropDownList.IsExist());
            Assert.True(objPage.StateDropDownList.IsExist());
            Assert.True(objPage.ZipCodeTextBox.IsExist());
            Assert.True(objPage.ClubWebsiteTextBox.IsExist());
            Assert.True(objPage.MainPhoneNumberTextBox.IsExist());
            Assert.True(objPage.SeasonRecordTextBox.IsExist());
            Assert.True(objPage.RecentGameResultsTextBox.IsExist());
            objPage.Settings.Logout();
        }
    }
}
