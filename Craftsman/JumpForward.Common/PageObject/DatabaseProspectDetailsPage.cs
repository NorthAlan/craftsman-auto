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
    public class DatabaseProspectDetailsPage : CoachPageBase
    {
        #region Internal Components
        protected TextArea txtPlayerName;
        protected TextArea txtPlayerYear;
        #endregion Internal Components

        public DatabaseProspectDetailsPage(IWebDriver driver) : base(driver)
        {
            txtPlayerName = new TextArea(driver, By.Id("recruitName"));
            txtPlayerYear = new TextArea(driver, By.Id("playerYear"));
        }

        #region Action Methods
        public bool IsProspectNameShown(ProspectModel prospect)
        {
            return (txtPlayerName.Text == (prospect.FirstName + " " + prospect.LastName));
        }
        #endregion Action Methods

    }
}
