using Craftsman.Core.Factory;
using Craftsman.Core.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class RosterCoachesPage: PageObjectBase
    {
        public RosterCoachesPage(IWebDriver driver) : base(driver)
        {
            WaitSelector.WaitingFor_ElementExists(this.Driver, By.Id("bttnMainCoachAdd"));
        }

        #region
        /// <summary>
        /// btnAddCoach
        /// </summary>
        [FindsBy(How = How.Id, Using = "bttnMainCoachAdd")]
        protected IWebElement btnAddCoach;


        [FindsBy(How = How.Id, Using = "bttnCoachAdd")]
        protected IWebElement btnAddNewCoach;



        #endregion


        public RosterCoachesAddPage AddNewCoach()
        {
            btnAddCoach.Click();
            btnAddNewCoach.Click();
            //Continue......Todo
            return new RosterCoachesAddPage(this.Driver);
        }

    }
}
