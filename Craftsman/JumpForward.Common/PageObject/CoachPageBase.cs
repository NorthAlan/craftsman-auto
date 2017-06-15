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
    public class CoachPageBase : PageObjectBase
    {
        protected IWebDriver _driver;
        protected NavigationBar _navigationBar;

        public CoachPageBase(IWebDriver driver) : base(driver)
        {
            //TODO: Verify page
            _navigationBar = new NavigationBar(driver, By.Id("navtop"));
        }

        public void NavigationTo(string mainMenu, string subMenu)
        {
            _navigationBar.NavigationTo(mainMenu, subMenu);
        }

    }
}
