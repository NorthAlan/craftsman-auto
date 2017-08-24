using Craftsman.Core.Utilities;
using JumpForward.Common.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Component
{
    public class SettingsIcon
    {
        protected const string CST_SETTINGS_ICON = ".//i[@id='settingsIcon']";

        protected const string CST_SETTINGS_NAV = ".//li[@id='settingsContainer']//li/a[normalize-space(text())='{0}']";

        protected IWebDriver _driver;
        protected IWebElement _rootElement;

        public SettingsIcon(IWebDriver driver)
        {
            _driver = driver;
        }

        public T Select<T>() where T: CoachPageBase
        {
            /*
             * CoachMyProfilePage
             * CoachStaffPage
             * CoachSettingsPage
             * CoachAddNewsPage
             */

            var xPath = string.Empty;
            var type = typeof(T);
            if (type.Equals(typeof(CoachMyProfilePage)))
            {
                xPath = string.Format(CST_SETTINGS_NAV, "My Profile");
            }

            if (type.Equals(typeof(CoachStaffPage)))
            {
                xPath = string.Format(CST_SETTINGS_NAV, "Staff");
            }

            if (type.Equals(typeof(CoachSettingsPage)))
            {
                xPath = string.Format(CST_SETTINGS_NAV, "Settings");
            }

            if (type.Equals(typeof(CoachAddNewsPage)))
            {
                xPath = string.Format(CST_SETTINGS_NAV, "Add News");
            }
            if (type.Equals(typeof(CoachSignInPage)))
            {
                xPath = string.Format(CST_SETTINGS_NAV, "Logout");
            }

            if (string.IsNullOrEmpty(xPath))
            {
                throw new Exception(string.Format("Unsupported page type for [{0}]", type.FullName));
            }

            //click menu
            var settingsIcon = _driver.FindElement(By.XPath(CST_SETTINGS_ICON));
            var action = new Actions(_driver);
            action.MoveToElement(settingsIcon).Perform();

            var settingsMenu = WaitSelector.WaitingFor_GetElementWhenIsVisible(this._driver, By.XPath(xPath));
            settingsMenu.Click();

            var objPage = (T)Activator.CreateInstance(typeof(T), _driver);            
            return objPage;
        }

        public CoachSignInPage Logout()
        {
            //click menu
            var settingsIcon = _driver.FindElement(By.XPath(CST_SETTINGS_ICON));
            var action = new Actions(_driver);
            action.MoveToElement(settingsIcon).Perform();

            var xPath = string.Format(CST_SETTINGS_NAV, "Logout");
            var settingsMenu = WaitSelector.WaitingFor_GetElementWhenIsVisible(this._driver, By.XPath(xPath));
            settingsMenu.Click();

            return new CoachSignInPage(this._driver);
        }
    }
}
