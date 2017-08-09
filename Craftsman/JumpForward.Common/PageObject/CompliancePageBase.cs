using Craftsman.Core.Factory;
using Craftsman.Core.Utilities;
using JumpForward.Common.Component;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class CompliancePageBase: PageObjectBase
    { 
        protected IWebDriver _driver;
        protected ComplianceNavigationBar _ComplianceNavigationBar;

        public CompliancePageBase(IWebDriver driver) : base(driver)
        {
            _ComplianceNavigationBar = new ComplianceNavigationBar(driver, By.Id("MainSector"));
        }

        public ComplianceNavigationBar NavMenu { get { return _ComplianceNavigationBar; } }

        //public void NavigationTo(string mainMenu, string subMenu, int sportId)
        //{
        //    _ComplianceNavigationBar.Select(mainMenu, subMenu, sportId);
        //}

        //public void NavigationTo(string mainMenu, string subMenu)
        //{
        //    _ComplianceNavigationBar.Select(mainMenu, subMenu, 0);
        //}

        protected void ClosePopWindow(IWebDriver driver)
        {
            var waitTime = TimeSpan.FromSeconds(5);
            var waitHard = TimeSpan.FromSeconds(1);

            // New Updated Calendar Feature!
            if (WaitSelector.WaitingFor_ElementExists(driver, By.XPath("//span[contains(text(),'No thanks')]"), waitTime))
            {
                var btnNoThanks = WaitSelector.WaitingFor_GetElementWhenIsVisible(driver, By.XPath("//span[contains(text(),'No thanks')]"));

                WaitSelector.HardWait(waitHard);
                btnNoThanks.Click();
                WaitSelector.HardWait(waitHard);
            }
            if (WaitSelector.WaitingFor_ElementExists(driver, By.XPath("//span[contains(text(),'Close') and contains(@class,'close-link')]"), waitTime))
            {
                var btnClose = WaitSelector.WaitingFor_GetElementWhenIsVisible(driver, By.XPath("//span[contains(text(),'Close') and contains(@class,'close-link')]"));
                WaitSelector.HardWait(waitHard);
                btnClose.Click();
                WaitSelector.HardWait(waitHard);
            }

            // SUMMER IS HERE AGAIN!!!
            if (WaitSelector.WaitingFor_ElementExists(driver, By.XPath("//span[contains(text(),'Ok, got it')]"), waitTime))
            {
                var btnGotIt = WaitSelector.WaitingFor_GetElementWhenIsVisible(driver, By.XPath("//span[contains(text(),'Ok, got it')]"));
                WaitSelector.HardWait(waitHard);
                btnGotIt.Click();
                WaitSelector.HardWait(waitHard);
            }

            //
        }
    }
}
