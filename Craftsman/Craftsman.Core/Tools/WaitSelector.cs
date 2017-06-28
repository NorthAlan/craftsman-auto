using Craftsman.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Craftsman.Core.Tools
{
    public class WaitSelector
    {
        private static TimeSpan _timeoutInterval;
        static WaitSelector()
        {
            _timeoutInterval = TimeSpan.FromSeconds(30);
            int conifgInterval;
            if (int.TryParse(SettingManager.GetAppSetting(SettingName.WAITTIMEOUTINTERVAL), out conifgInterval))
            {
                _timeoutInterval = TimeSpan.FromSeconds(conifgInterval);
            }
        }

        #region Waiting For Element
        #region Element is exist
        public static bool WaitingFor_ElementExists(IWebDriver driver, By by, TimeSpan timeOut)
        {
            return (WaitingFor_GetElementWhenExists(driver, by, timeOut) != null) ? true : false;
        }
        public static bool WaitingFor_ElementExists(IWebDriver driver, By by)
        {
            return WaitingFor_ElementExists(driver, by, _timeoutInterval);
        }

        public static IWebElement WaitingFor_GetElementWhenExists(IWebDriver driver, By by, TimeSpan timeOut)
        {
            IWebElement element;
            var wait = new WebDriverWait(driver, timeOut);
            try
            {
                element = wait.Until(ExpectedConditions.ElementExists(by));
            }
            catch { element = null; }
            return element;
        }
        public static IWebElement WaitingFor_GetElementWhenExists(IWebDriver driver, By by)
        {
            return WaitingFor_GetElementWhenExists(driver, by, _timeoutInterval);
        }

        public static ReadOnlyCollection<IWebElement> WaitingFor_GetElementsWhenExists(IWebDriver driver, By by, TimeSpan timeOut)
        {
            ReadOnlyCollection<IWebElement> elements;
            var wait = new WebDriverWait(driver, timeOut);
            try
            {
                wait.Until(ExpectedConditions.ElementExists(by));
                elements = driver.FindElements(by);
            }
            catch { elements = null; }
            return elements;
        }
        public static ReadOnlyCollection<IWebElement> WaitingFor_GetElementsWhenExists(IWebDriver driver, By by)
        {
            return WaitingFor_GetElementsWhenExists(driver, by, _timeoutInterval);
        }
        #endregion Element is exist

        #region Element is visible
        public static IWebElement WaitingFor_GetElementWhenIsVisible(IWebDriver driver, By by, TimeSpan timeOut)
        {
            IWebElement element;
            var wait = new WebDriverWait(driver, timeOut);
            try
            {
                element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch { element = null; }
            return element;
        }
        public static IWebElement WaitingFor_GetElementWhenIsVisible(IWebDriver driver, By by)
        {
            return WaitingFor_GetElementWhenIsVisible(driver, by, _timeoutInterval);
        }

        public static ReadOnlyCollection<IWebElement> WaitingFor_GetElementsWhenIsVisible(IWebDriver driver, By by, TimeSpan timeOut)
        {
            ReadOnlyCollection<IWebElement> elements;
            var wait = new WebDriverWait(driver, timeOut);
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                elements = driver.FindElements(by);
            }
            catch { elements = null; }
            return elements;
        }
        public static ReadOnlyCollection<IWebElement> WaitingFor_GetElementsWhenIsVisible(IWebDriver driver, By by)
        {
            return WaitingFor_GetElementsWhenIsVisible(driver, by, _timeoutInterval);
        }

        public static bool WaitingFor_ElementIsVisible(IWebDriver driver, By by, TimeSpan timeOut)
        {
            return (WaitingFor_GetElementWhenIsVisible(driver, by, timeOut) != null) ? true : false;
        }
        public static bool WaitingFor_ElementIsVisible(IWebDriver driver, By by)
        {
            return WaitingFor_ElementIsVisible(driver, by, _timeoutInterval);
        }
        #endregion Element is visible

        #region Element is to be clickable
        public static IWebElement WaitingFor_GetElementWhenToBeClickable(IWebDriver driver, By by, TimeSpan timeOut)
        {
            IWebElement element;
            var wait = new WebDriverWait(driver, timeOut);
            try
            {
                element = wait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch { element = null; }
            return element;
        }
        public static IWebElement WaitingFor_GetElementWhenToBeClickable(IWebDriver driver, By by)
        {
            return WaitingFor_GetElementWhenToBeClickable(driver, by, _timeoutInterval);
        }

        public static ReadOnlyCollection<IWebElement> WaitingFor_GetElementsWhenToBeClickable(IWebDriver driver, By by, TimeSpan timeOut)
        {
            ReadOnlyCollection<IWebElement> elements;
            var wait = new WebDriverWait(driver, timeOut);
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
                elements = driver.FindElements(by);
            }
            catch { elements = null; }
            return elements;
        }
        public static ReadOnlyCollection<IWebElement> WaitingFor_GetElementsWhenToBeClickable(IWebDriver driver, By by)
        {
            return WaitingFor_GetElementsWhenToBeClickable(driver, by, _timeoutInterval);
        }

        public static bool WaitingFor_ElementToBeClickable(IWebDriver driver, By by, TimeSpan timeOut)
        {
            return (WaitingFor_GetElementWhenToBeClickable(driver, by, timeOut) != null) ? true : false;
        }
        public static bool WaitingFor_ElementToBeClickable(IWebDriver driver, By by)
        {
            return WaitingFor_ElementToBeClickable(driver, by, _timeoutInterval);
        }
        #endregion Element is to be clickable

        #endregion Waiting For Element

        #region Waiting For Url
        public static bool WaitingFor_UrlContains(IWebDriver driver, string fraction, TimeSpan timeOut)
        {
            var wait = new WebDriverWait(driver, timeOut);
            return wait.Until(ExpectedConditions.UrlContains(fraction));
        }
        public static bool WaitingFor_UrlContains(IWebDriver driver, string fraction)
        {
            return WaitingFor_UrlContains(driver, fraction, _timeoutInterval);
        }
        //public static bool WaitingFor_UrlContains(IWebDriver driver, PageAlias alias)
        //{
        //    var uri = RouteMapper.ConvertAliasToUri(alias);
        //    return WaitingFor_UrlContains(driver, uri);
        //}

        //public static bool WaitingFor_UrlToBe(IWebDriver driver, PageAlias alias, TimeSpan timeOut)
        //{
        //    var url = RouteMapper.ConvertAliasToUrl(alias);
        //    var wait = new WebDriverWait(driver, timeOut);
        //    return wait.Until(ExpectedConditions.UrlToBe(url));
        //}
        //public static bool WaitingFor_UrlToBe(IWebDriver driver, PageAlias alias)
        //{
        //    return WaitingFor_UrlToBe(driver, alias, _timeoutInterval);
        //}

        public static bool WaitingFor_UrlMatches(IWebDriver driver, string regex, TimeSpan timeOut)
        {
            var wait = new WebDriverWait(driver, timeOut);
            return wait.Until(ExpectedConditions.UrlMatches(regex));
        }
        public static bool WaitingFor_UrlMatches(IWebDriver driver, string regex)
        {
            return WaitingFor_UrlMatches(driver, regex, _timeoutInterval);
        }

        #endregion

        #region Waiting For Text
        public static bool WaitingFor_TextToBePresentInElement(IWebDriver driver, IWebElement element, string text, TimeSpan timeOut)
        {
            var wait = new WebDriverWait(driver, timeOut);
            bool isPresent = false;
            try
            {
                isPresent = wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
            }
            catch { isPresent = false; }
            return isPresent;
        }
        public static bool WaitingFor_TextToBePresentInElement(IWebDriver driver, IWebElement element, string text)
        {
            return WaitingFor_TextToBePresentInElement(driver, element, text, _timeoutInterval);
        }
        #endregion

        #region Waiting For State changed
        public static bool WaitingFor_ElementSelectionStateToBe(IWebDriver driver, IWebElement element, bool selected, TimeSpan timeOut)
        {
            var wait = new WebDriverWait(driver, timeOut);
            return wait.Until(ExpectedConditions.ElementSelectionStateToBe(element, selected));
        }
        public static bool WaitingFor_ElementSelectionStateToBe(IWebDriver driver, IWebElement element, bool selected)
        {
            return WaitingFor_ElementSelectionStateToBe(driver, element, selected, _timeoutInterval);
        }

        public static bool WaitingFor_ElementSelectionStateToBe(IWebDriver driver, By locator, bool selected, TimeSpan timeOut)
        {
            var wait = new WebDriverWait(driver, timeOut);
            return wait.Until(ExpectedConditions.ElementSelectionStateToBe(locator, selected));
        }
        public static bool WaitingFor_ElementSelectionStateToBe(IWebDriver driver, By locator, bool selected)
        {
            return WaitingFor_ElementSelectionStateToBe(driver, locator, selected, _timeoutInterval);
        }

        public static bool WaitingFor_InvisibilityOfElementLocated(IWebDriver driver, By locator, TimeSpan timeOut)
        {
            var wait = new WebDriverWait(driver, timeOut);
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
        public static bool WaitingFor_InvisibilityOfElementLocated(IWebDriver driver, By locator)
        {
            return WaitingFor_InvisibilityOfElementLocated(driver, locator, _timeoutInterval);
        }

        #endregion Waiting For State changed

        #region Extension
        public static bool WaitingFor_WebElementAttributeChangedTo(IWebDriver driver, By locator, string attrName, string attrValue, TimeSpan timeOut)
        {
            var wait = new WebDriverWait(driver, timeOut);
            return wait.Until<bool>(
                delegate (IWebDriver dir)
                {
                    var flag = false;
                    var element = dir.FindElement(locator);
                    if (element.GetAttribute(attrName) == attrValue)
                    {
                        flag = true;
                    }
                    return flag;
                }
            );
        }
        public static bool WaitingFor_WebElementAttributeChangedTo(IWebDriver driver, By locator, string attrName, string attrValue)
        {
            return WaitingFor_WebElementAttributeChangedTo(driver, locator, attrName, attrValue, _timeoutInterval);
        }

        public static bool WaitingFor_WebElementAttributeChanged(IWebDriver driver, By locator, string attrName, TimeSpan timeOut)
        {
            var oldAttrValue = driver.FindElement(locator).GetAttribute(attrName);
            var wait = new WebDriverWait(driver, timeOut);
            return wait.Until<bool>(
                delegate (IWebDriver dir)
                {
                    var flag = false;
                    var element = dir.FindElement(locator);
                    if (element.GetAttribute(attrName) != oldAttrValue)
                    {
                        flag = true;
                    }
                    return flag;
                }
            );
        }
        public static bool WaitingFor_WebElementAttributeChanged(IWebDriver driver, By locator, string attrName)
        {
            return WaitingFor_WebElementAttributeChanged(driver, locator, attrName, _timeoutInterval);
        }
        #endregion Waiting For State changed

        #region Element is exist
        public static void HardWait(TimeSpan time)
        {
            //Temporary use, need to improve.
            Thread.Sleep(time);
        }
        #endregion Element is exist
    }
}
