using Craftsman.Core.Component;
using Craftsman.Core.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject.Coach.Compliance
{
    public class ContactSubmitToCompliancePage : CoachPageBase
    {
        protected Link linkAddNewReport;
        protected Link linkBackToDashboard;
        protected Label lblCount;
        protected Table tableReportSubmission;

        public ContactSubmitToCompliancePage(IWebDriver driver) : base(driver)
        {
            WaitSelector.WaitingFor_ElementExists(this.Driver, By.XPath(".//*[@id='page-container']//span[text()='Add New Report Submission']"));

            linkAddNewReport = new Link(driver, By.XPath(".//*[@id='page-container']//span[text()='Add New Report Submission']"));
            linkBackToDashboard = new Link(driver, By.XPath(".//*[@id='page-container']//span[text()='Back to Dashboard']"));
            lblCount = new Label(driver, By.XPath(".//*[@id='page-container']//div[contains(text(),'Count')]"));
            //tableReportSubmission = new Table(driver,By.XPath("//div[@class='k-grid-content']/table"));
        }
    }
}
