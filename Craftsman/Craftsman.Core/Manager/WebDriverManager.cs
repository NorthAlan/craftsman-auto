using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Craftsman.Core.Utilities;

namespace Craftsman.Core.Manager
{
    public class WebDriverManager : IDriverManager
    {
        private IWebDriver _driver;
        public WebDriverManager() { }
        public WebDriverManager(IWebDriver driver)
        {
            this._driver = driver;
        }

        public IWebDriver Driver
        {
            get
            {
                return this._driver;
            }
        }

        public void BuildDefaultSetting()
        {
            _driver.Manage().Window.Maximize();
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
        }
        
    }
}
