using Craftsman.Core;
using Craftsman.Core.Component;
using JumpForward.Common.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class DatabaseClubsPage : CoachPageBase
    {
        protected Link lnkAddClub;
        protected JumpForwardTable tblClubs;

        public IComponent AddClubLink { get { return lnkAddClub; } }


        public DatabaseClubsPage(IWebDriver driver) : base(driver)
        {
            //Init element.
            lnkAddClub = new Link(driver, By.XPath(".//i[contains(@class,'clubs-add-icon')]/parent::span/parent::a"));
            tblClubs = new JumpForwardTable(driver, By.Id("database-grid"));
        }

        #region Action method 
        public DatabaseClubsDetailPage ClickAddClubLink()
        {
            this.lnkAddClub.Click();
            //TO DO: Move to base
            var locator = this.Driver.SwitchTo();
            var windowName = this.Driver.WindowHandles.Last();
            locator.Window(windowName);
            return new DatabaseClubsDetailPage(this.Driver);
        }

        public bool IsExistClub(string clubName)
        {
            bool hasClub = false;
            for (int i = 1; i <= tblClubs.RowCount; i++)
            {
                var cell = tblClubs["Club Name", i];
                if (cell.Text == clubName)
                {
                    hasClub = true;
                }
            }
            return hasClub;
        }
        #endregion


    }

    
}

