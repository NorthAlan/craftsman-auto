using Craftsman.Core;
using Craftsman.Core.Component;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Component
{

    public class JumpForwardSelect : BaseComponent
    {
        public JumpForwardSelect(IWebDriver driver, By by) : base(driver, by)
        {
        }

        public string SelectByValue(string value)
        {
            return string.Empty;
        }

        public string Select(string text)
        {
            this.Waiting(For.Visible);
            var eleSelectBox = this.OriginalElement;
            var eleSelectOption = new TextArea(this._driver, By.XPath($".//*[@id='TimeZoneId_listbox']/li[text()='{text}']"));

            var action = new Actions(this._driver);
            action.MoveToElement(eleSelectBox).Click().Perform();

            eleSelectOption.Waiting(For.Visible);
            action.MoveToElement(eleSelectOption.OriginalElement).Click().Perform();

            return string.Empty;
        }

    }
}
