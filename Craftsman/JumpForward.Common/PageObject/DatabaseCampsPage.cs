using Craftsman.Core;
using Craftsman.Core.Component;
using Craftsman.Core.Tools;
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
    public class DatabaseCampsPage : CoachPageBase
    {
        protected Button btnAddCamp;
        protected Button btnAddTeamCamp;
        protected CheckBox ckbShowArchivedCamps;
        protected JumpForwardTable tblCamps;


        
        public DatabaseCampsPage(IWebDriver driver) : base(driver)
        {
            //Init element.
            btnAddCamp = new Button(driver, By.XPath(".//*[@id='prospectGridWrapper']/button[text()='Add Camp']"));
            btnAddTeamCamp = new Button(driver, By.XPath(".//*[@id='prospectGridWrapper']/button[text()='Add Team Camp']"));
            ckbShowArchivedCamps = new CheckBox(driver, By.Id("ShowArchived"));
            tblCamps = new JumpForwardTable(driver, By.Id("prospectGrid"));
        }

        #region Action method 
        public DatabaseCampsDetailPage ClickAddCampButton()
        {
            this.btnAddCamp.Waiting(For.Clickable);
            this.btnAddCamp.Click();
            return new DatabaseCampsDetailPage(this.Driver);
        }


        #endregion
        public JumpForwardTableCell GetCampByName(string campName)
        {
            return  tblCamps.FindCellByText(campName);
        }

        public bool IsExistCamp(string campName)
        {
            var campCell = tblCamps.FindCellByText(campName);
            return !(campCell == null);
        }

    }

    
}

