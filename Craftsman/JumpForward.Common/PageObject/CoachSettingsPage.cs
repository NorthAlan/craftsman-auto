using Craftsman.Core.Tools;
using JumpForward.Common.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class CoachSettingsPage : CoachPageBase
    {
        public CoachSettingsPage(IWebDriver driver) : base(driver)
        {
            //WaitSelector.WaitingFor_ElementExists(this.Driver, By.Id("ContentPlaceHolder1_txtUsername"));
        }
    }
}
