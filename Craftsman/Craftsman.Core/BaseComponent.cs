using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core
{
    public class BaseComponent : IComponent
    {
        protected IWebDriver _driver;
        protected By _by;

        public BaseComponent(IWebDriver driver, By by)
        {
            this._driver = driver;
            this._by = by;
        }
        public IWebElement OriginalElement
        {
            get
            {
                if (this._driver != null)
                {
                    return this._driver.FindElement(this._by);
                }
                throw new Exception("Can not get WebElement!");
            }
        }
        public bool IsClickable()
        {
            throw new NotImplementedException();
        }

        public bool IsExist()
        {
            throw new NotImplementedException();
        }

        public bool IsVisible()
        {
            throw new NotImplementedException();
        }

        public bool WaitingFor(ComponentWaitType type, TimeSpan timeout)
        {
            throw new NotImplementedException();
        }
    }
}
