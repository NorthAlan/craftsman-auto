using Craftsman.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Component
{

    public class JumpForwardSelect : BaseComponent
    {
        public JumpForwardSelect(IWebDriver driver, By by) : base(driver, by)
        {
        }

        public string SelectByValue(string value)
        {
            return string.Empty;
        }

        public string Select(string text)
        {
            this.Waiting(For.Visible);
            return string.Empty;
        }

    }
}
