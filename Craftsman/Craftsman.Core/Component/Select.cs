using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Craftsman.Core.Component
{
    public class Select : BaseComponent
    {
        public Select(IWebDriver driver, By by) : base(driver, by) { }

        public void SelectByText(string text)
        {
            this.Waiting(For.Clickable);
            var ele = new SelectElement(this.OriginalElement);
            ele.SelectByText(text);
        }

        public void SelectByValue(string value)
        {
            this.Waiting(For.Clickable);
            var ele = new SelectElement(this.OriginalElement);
            ele.SelectByValue(value);
        }
        public void SelectByValue(int index)
        {
            this.Waiting(For.Clickable);
            var ele = new SelectElement(this.OriginalElement);
            ele.SelectByIndex(index);
        }

        public string SelectedOptionText
        {
            get
            {
                this.Waiting(For.Clickable);
                var ele = new SelectElement(this.OriginalElement);
                return ele.SelectedOption.Text;
            }
        }

        public List<string> AllSelectedOptions
        {
            get
            {
                this.Waiting(For.Clickable);
                var ele = new SelectElement(this.OriginalElement);
                return ele.AllSelectedOptions.Select(x => x.Text).ToList();
            }
        }
    }
}
