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
    public class JumpForwardTestBase : IClassFixture<TestContextFixture>
    {
        #region 
        private IDriverManager _driverManager { get; set; }
        private RouteMapper _routeMapper { get; set; }

        public IWebDriver Driver { get { return this._driverManager.Driver; } }
        public RouteMapper Router { get { return this._routeMapper; } }
        #endregion


        public JumpForwardTestBase(TestContextFixture context)
        {
            this._driverManager = context.DriverManager;
            this._routeMapper = context.RouteMapper;

            InitializationRouteMapper();
        }

        public void InitializationDataKeeper()
        {
            //throw new NotImplementedException();
        }

        public void InitializationRouteMapper()
        {
            var strAppNameCoach = "AppAlias.Coach";
            var strAppNameElevation = "AppAlias.Elevation";

            //TODO: load for config @.Set up baseUrl 

            /*
             * <environments>
             *      <environment name="QA">
             *          <baseUrl name="AppAlias.Coach" url="https://college-china.jumpforward.com" />
             *          <baseUrl name="AppAlias.Elevation" url="http://elevation-test.jumpforward.com" />
             *      </environment>
             * </environments>
             */
            this._routeMapper.SetUpBaseUrl(strAppNameCoach, "https://college-china.jumpforward.com");
            this._routeMapper.SetUpBaseUrl(strAppNameElevation, "http://elevation-test.jumpforward.com");

            //@.Set up page object
            this._routeMapper.SetUpPageObject(typeof(CoachSignInPage), string.Empty, strAppNameCoach);
            this._routeMapper.SetUpPageObject(typeof(DatabaseProspectsPage), "/coach/Prospects", strAppNameCoach);

        }

        public void InitializationServiceInvoker()
        {
            //throw new NotImplementedException();
            //TestContainer.ServiceInvoker = ServiceInvoker;
        }

        public void InitializationTestContext()
        {
            //throw new NotImplementedException();
        }
    }
}

