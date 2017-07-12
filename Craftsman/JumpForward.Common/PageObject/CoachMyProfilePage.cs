using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class CoachMyProfilePage : CoachPageBase
    {
        public CoachMyProfilePage(IWebDriver driver) : base(driver)
        {
            //WaitSelector.WaitingFor_ElementExists(this.Driver, By.Id("ContentPlaceHolder1_txtUsername"));
        }
    }
}
