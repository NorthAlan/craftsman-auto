using Craftsman.Core.Component;
using Craftsman.Core.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject.Coach.Compliance.Contact
{
    public class RecruitSummaryReportPage : CoachPageBase
    {
        protected Link linkTitle;
        protected Label lblReportTitle;

        public RecruitSummaryReportPage(IWebDriver driver) : base(driver)
        {
            WaitSelector.WaitingFor_ElementExists(this.Driver, By.XPath(".//*[@id='ui-accordion-ui-accordion-header-0']/a"));

            linkTitle = new Link(driver, By.XPath(".//*[@id='ui-accordion-ui-accordion-header-0']/a"));
            lblReportTitle = new Label(driver, By.Id("cphMain_cphMainContent_ComplianceRPDReport_lblReportTitle"));
        }
    }
}
