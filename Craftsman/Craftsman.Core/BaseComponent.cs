using Craftsman.Core.Utilities;
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

        public List<IWebElement> OriginalElements
        {
            get
            {
                if (this._driver != null)
                {
                    return this._driver.FindElements(this._by).ToList();
                }
                throw new Exception("Can not get WebElement!");
            }
        }

        public string GetText()
        {
            return this.OriginalElement.Text;
        }

        public bool IsClickable()
        {
            return (WaitSelector.WaitingFor_GetElementWhenToBeClickable(this._driver, this._by) != null);
        }

        public bool IsExist()
        {
            return (WaitSelector.WaitingFor_GetElementsWhenExists(this._driver, this._by) != null);
        }

        public bool IsVisible()
        {
            return (WaitSelector.WaitingFor_GetElementsWhenIsVisible(this._driver, this._by) != null);
        }

        public void Waiting(For type, TimeSpan timeout)
        {
            switch (type)
            {
                case For.Exist:
                    WaitSelector.WaitingFor_ElementExists(this._driver, this._by, timeout);
                    break;
                case For.Visible:
                    WaitSelector.WaitingFor_ElementIsVisible(this._driver, this._by, timeout);
                    break;
                case For.Clickable:
                    WaitSelector.WaitingFor_ElementToBeClickable(this._driver, this._by, timeout);
                    break;
                case For.Invisibility:
                    WaitSelector.WaitingFor_InvisibilityOfElementLocated(this._driver, this._by, timeout);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void Waiting(For type)
        {
            Waiting(type, TimeSpan.FromSeconds(30));
        }

        public void WaitingTextToBePresent(string text)
        {
            WaitSelector.WaitingFor_TextToBePresentInElement(this._driver, this.OriginalElement, text, TimeSpan.FromSeconds(30));
        }
    }
}
