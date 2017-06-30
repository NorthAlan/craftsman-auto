using Craftsman.Core.Factory;
using Craftsman.Core.Tools;
using JumpForward.Common.Component;
using JumpForward.Common.Model;
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

        [Fact(DisplayName = cst_DisplayName + ".Demo_Case_AddCoach")]
        public void Demo_Case_AddCoach()
        {
            var manager = CraftsmanFactory.CreateDriverManager();
            manager.NavigateTo(string.Empty);

            var signInPage = CraftsmanFactory.CreatePageObject<CoachSignInPage>(manager.Driver);
            var dbProspectsPage = signInPage.SignIn("demicoach@activenetwork.com", "active");
            var staffPage = dbProspectsPage.Settings.Select<CoachStaffPage>();

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

            staffPage.AddNewUser(model);
        }

        public void Demo_Case()
        {
            
            /*
             * DataKeeper 数据持有
             * ServiceInvoker 服务调用
             * RouteMapper 路由映射
             * 
             * WorkflowFactory
             * TestContext
             */

            //-->Data preparation.

            //var page01 = RouteMapper.GoTo<IPageObject>();
            //var page02 = page01.SomeAction();

        }

    }
}
