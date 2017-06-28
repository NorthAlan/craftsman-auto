using OpenQA.Selenium;
using OpenQA.Selenium.Interactions; 

namespace JumpForward.Common.Component
{
    public class ComplianceNavigationBar
    {
        protected const string CST_MAIN_MENU_TEMP = "//div[@class='compMenuWrapper']//a[text()='{0}']";
            //".//*[@id='contentnavtop']/ul[contains(@class,'navMenu')]/*/a[text()='{0}']";

        protected IWebDriver _driver;
        protected IWebElement _rootElement;

        public ComplianceNavigationBar(IWebDriver driver, By rootPath)
        {
            _driver = driver;
            _rootElement = driver.FindElement(rootPath);
        }

        /// <summary>
        /// NavigationTo other page
        /// </summary>
        /// <param name="mainMenu">mainMenu</param>
        /// <param name="subMenu">subMenu</param>
        public void NavigationTo(string mainMenu, string subMenu, int sportId)
        {
            //ex: .//*[@id='contentnavtop']/ul[contains(@class,'navMenu')]/*/a[text()='Databases']/following-sibling::div[1]//a[text()='Prospects']
            var mainMenuPath = string.Format(CST_MAIN_MENU_TEMP, mainMenu);
            var eleMainMenu = _driver.FindElement(By.XPath(mainMenuPath));

            var action = new Actions(_driver);
            action.MoveToElement(eleMainMenu).Perform();

            var linkImg = string.Empty;

            if (mainMenu == "Roster")
            { 
                linkImg = string.Format("//a[@href='/compliance2/RosterManagement.aspx?sid={0}']", sportId);
            }

            var eleSubMenu = _driver.FindElement(By.XPath(linkImg));
            //TODO: handler exception here.

            eleSubMenu.Click();
        }
         
    }
}
