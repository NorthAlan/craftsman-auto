using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Craftsman.Core;
using Craftsman.Core.Component;
using Craftsman.Core.Fixture;
using Craftsman.Core.Factory;
using Craftsman.Core.Utilities;
using JumpForward.Common;
using JumpForward.Common.Component;
using JumpForward.Common.Model;
using JumpForward.Common.PageObject;

namespace JumpForward.TestCase
{
    [Trait("Coach", "Prospects")]
    public class Coach_AddProspect_Test : JumpForwardTestBase
    {

        public Coach_AddProspect_Test(TestContextFixture context) : base(context)
        {
        }

        private const string cst_DisplayName = "Coach_AddProspect";

        [Fact(DisplayName = cst_DisplayName + ".Success")]
        public void Demo_Case_AddProspect()
        {
            // Data Preparation
            var prospect = new ProspectModel()
            {
                FirstName = $"Demi-{DateTime.Now.Ticks}",
                LastName = "ZhangT",
                GradYear = "2019",
                RecruitedPosition = string.Empty,
                Height = string.Empty,
                Weight = string.Empty,
                Jersey = string.Empty,
                Rating = string.Empty,
                Tag = string.Empty,
                TagM = string.Empty
            };

            // Sign in Coach portal and go to Add Prospect page
            var signInPage = Router.GoTo<CoachSignInPage>();
            var dbProspectPage = signInPage.SignIn("demicoach@activenetwork.com", "active");
            var addProspectPage = dbProspectPage.NavMenu.Select<Database_AddProspectPage>("Databases", "Add Prospect");

            // add prospect
            var addProspectSuccessPage = addProspectPage.SetProspectDetails(prospect)
                .ClickSaveProspectButton();

            Assert.True(addProspectSuccessPage.IsProspectAddedSuccessfully(prospect));

            //var prospectDetailsPage = addProspectSuccessPage.ClickClickHereButton();

            //Assert.True(prospectDetailsPage.IsProspectNameShown(prospect));

        }

    }
}
