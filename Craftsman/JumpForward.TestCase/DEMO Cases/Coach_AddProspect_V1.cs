using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Craftsman.Core.Factory;
using JumpForward.Common.PageObject;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Craftsman.Core.Component;
using Craftsman.Core.Utilities;

namespace JumpForward.TestCase.DEMO_Cases
{
    public class Coach_AddProspect_V1
    {
        [Fact(DisplayName = "Coach_AddProspect")]
        public void AddProspect()
        {
            //create manager
            var manager = CraftsmanFactory.CreateDriverManager();
            // navigate to Sign In page
            //manager.NavigateTo(String.Empty);

            var signInPage = CraftsmanFactory.CreatePageObject<CoachSignInPage>(manager.Driver);
            var dbProspectsPage = signInPage.SignIn("demicoach@activenetwork.com", "active");

            // navigate to Add Prospect page
            dbProspectsPage.NavMenu.Select("Databases", "Add Prospect");


            // Type the required prospect details - First Name, Last Name and Grad Year
            var txtFirstName = manager.Driver.FindElement(By.Id("cphMain_cphMainContent_txtFirstName"));
            var txtLastName = manager.Driver.FindElement(By.Id("cphMain_cphMainContent_txtLastName"));
            var ddlGradYear = manager.Driver.FindElement(By.Id("cphMain_cphMainContent_ddlGradYear"));
            var btnSaveProspect = manager.Driver.FindElement(By.XPath("//*[@id='mainContainer']/div//input[@value='Save Prospect' and @type='button']"));

            txtFirstName.SendKeys("FN");
            txtLastName.SendKeys("LN");
            var setGY = new SelectElement(ddlGradYear);
            setGY.SelectByValue("2017");
            btnSaveProspect.Click();

            var textSuccessful = manager.Driver.FindElement(By.XPath(".//*[@id='cphMain_cphMainContent_lblProspectStatus']/h2"));
            WaitSelector.WaitingFor_TextToBePresentInElement(manager.Driver, textSuccessful, "Prospect Saved Successfully");

            var hrefClickHere = manager.Driver.FindElement(By.XPath(".//a[text()='Click Here']"));
            hrefClickHere.Click();

            var recruitName = manager.Driver.FindElement(By.Id("recruitName"));
            WaitSelector.WaitingFor_TextToBePresentInElement(manager.Driver, recruitName, "FN LN");

            manager.Driver.Close();
        }


    }
}
