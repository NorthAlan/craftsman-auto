using Craftsman.Core;
using Craftsman.Core.Factory;
using Craftsman.Core.Fixture;
using Craftsman.Core.Utilities;
using JumpForward.Common;
using JumpForward.Common.Component;
using JumpForward.Common.Fixture;
using JumpForward.Common.Model;
using JumpForward.Common.PageObject;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace JumpForward.TestCase
{
    [Trait("Coach", "Camp")]
    public class Coach_CreateCamp_Test : JumpForwardTestBase
    {
        public Coach_CreateCamp_Test(TestContextFixture context, JumpForwardServiceFixture service) : base(context, service) { }

        private const string cst_DisplayName = "Create.Camp";

        [Fact(DisplayName = cst_DisplayName + ".Success")]
        //[JsonData("file1.json","file2.json")]
        //SQlData()
        public void Demo_Case_CreateCamp()
        {
            //-->Data preparation.
            
            var json = File.ReadAllText("Smoke/DemoCase/TestData.json");
            var camp = JsonConvert.DeserializeObject<CampModel>(json);

            var signInPage = Router.GoTo<CoachSignInPage>();
            var dbProspectsPage = signInPage.SignIn("demicoach@activenetwork.com", "active");
            var databaseCampsPage = dbProspectsPage.NavMenu.Select<DatabaseCampsPage>("Databases", "Camps");

            /*You can custom this 'Workflow'*/
            databaseCampsPage.ClickAddCampButton()
                .SetCampBaseInformation(camp)
                .SetCampRegistrationItems(camp.CampItems)
                .SetCampExtraItems(camp.Purchases)            
                .SetDefaultQuestions(camp)
                .SetCustomQuestions(camp)
                .SetWaiverInformation(camp)
                .SetAgreementAndDescription("agreement", "description")
                .ClickSaveButton();

            Assert.True(databaseCampsPage.IsExistCamp(camp.Name));
        }

        [Fact(DisplayName = cst_DisplayName + ".APIsTests")]
        public void Call_APIs()
        {
            //call APIs
            //GET: coach/Prospects/GetNewProspects?skip=0&take=100&pageSize=100
            var prospects = this.CoachService.GetProspects();
            Assert.NotNull(prospects);
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
             *      [idea]@.ServiceInvoker.{ModuleName}.{ServiceActionName}
             *      [fact]@.{ModuleName}Service.{ServiceActionName}
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
