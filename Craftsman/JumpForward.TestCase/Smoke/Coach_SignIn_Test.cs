using Craftsman.Core.Factory;
using JumpForward.Common.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Linq;
using Xunit;

namespace JumpForward.TestCase
{
    [Trait("Coach", "SignInTest")]
    public class Coach_SignIn_Test
    {
        private const string cst_DisplayName = "BaseCheck.SignIn";

        [Fact(DisplayName = cst_DisplayName + ".Success")]
        public void SignIn_Success()
        {
            //Create manager & Navigate page to Login.
            var manager = CraftsmanFactory.CreateDriverManager();
            manager.NavigateTo(string.Empty);
            var signInPage = CraftsmanFactory.CreatePageObject<CoachSignInPage>(manager.Driver);
            var dbProspectsPage = signInPage.SignIn("demicoach@activenetwork.com", "active");

            dbProspectsPage.NavigationTo("Databases", "Add Prospect");
            dbProspectsPage.NavigationTo("Databases", "Prospects");
            dbProspectsPage.NavigationTo("Email", "Sent");
            dbProspectsPage.Driver.Close();
        }


        public void Demo_Case()
        {
            //var page = RouteMapper.GoTo<IPageObject>();
            //page.
        }

    }
}
