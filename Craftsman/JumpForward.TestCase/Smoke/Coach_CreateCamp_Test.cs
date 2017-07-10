using Craftsman.Core;
using Craftsman.Core.Factory;
using Craftsman.Core.Fixture;
using Craftsman.Core.Utilities;
using JumpForward.Common;
using JumpForward.Common.Component;
using JumpForward.Common.Model;
using JumpForward.Common.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JumpForward.TestCase
{
    [Trait("Coach", "Camp")]
    public class Coach_CreateCamp_Test: JumpForwardTestBase
    {
        public Coach_CreateCamp_Test(SingleBrowserFixture fixture) : base(fixture)
        {
        }

        private const string cst_DisplayName = "Create.Camp";


        [Fact(DisplayName = cst_DisplayName + ".Success")]
        public void Demo_Case_CreateCamp()
        {
            //-->Data preparation.
            var camp = new CampModel()
            {
                Name = "camp name 001",
                Location = "china XI'AN",
                MapsLocation = string.Empty,
                TimeZone = "Central standard time",
                CampStart = DateTime.Parse("2018-01-01 1:00 PM"),
                CampEnd = DateTime.Parse("2018-01-01 7:00 PM"),
                RegistrationStart = DateTime.Parse("2017-12-01 1:00 PM"),
                RegistrationEnd = DateTime.Parse("2017-12-01 7:00 PM"),
                ConfirmationEmailText = "ConfirmationEmailText",
                CampWaiver = "CampWaiver",
                RefundPolicy = "RefundPolicy"
            };

            camp.CampItems = new List<CampItemModel>() {
                new CampItemModel { Price = 10.00m, Description = "CampItem 001" , Unlimited= false, MaxQty = 10 } ,
                new CampItemModel { Price = 20.00m, Description = "CampItem 001" , Unlimited= true } ,
            };

            //camp.Purchases = 
            //camp.DefaultQuestions = 
            //camp.CustomQuestions =
            //camp.CustomWaivers

            var signInPage = TestContainer.Router.GoTo<CoachSignInPage>();
            var dbProspectsPage = signInPage.SignIn("demicoach@activenetwork.com", "active");
            var databaseCampsPage = dbProspectsPage.NavMenu.Select<DatabaseCampsPage>("Databases", "Camps");

            /*You can custom this 'Workflow'*/
            databaseCampsPage.ClickAddCampButton()
                //.SetCampBaseInformation(camp)
                //.SetCampRegistrationItems(camp.CampItems)
                //.SetCampExtraItems(camp.Purchases)
                //.SetDefaultQuestions(camp)
                //.SetCustomQuestions(camp)
                //.SetWaiverInformation(camp)
                //.SetAgreementAndDescription("agreement", "description")
                .ClickSaveButton();

            Assert.True(databaseCampsPage.IsExistCamp("camp name"));
        }
        public void Demo_Case()
        {
            /*
             * Testbase
             *  ==> ModelBuilder 模型生成器
             *      @. ModelBuilder.
             *  ==> DataKeeper 数据持有
             *      @. DataKeeper.{ModuleName}.{SqlActionName}
             *  ==> ServiceInvoker 服务调用
             *      @.ServiceInvoker.{ModuleName}.{ServiceActionName}
             *  ==> RouteMapper 路由映射
             *      @.RouteMapper.GoTo<IPageObject>(string url)
             *      @.RouteMapper.Build<IPageObject>(IWebDriver driver)
             *      @.RouteMapper.Is<IPageObject>(IWebDriver driver)
             *  
             *  ==> PageObject
             *      ==== Method
             *      @. Action method : return IPageObject
             *      @. Data acquisition / Check method : return data object
             *      ==== Property
             *      @. internal component :  
             *      @. public component : IComponent Use for Checker
             *  WorkflowFactory
             *  TestContext
             */

            //-->Data preparation.
            
            //var signInPage = RouteMapper.GoTo<CoachSignInPage>();
            //var dbProspectsPage = signInPage.SignIn("demicoach@activenetwork.com", "active");
            //var DatabaseCampsPage = dbProspectsPage.NavMenu.Select<DatabaseCampsPage>("Databases", "Camps");

            //dbProspectsPage.NavMenu.Select("Databases", "Camps");
            //DatabaseCampsPage = RouteMapper.Build<DatabaseCampsPage>()
            //  .ClickAddCampButton()
            //  .SetCampBaseInformation(model)
            //  .SetCampRegistrationItems(model)
            //  .SetCampExtraItems(model)
            //  .SetDefaultQuestions(model)
            //  .SetCustomQuestions(model)
            //  .SetWaiverInformation(model)
            //  .ClickSaveButton(model)


            //DatabaseCampsPage = RouteMapper.Build<DatabaseCampsPage>()
            //  .ClickAddCampButton()
            //  .SetCampBaseInformation(model)
            //  .ClickSaveButton(model)



            /*You can custom 'Workflow'*/

            //Assert.NotNull(DatabaseCampsPage.GetCampByName("camp name"));
        }

    }
}
