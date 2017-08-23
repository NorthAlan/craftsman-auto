using Craftsman.Core.Factory;
using Craftsman.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class RosterPage : PageObjectBase
    {
        public RosterPage(IWebDriver driver) : base(driver)
        {
            WaitSelector.WaitingFor_ElementExists(this.Driver, By.Id("tabsRoster"));
        }

        #region Page elements
        [FindsBy(How = How.Id, Using = "atabNewRoster")]
        protected IWebElement tabRoster;

        [FindsBy(How = How.Id, Using = "atabCoaches")]
        protected IWebElement tabCoaches;
        #endregion Page elements

        /// <summary>
        /// RedirectToCocahes
        /// </summary>
        /// <returns>RosterCoachesPage</returns>
        public RosterCoachesPage RedirectToCocahes()
        {
            this.tabCoaches.Click();
            return new RosterCoachesPage(this.Driver);
        }
    }
}
