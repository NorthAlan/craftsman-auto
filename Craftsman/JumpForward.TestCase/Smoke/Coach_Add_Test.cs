using Craftsman.Core.Factory;
using JumpForward.Common.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Linq;
using Xunit;

namespace JumpForward.TestCase.Smoke
{
    [Trait("Coach", "AddTest")]
    public class Coach_Add_Test
    {
        private const string cst_DisplayName = "BaseCheck.Add";

        [Fact(DisplayName = cst_DisplayName + ".Success")]
        public void Add_Success()
        {
            //Create manager & Navigate page to Login.
            var manager = CraftsmanFactory.CreateDriverManager();
            manager.NavigateTo(string.Empty);
            var signInPage = CraftsmanFactory.CreatePageObject<CoachSignInPage>(manager.Driver);
            var comHomePage = signInPage.ComplianceSignIn("demicompliance@activenetwork.com", "active");

            comHomePage.NavigationTo("Roster", "Football", 18);

            string firstName = "Clark";
            string lastName = "Peng";

            string guid = Guid.NewGuid().ToString().Substring(0, 5);
            string random = Convert.ToString(new Random().Next(1, 100));
            string emial = firstName + "." + lastName + guid + random + "@activetest.com";

            var rosterHomePage = CraftsmanFactory.CreatePageObject<RosterPage>(manager.Driver);
            var rosterCoachesPage = rosterHomePage.RedirectToCocahes();
            var rosterPage = rosterCoachesPage.AddNewCoach(firstName, lastName, emial);
            var rosterCoachesResultPage = rosterHomePage.RedirectToCocahes();
            rosterCoachesResultPage.FindCoachbyEmail(emial);

            rosterPage.Driver.Close();
        }
    }
}
