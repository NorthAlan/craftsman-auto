using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core.Component
{
    public class CheckBox : BaseComponent
    {
        public CheckBox(IWebDriver driver, By by) : base(driver, by)
        {
        }

        public void Click()
        {
            this.OriginalElement.Click();
        }

        public void SetState(bool selected)
        {
            if (this.Selected != selected)
            {
                this.OriginalElement.Click();
            }
        }

        public bool Selected
        {
            get{ return this.OriginalElement.Selected; }
        }
    }
}
