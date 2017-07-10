using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Craftsman.Core.Component
{
    public class RichTextBox : BaseComponent
    {
        public RichTextBox(IWebDriver driver, By by) : base(driver, by)
        {
        }

        public void SendKeys(string text)
        {
            this.Waiting(For.Visible);
            var eleInput = this.OriginalElement.FindElement(By.Id("cke_1_contents"));
            

            var action = new Actions(this._driver);
            action.MoveToElement(eleInput)
                .Click()
                .SendKeys(text)
                .Perform();
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
