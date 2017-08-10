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

        #region left pancel
        protected Button btnMergeClubs;
        #endregion left pancel

        public IComponent AddClubLink { get { return lnkAddClub; } }


        public DatabaseClubsPage(IWebDriver driver) : base(driver)
        {
            //Init element.
            lnkAddClub = new Link(driver, By.XPath(".//i[contains(@class,'clubs-add-icon')]/parent::span/parent::a"));
            tblClubs = new JumpForwardTable(driver, By.Id("database-grid"));
            btnMergeClubs = new Button(driver, By.XPath(".//button[contains(.,'Merge Clubs')]"));
            
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

        public DatabaseClubsPage SelectClubs(string name)
        {
            var cells = tblClubs.FindAllCellsByText(name);
            foreach (var cell in cells)
            {
                var prevCell = tblClubs[cell.ColumnIndex - 1, cell.RowIndex];
                var chkBox = prevCell.GetComponent<CheckBox>("input[@type='checkbox']");
                chkBox.SetState(true);
            }
            
            return this;
        }
        #endregion
    }
}