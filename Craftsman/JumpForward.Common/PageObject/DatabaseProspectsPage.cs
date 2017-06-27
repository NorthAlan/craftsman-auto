using Craftsman.Core.Tools;
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
    public class DatabaseProspectsPage : CoachPageBase
    {
        public DatabaseProspectsPage(IWebDriver driver) : base(driver)
        {
            var btnGotIt = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(driver, By.XPath("//span[contains(.,'Ok, got it')]"));
            if (btnGotIt.Displayed) {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                btnGotIt.Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}
