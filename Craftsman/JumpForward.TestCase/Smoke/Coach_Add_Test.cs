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
            
            var rosterHomePage = CraftsmanFactory.CreatePageObject<RosterPage>(manager.Driver);
            var rosterCoachesPage = rosterHomePage.RedirectToCocahes();
            var rosterCoachesAddPage = rosterCoachesPage.AddNewCoach();
            var rosterPage = rosterCoachesAddPage.Save();

            rosterPage.Driver.Close();
        }
    }
}
