using Craftsman.Core.Factory;
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

        public void NavigationTo(string mainMenu, string subMenu, int sportId)
        {
            _ComplianceNavigationBar.NavigationTo(mainMenu, subMenu, 18);
        }

        public void NavigationTo(string mainMenu, string subMenu)
        {
            _ComplianceNavigationBar.NavigationTo(mainMenu, subMenu, 0);
        }
    }
}
