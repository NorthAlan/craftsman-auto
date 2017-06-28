using Craftsman.Core.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Component
{
    public class NavigationBar
    {
        protected const string CST_MAIN_MENU_TEMP = ".//*[@id='contentnavtop']/ul[contains(@class,'navMenu')]/*/a[text()='{0}']";

        protected IWebDriver _driver;
        protected IWebElement _rootElement;

        public NavigationBar(IWebDriver driver, By rootPath)
        {
            _driver = driver;
            _rootElement = driver.FindElement(rootPath);
        }

        /// <summary>
        /// NavigationTo other page
        /// </summary>
        /// <param name="mainMenu">mainMenu</param>
        /// <param name="subMenu">subMenu</param>
        public void NavigationTo(string mainMenu, string subMenu)
        {
            
            //ex: .//*[@id='contentnavtop']/ul[contains(@class,'navMenu')]/*/a[text()='Databases']/following-sibling::div[1]//a[text()='Prospects']
            var mainMenuPath = string.Format(CST_MAIN_MENU_TEMP, mainMenu);

            //var eleMainMenu = _driver.FindElement(By.XPath(mainMenuPath));
            var eleMainMenu = WaitSelector.WaitingFor_GetElementWhenIsVisible(this._driver, By.XPath(mainMenuPath));

            var action = new Actions(_driver);
            action.MoveToElement(eleMainMenu).Perform();

            var linkText = string.Format("{0}/following-sibling::div[1]//a[text()='{1}']", mainMenuPath, subMenu);
            var linkImg = string.Format("{0}/following-sibling::div[1]//span[text()='{1}']", mainMenuPath, subMenu);
            var eleSubMenu = WaitSelector.WaitingFor_GetElementWhenIsVisible(_driver, By.XPath(string.Format("{0} | {1}", linkText, linkImg)));
            //var eleSubMenu = _driver.FindElement(By.XPath(string.Format("{0} | {1}", linkText, linkImg)));
            //TODO: handler exception here.

            eleSubMenu.Click();
        }
    }
}
