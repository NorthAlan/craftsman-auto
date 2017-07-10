using Craftsman.Core;
using Craftsman.Core.Fixture;
using Craftsman.Core.Manager;
using Craftsman.Core.Utilities;
using JumpForward.Common.PageObject;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JumpForward.Common
{
    public class JumpForwardTestBase : CraftsmanTestBase, IClassFixture<SingleBrowserFixture>
    {
        protected IDriverManager driverManager { get; set; }

        public JumpForwardTestBase(SingleBrowserFixture fixture)
        {
            driverManager = fixture.DriverManager;
            base.Initialization();
        }

        public override void InitializationDataKeeper()
        {
            //throw new NotImplementedException();
        }

        public override void InitializationRouteMapper()
        {
            if (TestContainer.Router != null) { return; }

            var strAppNameCoach = "AppAlias.Coach";
            var strAppNameElevation = "AppAlias.Elevation";
            var routeMapper = new RouteMapper(driverManager.Driver);

            //TODO: load for config @.Set up baseUrl 

            /*
             * <environments>
             *      <environment name="QA">
             *          <baseUrl name="AppAlias.Coach" url="https://college-china.jumpforward.com" />
             *          <baseUrl name="AppAlias.Elevation" url="http://elevation-test.jumpforward.com" />
             *      </environment>
             * </environments>
             */
            routeMapper.SetUpBaseUrl(strAppNameCoach, "https://college-china.jumpforward.com");
            routeMapper.SetUpBaseUrl(strAppNameElevation, "http://elevation-test.jumpforward.com");

            //@.Set up page object
            routeMapper.SetUpPageObject(typeof(CoachSignInPage), string.Empty, strAppNameCoach);
            routeMapper.SetUpPageObject(typeof(DatabaseProspectsPage), "/coach/Prospects", strAppNameCoach);

            TestContainer.Router = routeMapper;
        }

        public override void InitializationServiceInvoker()
        {
            //throw new NotImplementedException();
        }

        public override void InitializationTestContext()
        {
            //throw new NotImplementedException();
        }
    }
}

