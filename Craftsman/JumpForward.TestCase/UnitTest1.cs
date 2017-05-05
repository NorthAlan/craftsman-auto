using Craftsman.Core.Factory;
using JumpForward.PageObject;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Linq;
using Xunit;

namespace JumpForward.TestCase
{
    [Trait("Coach", "SignInTest")]
    public class Coach_SignIn_Success_Test
    {
        private const string cst_DisplayName = "BaseCheck.SignIn";

        [Fact(DisplayName = cst_DisplayName + ".Success")]
        public void SignIn_Success()
        {
            //Create manager & Navigate page to Login.
            var manager = CraftsmanFactory.CreateDriverManager();
            manager.NavigateTo(string.Empty);
            var objPage = CraftsmanFactory.CreatePageObject<CoachSignInPage>(manager.Driver);
            objPage.SignIn("demicoach@activenetwork.com", "active");
            objPage.Driver.Close();
        }

    }
}
