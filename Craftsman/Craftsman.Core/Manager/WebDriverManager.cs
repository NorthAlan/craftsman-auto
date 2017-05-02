using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Craftsman.Core.Tools;

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

        public void NavigateTo(string url)
        {
            var linkUrl = RouteMapper.BuildPageUrl("AppAlias.Coach", url);
            _driver.Url = linkUrl;
        }
    }
}
