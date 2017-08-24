﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Craftsman.Core.Component;
using Craftsman.Core.Utilities;
using OpenQA.Selenium;

namespace JumpForward.Common.PageObject.Coach.Compliance.Contact
{ 
    public class EvaluationDaysByProspectPage : CoachPageBase
    {
        protected Link lblTitle;
        protected Link linkBackToDashboard;

        public EvaluationDaysByProspectPage(IWebDriver driver) : base(driver)
        {
            WaitSelector.WaitingFor_ElementExists(this.Driver, By.XPath(".//*[@id='page-container']//span[text()='Back to Dashboard']"));

            lblTitle = new Link(driver, By.XPath(".//*[@id='page-container']//h1[@class='ng-binding']"));
            linkBackToDashboard = new Link(driver, By.XPath(".//*[@id='page-container']//span[text()='Back to Dashboard']"));
        }
    }
}