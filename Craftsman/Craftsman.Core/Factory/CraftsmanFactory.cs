using Craftsman.Core;
using Craftsman.Core.Manager;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core.Factory
{
    public class CraftsmanFactory
    {
        public static IDriverManager CreateDriverManager()
        {
            var browser = SettingManager.GetAppSetting(SettingName.BROWSER);
            var driverPath = SettingManager.GetAppSetting(SettingName.DRIVERPATH);
            if (string.IsNullOrEmpty(browser))
            {
                throw new Exception(string.Format("Can not get config '{0}'", SettingName.BROWSER));
            }

            IWebDriver driver;
            switch (browser.ToLower())
            {
                case "*iexplore":
                case "*ie":
                    driver = new InternetExplorerDriver(driverPath);
                    break;
                case "*firefox":
                    var options = new FirefoxOptions();
                    
                    driver = new FirefoxDriver();
                    break;
                case "*chrome":
                    driver = new ChromeDriver(driverPath);
                    break;
                //case "*remote":
                //    break;
                default:
                    throw new Exception("Create driver failed!");
            }
            
            var manager = new WebDriverManager(driver);
            manager.BuildDefaultSetting();
            return manager;
        }

        /// <summary>
        /// Create page object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreatePageObject<T>(IWebDriver driver) where T : PageObjectBase
        {
            Type type = typeof(T);
            var pageObject = (T) Activator.CreateInstance(type, driver);
            return pageObject;
        }
        /// <summary>
        /// Create page component
        /// </summary>
        /// <typeparam name="T">page control type</typeparam>
        /// <param name="driver">driver</param>
        /// <param name="rootXPath">rootXPath</param>
        /// <returns>entity</returns>
        public static T CreatePageComponent<T>(IWebDriver driver, string rootXPath) where T : PageComponentBase
        {
            Type type = typeof(T);
            var pageComponent = (T) Activator.CreateInstance(type, driver, rootXPath);
            return pageComponent;
        }
    }
}
