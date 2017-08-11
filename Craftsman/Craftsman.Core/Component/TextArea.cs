using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core.Component
{
    public class TextArea : BaseComponent
    {
        public TextArea(IWebDriver driver, By by) : base(driver, by)
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
