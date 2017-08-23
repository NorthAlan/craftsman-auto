using Craftsman.Core.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject.Coach.Compliance
{
    public class ContactSubmitToCompliance: CoachPageBase
    {
        public ContactSubmitToCompliance(IWebDriver driver) : base(driver)
        {
            WaitSelector.WaitingFor_ElementExists(this.Driver, By.Id(""));
        }
    }
}
