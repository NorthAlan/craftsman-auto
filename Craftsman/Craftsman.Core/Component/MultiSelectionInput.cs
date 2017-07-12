using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Craftsman.Core.Component
{
    public class MutiInputSelect : BaseComponent
    {
        public MutiInputSelect(IWebDriver driver, By by) : base(driver, by)
        {
        }

        public void SelectByText(string text)
        {
            var ele = this._driver.FindElement(this._by);

            var action = new Actions(this._driver);
            action.MoveToElement(ele)
                .Click()
                .SendKeys(text)
                .SendKeys(Keys.Enter)
                .Perform();
        }

        public IList<string> SelectedDatas
        {
            get
            {
                throw new NotSupportedException();
            }
        }
    }
}
