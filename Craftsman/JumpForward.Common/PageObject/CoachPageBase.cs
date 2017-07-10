using Craftsman.Core.Factory;
using Craftsman.Core.Tools;
using JumpForward.Common.Component;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class CoachPageBase : PageObjectBase
    {
        protected NavigationBar _navigationBar;

        protected SettingsIcon _settingsIcon;

        public CoachPageBase(IWebDriver driver) : base(driver)
        {
            //TODO: Verify page
            _navigationBar = new NavigationBar(driver, By.Id("navtop"));
            _settingsIcon = new SettingsIcon(driver);
            ClosePopWindow(driver);
        }

        public SettingsIcon Settings { get { return _settingsIcon; } }

        public NavigationBar NavMenu { get { return _navigationBar; } }

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
