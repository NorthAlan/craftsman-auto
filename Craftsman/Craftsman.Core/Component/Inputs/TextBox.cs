using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Craftsman.Core.Component
{
    public class TextBox : BaseComponent
    {
        public TextBox(IWebDriver driver, By by) : base(driver, by)
        {
        }

        public void SendKeys(string text)
        {
            this.Waiting(For.Visible);
            this.OriginalElement.SendKeys(text);
        }

        public void Clear()
        {
            this.OriginalElement.Clear();
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
