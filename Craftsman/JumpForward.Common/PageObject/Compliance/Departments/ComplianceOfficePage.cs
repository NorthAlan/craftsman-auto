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
    public class ComplianceOfficePage : PageObjectBase
    {
        protected Button btnAssignForm;
        protected Button btnAddDeptUser;
        protected Button btnEmail;
        protected Button btnClear;
        protected CheckBox chkIncludeInactive;
        protected JumpForwardTable DeptUserList; 

        public ComplianceOfficePage(IWebDriver driver) : base(driver)
        {
            WaitSelector.WaitingFor_ElementExists(driver, By.Id("bttnAddindividualDeptUser"));

            this.btnAssignForm = new Button(driver, By.Id("aDeptCreateTask"));
            this.btnAddDeptUser = new Button(driver, By.Id("bttnAddindividualDeptUser"));
            this.btnEmail = new Button(driver, By.Id("bttnEmail"));
            this.btnClear = new Button(driver, By.Id("bttnIndividualDepartmentClear"));
            this.chkIncludeInactive = new CheckBox(driver, By.Id("chkIndividualDeptIncludeInactive"));
            this.DeptUserList = new JumpForwardTable(driver, By.Id("divIndividualDepartmentGridContainer")); //tblIndividualDepartmentsGrid , divIndividualDepartmentGridContainer
        }

        public AddNewComplianceUserPage AddNewComplianceUser()
        {
            this.btnAddDeptUser.Click();
            return new AddNewComplianceUserPage(this.Driver);
        }


    }
}
