using Craftsman.Core;
using Craftsman.Core.Factory;
using Craftsman.Core.Fixture;
using Craftsman.Core.Utilities;
using JumpForward.Common;
using JumpForward.Common.Component;
using JumpForward.Common.Fixture;
using JumpForward.Common.Model;
using JumpForward.Common.PageObject;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace JumpForward.TestCase
{
    [Trait("Coach", "Database.Clubs.Search")]
    public class Coach_DatabaseClubs_Search : JumpForwardTestBase
    {
        public Coach_DatabaseClubs_Search(TestContextFixture context, JumpForwardServiceFixture service) : base(context, service)
        {
            //InitData
        }

        private const string cst_DisplayName = "Database.Clubs.Search";
        private const string cst_TestDataFilePath = "TestData/TestSuiteA";
        

        [Fact(DisplayName = "JF0002." + cst_DisplayName + ".SearchClub")]
        public void JF0002_SearchClub_Filter()
        {
            //-->Data preparation.
            var json = File.ReadAllText($"{cst_TestDataFilePath}/JF0002/Club.json");
            var clubA = JsonConvert.DeserializeObject<ClubModel>(json);
            var clubB = JsonConvert.DeserializeObject<ClubModel>(json);


            var signInPage = Router.GoTo<CoachSignInPage>();
            var dbProspectsPage = signInPage.SignIn("demicoach@activenetwork.com", "active");
            var databaseClubsPage = dbProspectsPage.NavMenu.Select<DatabaseClubsPage>("Databases", "Clubs");

            //-->Actions.
            databaseClubsPage.SelectClubs("JF0001-Club");

            databaseClubsPage.SetSearchClub("JF").SetSearchTeam("Team");
            
            //-->Check Point.
            Assert.Equal("JF", databaseClubsPage.FilterClubName.GetText());
            Assert.Equal("Team", databaseClubsPage.FilterTeamName.GetText());
        }


        [Fact(DisplayName = "JF0003." + cst_DisplayName + ".MergeClub")]
        public void JF0003_MergeClub_SameClub()
        {
            //-->Data preparation.
            var json = File.ReadAllText($"{cst_TestDataFilePath}/JF_0002/Club.json");
            var clubA = JsonConvert.DeserializeObject<ClubModel>(json);
            var clubB = JsonConvert.DeserializeObject<ClubModel>(json);


            var signInPage = Router.GoTo<CoachSignInPage>();
            var dbProspectsPage = signInPage.SignIn("demicoach@activenetwork.com", "active");
            var databaseClubsPage = dbProspectsPage.NavMenu.Select<DatabaseClubsPage>("Databases", "Clubs");


            //-->Actions.
            ////Create ClubA
            //databaseClubsPage = databaseClubsPage.ClickAddClubLink()
            //    .SetClubBaseInformation(clubA)
            //    .SetHeadCoachInformation(clubA)
            //    .ClickSaveButton()
            //    .ClickBackToClubsButton();

            ////Create ClubB
            //databaseClubsPage = databaseClubsPage.ClickAddClubLink()
            //    .SetClubBaseInformation(clubA)
            //    .SetHeadCoachInformation(clubA)
            //    .ClickSaveButton()
            //    .ClickBackToClubsButton();

            databaseClubsPage.SelectClubs("JF0001-Club");

            databaseClubsPage.SetSearchClub("JF").SetSearchTeam("Team");
            //.FilterClubName.Text

            Assert.Equal("JF", databaseClubsPage.FilterClubName.GetText());
            Assert.Equal("Team", databaseClubsPage.FilterTeamName.GetText());
            //MergeClub

            //-->Check Point.
            //Assert.True(databaseClubsPage.IsExistClub(club.Name));
            //Assert.True(databaseClubsPage.AddClubLink.IsExist());
        }
    }
}
