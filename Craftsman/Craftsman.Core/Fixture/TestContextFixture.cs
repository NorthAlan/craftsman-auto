using Craftsman.Core.Factory;
using Craftsman.Core.Manager;
using Craftsman.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core.Fixture
{
    public class TestContextFixture : IDisposable
    {
        /// <summary>
        /// Get driver manager
        /// </summary>
        public IDriverManager DriverManager { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        public RouteMapper RouteMapper { get; private set; }

        /// <summary>
        /// Create browser driver
        /// </summary>
        public TestContextFixture()
        {
            //Create Browser driver.
            var driverManager = CraftsmanFactory.CreateDriverManager();
            if (this.DriverManager != null)
            {
                var options = this.DriverManager.Driver.Manage();
                options.Cookies.AddCookie(new OpenQA.Selenium.Cookie("wm-ASRep-14-39814", "1"));
                options.Cookies.AddCookie(new OpenQA.Selenium.Cookie("wm-ASRep-14-45441", "1"));
                options.Window.Maximize();
            }

            //build router.
            var routeMapper = new RouteMapper(driverManager.Driver);
            
            //set data.
            this.DriverManager = driverManager;
            this.RouteMapper = routeMapper;

        }

        protected virtual void OnDispose() { }
        public void Dispose()
        {
            OnDispose();
            //Close browser driver.
            if (this.DriverManager != null && this.DriverManager.Driver != null)
            {
                this.DriverManager.Driver.Close();
            }
        }
    }
}
