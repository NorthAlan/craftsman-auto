using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core.Factory
{
    public class PageComponentBase
    {
        protected IWebDriver _driver;
        protected string _rootXPath;

        public PageComponentBase(IWebDriver driver, string rootXPath)
        {
            this._driver = driver;
            this._rootXPath = rootXPath;
        }

        protected virtual void ReloadControls() { }
    }
}
