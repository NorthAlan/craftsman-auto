using Craftsman.Core.Factory;
using Craftsman.Core.Fixture;
using JumpForward.Common;
using JumpForward.Common.Fixture;
using JumpForward.Common.Model;
using JumpForward.Common.PageObject;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace JumpForward.TestCase.Smoke
{
    [Trait("Coach", "AddTest")]
    public class Coach_Add_Test : JumpForwardTestBase
    {
        public Coach_Add_Test(TestContextFixture context, JumpForwardServiceFixture service) : base(context, service) { }

        private const string cst_DisplayName = "BaseCheck.Add";

        [Fact(DisplayName = cst_DisplayName + ".Success")]
        public void Add_Success()
        {
            //Create manager & Navigate page to Login. 
            var signInPage = Router.GoTo<CoachSignInPage>();
            var comHomePage = signInPage.ComplianceSignIn("demicompliance@activenetwork.com", "active");

            var rosterHomePage = comHomePage.NavMenu.Select<RosterPage>("Roster", "Football", 18);
            var rosterCoachesPage = rosterHomePage.RedirectToCocahes();

            var json = File.ReadAllText("Smoke/Coach_Add_Test.json");
            var coachUser = JsonConvert.DeserializeObject<CoachUserModel>(json);

            string firstName = coachUser.FirstName;
            string lastName = coachUser.LastName;

            string guid = Guid.NewGuid().ToString().Substring(0, 5);
            string random = Convert.ToString(new Random().Next(1, 100));
            string emial = firstName + "." + lastName + guid + random + "@activetest.com";

            //var rosterHomePage = CraftsmanFactory.CreatePageObject<RosterPage>(manager.Driver);
            var rosterPage = rosterCoachesPage.AddNewCoach(coachUser, emial);
            var rosterCoachesResultPage = rosterHomePage.RedirectToCocahes();

            Assert.True(rosterCoachesResultPage.FindCoachbyEmail(emial));

            //rosterPage.Driver.Close();
        }
    }
}
