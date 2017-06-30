using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class CoachAddNewsPage : CoachPageBase
    {
        public CoachAddNewsPage(IWebDriver driver) : base(driver)
        {
            //WaitSelector.WaitingFor_ElementExists(this.Driver, By.Id("ContentPlaceHolder1_txtUsername"));
        }
    }
}
