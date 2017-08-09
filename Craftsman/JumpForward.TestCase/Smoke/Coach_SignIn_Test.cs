using Craftsman.Core.Factory;
using JumpForward.Common;
using JumpForward.Common.Component;
using JumpForward.Common.Model;
using JumpForward.Common.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Linq;
using Xunit;
using Craftsman.Core.Fixture;
using RestSharp;
using System.Net;
using System.Xml;
using System.Text.RegularExpressions;
using JumpForward.Common.Fixture;

namespace JumpForward.TestCase
{
    [Trait("Coach", "SignInTest")]
    public class Coach_SignIn_Test : JumpForwardTestBase
    {
        private const string cst_DisplayName = "BaseCheck.SignIn";

        public Coach_SignIn_Test(TestContextFixture context, JumpForwardServiceFixture service) : base(context, service) { }

        [Fact(DisplayName = cst_DisplayName + ".Success")]
        public void SignIn_Success()
        {
            //Create manager & Navigate page to Login.
            var signInPage = Router.GoTo<CoachSignInPage>();
            var dbProspectsPage = signInPage.CoachSignIn("demicoach@activenetwork.com", "active");

            dbProspectsPage.NavMenu.Select("Databases", "Add Prospect");
            dbProspectsPage.NavMenu.Select("Databases", "Prospects");
            dbProspectsPage.NavMenu.Select("Email", "Sent");
            dbProspectsPage.Driver.Close();
        }

        [Fact(DisplayName = cst_DisplayName + ".Demo_Case_AddCoach")]
        public void Demo_Case_AddCoach()
        {
            var model = new CoachUserModel()
            {
                FirstName = "Alan",
                LastName = "L002",
                EmailAddress = "alan.002@null.com",
                Gender = GenderType.Male,
                PhoneNumber = "18600000000",
                Comment = "Comment here.",
                Title = "Test Titile",
                Sports = "Men's Basketball"
                //PhoneNumberType
            };

            var signInPage = Router.GoTo<CoachSignInPage>();
            var dbProspectsPage = signInPage.CoachSignIn("demicoach@activenetwork.com", "active");
            dbProspectsPage.Settings.Select<CoachStaffPage>().AddNewUser(model);
            //var staffPage = dbProspectsPage.Settings.Select<CoachStaffPage>();
            //staffPage.AddNewUser(model);

        }
    }
}
