using Craftsman.Core.Component;
using Craftsman.Core.Factory;
using Craftsman.Core.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject.Compliance.Departments
{
    public class AddNewComplianceUserPage : PageObjectBase
    {
        protected Button btnUpdate;

        public AddNewComplianceUserPage(IWebDriver driver) : base(driver)
        {
            WaitSelector.WaitingFor_ElementExists(driver, By.Id("btnUpdate"));

            this.btnUpdate = new Button(driver, By.Id("btnUpdate"));
        }


    }
}
