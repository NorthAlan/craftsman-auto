using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core.Component
{
    public class Select: BaseComponent
    {
        public Select(IWebDriver driver, By by) : base(driver, by)
        {
        }
        
        public string SelectByText(string text)
        { 
            SelectElement ddlSelect = new SelectElement(this.OriginalElement);
            ddlSelect.SelectByText(text);

            return string.Empty;
        }

        public string SelectByIndex(int index)
        {
            SelectElement ddlSelect = new SelectElement(this.OriginalElement);
            ddlSelect.SelectByIndex(index);

            return string.Empty;
        }
    }
}
