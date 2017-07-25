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


        #region
        //[Fact(DisplayName = cst_DisplayName + ".APIsTests")]
        //public void Call_APIs()
        //{
        //    //RestSharp
        //    //https://college-china.jumpforward.com/index.aspx
        //    var client = new RestClient("https://college-china.jumpforward.com");

        //    var requestIndex = new RestRequest("index.aspx", Method.GET);
        //    var requestSignIn = new RestRequest("index.aspx", Method.POST);
        //    var requestCoach = new RestRequest("coach/Prospects", Method.GET);
        //    var cookieContainer = new CookieContainer();

        //    var responseIndex = client.Get(requestIndex);

        //    //<User\s*EntryTime='(?<time>[\s\S]*?)'\s+Email='(?<email>[\s\S]*?)'>(?<userName>[\s\S]*?)</User>
        //    //var match = Regex.Match(responseIndex.Content, "< input id = \"{0}\" name = \"{0}\" value = \"(?<value>[\\s\\S]*?)\"", RegexOptions.IgnoreCase);
        //    //
        //    var _eventTarget = GetInputDemoValue("__EVENTTARGET", responseIndex.Content);
        //    var _eventArgument = GetInputDemoValue("__EVENTARGUMENT", responseIndex.Content);
        //    var _viewState = GetInputDemoValue("__VIEWSTATE", responseIndex.Content);
        //    var _viewStateGenerator = GetInputDemoValue("__VIEWSTATEGENERATOR", responseIndex.Content);
        //    var _eventValidation = GetInputDemoValue("__EVENTVALIDATION", responseIndex.Content);
        //    var _userIPAddress = GetInputDemoValue("ContentPlaceHolder1_userIPAddress", responseIndex.Content); 

        //    //var xmlDoc = new XmlDocument();
        //    //var  iStart = responseIndex.Content.IndexOf("<body>");
        //    //var iEnd = responseIndex.Content.IndexOf("</body>");
        //    //var xml = responseIndex.Content.Substring(iStart, iEnd - iStart + 7);
        //    //< input id = "__EVENTTARGET" name = "__EVENTTARGET" value = "" type = "hidden" >
        //    //xmlDoc.LoadXml(xml);
        //    //var _eventTarget = xmlDoc.SelectSingleNode(".//input[@id='__EVENTTARGET']").Value;
        //    //var _eventArgument = xmlDoc.SelectSingleNode(".//input[@id='__EVENTARGUMENT']").Value;
        //    //var _viewState = xmlDoc.SelectSingleNode(".//input[@id='__VIEWSTATE']").Value;
        //    //var _viewStateGenerator = xmlDoc.SelectSingleNode(".//input[@id='__VIEWSTATEGENERATOR']").Value;
        //    //var _eventValidation = xmlDoc.SelectSingleNode(".//input[@id='__EVENTVALIDATION']").Value;
        //    //var _userIPAddress = xmlDoc.SelectSingleNode(".//input[@id='ContentPlaceHolder1_userIPAddress']").Value;


        //    var cookies = responseIndex.Cookies;
        //    foreach (var cookie in cookies)
        //    {
        //        cookieContainer.Add(new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
        //    }
        //    client.CookieContainer = cookieContainer;


        //    requestSignIn.AddParameter("__EVENTTARGET", _eventTarget);
        //    requestSignIn.AddParameter("__EVENTARGUMENT", _eventArgument);
        //    requestSignIn.AddParameter("__VIEWSTATE", _viewState);
        //    requestSignIn.AddParameter("__VIEWSTATEGENERATOR", _viewStateGenerator);
        //    requestSignIn.AddParameter("__EVENTVALIDATION", _eventValidation);
        //    //requestSignIn.AddParameter("__VIEWSTATE", "MXkCH3aiKBAVraJcgL8j0p8vhcrHxIqf9GGSsOAaomA0D34bhItqgG26iskoaIOGR / EvsKSzmVTP0FGZmcvextYEEnNszOW0JXA26TwnVCI =");
        //    //requestSignIn.AddParameter("__VIEWSTATEGENERATOR", "90059987");
        //    //requestSignIn.AddParameter("__EVENTVALIDATION", "1wxkCc9e4mfal2M8RRUgZWho19iebcPysIwpt2yReEheQEGWAmnyVBIeMq5ZRbWvRo5NRJA0bE2OGUGtKSI7YrXOWKkfsv9CU0yRMrY5 + ZoI4Tx67W / 9Ywvg / v5v57xEaRdScdiTj8gGWIH35FQ9AZ9PZyygXUpe6OxEmGdR9whhydNtr / cSF + pawZnBy74b");
        //    requestSignIn.AddParameter("ctl00$ContentPlaceHolder1$txtUsername", "demicoach@activenetwork.com");
        //    requestSignIn.AddParameter("ctl00$ContentPlaceHolder1$txtPassword", "active");
        //    requestSignIn.AddParameter("ctl00$ContentPlaceHolder1$bttnLogin", "Sign In");
        //    requestSignIn.AddParameter("ctl00$ContentPlaceHolder1$userIPAddress", _userIPAddress);
        //    //requestSignIn.AddParameter("ctl00$ContentPlaceHolder1$userIPAddress", "74.120.127.228");
        //    var responseSignIn = client.Post(requestSignIn);
        //    //cookies = responseSignIn.Cookies;

        //    //cookieContainer = new CookieContainer();
        //    //foreach (var cookie in cookies)
        //    //{
        //    //    cookieContainer.Add(new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
        //    //}
        //    //client.CookieContainer = cookieContainer;

        //    //requestSignIn.AddParameter("ctl00$ContentPlaceHolder1$txtUsername", "demicoach@activenetwork.com");
        //    //requestSignIn.AddParameter("ctl00$ContentPlaceHolder1$txtPassword", "active");
        //    //requestSignIn.AddParameter("ctl00$ContentPlaceHolder1$bttnLogin", "Sign In");
        //    //responseSignIn = client.Post(requestSignIn);


        //    //var responseCoach = client.Get(requestCoach);
        //    //cookies = responseCoach.Cookies;

        //    //foreach (var cookie in cookies)
        //    //{
        //    //    cookieContainer.Add(new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
        //    //}
        //    //cookieContainer.Add(new System.Net.Cookie("ASP.NET_SessionId", "1qx5l1gjst4d4dt3ir42etym", string.Empty, "college-china.jumpforward.com"));
        //    //cookieContainer.Add(new System.Net.Cookie(".ASPXFORMSAUTH", "F986E0390392CB2F10EFF37DFFFD8CA6F326582CF684C1774B6DE0C18E672EEAD37689303CD777DCE455E1F9BDF4097422B5D33D9A84C2864EE89AEE5B886A092FEA80B66311DF06FF8D55E7D242ACD800C4237D3D6A9B59500A50761C402FB5F9381C4596489930DE9547EF3FC0A9286034D35C90E35576B0D408517D066BD9846E0AFC3BB185062CF6EAD8037757DCE766A1F69E35A46215E86FB3B3E78851", string.Empty, "college-china.jumpforward.com"));
        //    //cookieContainer.Add(new System.Net.Cookie(".ASPROLES", ".ASPROLES=pm9VwmA1h3dwHWnu-39RDgP_bDT77R5pA9UDxHevYkjhFRaKQ4nAYZCZ-KDZ-ocgXj61yEKtv6IGEZ2L3ELbygsHowWgsW7p8c2s3nqHuGUA84XxTY_t9s9w7MuyXRYMmy6IyG-eVMOpdNzs9JhhmGaQ1P-q5zgANZx-CcomYYYVgXkem3W1C4rllYiySRDaHTaYoUNVIOd_8MWGckts5TNZlT8gg-sP2pHpO6mjD6hkQrTVGWjohP-FEep81meeItF4x4iUxVZtmjoOx6aMdqZFA0Nm0AHUElpxSL1y4PHvPP49CpzhbLN3cINLdSgx2DVr5XOZsEzHN3bAGV69uY6MSGouzOnnt15YNrDX7Zvowu0Jq5PPBstednEp3DKOKr2NekJDmW_bY9RBG1zQX98hDNs1PP4e9hsfigyaD6OrpZClDTwedPTdxzuExBoGKDk3aOZLWk-_MKEwqKW4wTzvhpPGoL9yWCWXPndKXuo4DuFITJSvcdsgh0EXcABBCWXmmaFFrSPVaiYBuw5Yeg2", string.Empty, "college-china.jumpforward.com"));



        //    //coach/Prospects/GetNewProspects?skip=0&take=100&pageSize=100
        //    var request = new RestRequest("coach/Prospects/GetNewProspects?skip=0&take=100&pageSize=100", Method.GET);

        //    request.AddUrlSegment("skip", "0"); // replaces matching token in request.Resource
        //    request.AddUrlSegment("take", "100"); // replaces matching token in request.Resource
        //    request.AddUrlSegment("pageSize", "100"); // replaces matching token in request.Resource

        //    var response = client.Get(request);
        //}
        #endregion
    }
}
