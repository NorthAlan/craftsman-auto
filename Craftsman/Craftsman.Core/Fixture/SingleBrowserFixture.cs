using Craftsman.Core.Factory;
using Craftsman.Core.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core.Fixture
{
    public class SingleBrowserFixture : IDisposable
    {
        /// <summary>
        /// Get drover manager
        /// </summary>
        public IDriverManager DriverManager { get; protected set; }
        /// <summary>
        /// Create browser driver
        /// </summary>
        public SingleBrowserFixture()
        {
            //Create Browser driver.
            this.DriverManager = CraftsmanFactory.CreateDriverManager();
            if (this.DriverManager != null)
            {
                this.DriverManager.Driver.Manage().Window.Maximize();
            }
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
