using Craftsman.Core.Factory;
using Craftsman.Core.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class ComplianceHomePage : CompliancePageBase
    {
        public ComplianceHomePage(IWebDriver driver) : base(driver)
        {
            WaitSelector.WaitingFor_ElementExists(this.Driver, By.Id("divCoachDashboard"));
        }


    }
}
