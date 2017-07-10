using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Craftsman.Core.Component
{
    public class Button : BaseComponent
    {
        public Button(IWebDriver driver, By by) : base(driver, by)
        {
        }

        public void Click()
        {
            this.Waiting(For.Clickable);
            this.OriginalElement.Click();
        }

        public string Text
        {
            get
            {
                return this.Text;
            }
        }
    }
}
