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
    [Trait("Coach", "Database.Clubs")]
    public class Coach_DatabaseClubs_Test : JumpForwardTestBase
    {
        public Coach_DatabaseClubs_Test(TestContextFixture context, JumpForwardServiceFixture service) : base(context, service) { }

        private const string cst_DisplayName = "Coach.Database.Clubs";
        private const string cst_TestDataFilePath = "TestData/TestSuiteA";
        

        [Fact(DisplayName = "JF0001."+ cst_DisplayName + ".CreateClub")]
        public void JF0001_CreateClub()
        {
            //-->Data preparation.
            var json = File.ReadAllText($"{cst_TestDataFilePath}/JF_0001/data01.json");
            var club = JsonConvert.DeserializeObject<ClubModel>(json);

            var signInPage = Router.GoTo<CoachSignInPage>();
            var dbProspectsPage = signInPage.SignIn("demicoach@activenetwork.com", "active");
            var databaseClubsPage = dbProspectsPage.NavMenu.Select<DatabaseClubsPage>("Databases", "Clubs");


            //-->Actions.
            /*You can custom this 'Workflow'*/
            databaseClubsPage = databaseClubsPage.ClickAddClubLink()
                .SetClubBaseInformation(club)
                .SetHeadCoachInformation(club)
                .ClickSaveButton()
                .ClickBackToClubsButton();

            //-->Check Point.
            Assert.True(databaseClubsPage.IsExistClub(club.Name));
            Assert.True(databaseClubsPage.AddClubLink.IsExist());
        }
    }
}
