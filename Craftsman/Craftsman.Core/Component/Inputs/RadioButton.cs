using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Craftsman.Core.Component
{
    public class RadioButton : BaseComponent
    {
        public RadioButton(IWebDriver driver, By by) : base(driver, by)
        {
        }

        public void Click()
        {
            this.Waiting(For.Visible);
            this.OriginalElement.Click();
        } 

        public bool Selected
        {
            get
            {
                return this.OriginalElement.Selected;
            }
        }
    }
}
