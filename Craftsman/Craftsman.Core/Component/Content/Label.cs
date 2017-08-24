using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core.Component
{
    public class Label: BaseComponent
    {
        public Label(IWebDriver driver, By by) : base(driver, by)
        {
        }

        public string Text
        {
            get
            {
                return this.OriginalElement.Text;
            }
        }
    }
}
