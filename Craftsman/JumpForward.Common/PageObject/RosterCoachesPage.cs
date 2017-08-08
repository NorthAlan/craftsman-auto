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

        [FindsBy(How = How.Id, Using = "rosterCoachGrid")]
        protected IWebElement tableCoach;

        [FindsBy(How = How.XPath, Using = "//table[@id='rosterCoachGrid']/tbody/tr")]
        protected IWebElement tableCoachRows;



        #endregion

        /// <summary>
        /// AddNewCoach
        /// </summary>
        /// <returns>RosterCoachesAddPage</returns>
        public RosterPage AddNewCoach(string firstName, string lastName, string emial)
        {
            this.btnAddCoach.Click();
            this.btnAddNewCoach.Click();
            RosterCoachesAddPage rosterCoachesAddPage = new RosterCoachesAddPage(this.Driver);
            RosterPage rosterPage = rosterCoachesAddPage.Save(firstName, lastName, emial);
            
            return rosterPage;
        }

        public bool FindCoachbyEmail(string email)
        { 
            var emial = string.Format("//table[@id='rosterCoachGrid']/tbody/tr/td[text()='{0}']", email);

            try
            {
                this.Driver.FindElement(By.XPath(emial));
                return true;
            }
            catch(NoSuchElementException ex)
            {
                return false;
            }
             
        }

    }
}
