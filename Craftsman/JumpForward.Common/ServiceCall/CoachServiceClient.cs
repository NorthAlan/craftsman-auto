using JumpForward.Common.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JumpForward.Common.ServiceCall
{
    public class CoachServiceClient
    {
        private RestClient _client;

        #region Init data
        public CoachServiceClient()
        {
            if (_client != null) { return; }

            //TODO : get url for config file.
            var client = new RestClient("https://college-china.jumpforward.com");
            client.CookieContainer = new CookieContainer();

            var requestIndex = new RestRequest("index.aspx", Method.GET);
            var requestSignIn = new RestRequest("index.aspx", Method.POST);

            var responseIndex = client.Get(requestIndex);

            var _viewState = GetInputDomValue("__VIEWSTATE", responseIndex.Content);
            var _viewStateGenerator = GetInputDomValue("__VIEWSTATEGENERATOR", responseIndex.Content);
            var _eventValidation = GetInputDomValue("__EVENTVALIDATION", responseIndex.Content);
            requestSignIn.AddParameter("__VIEWSTATE", _viewState);
            requestSignIn.AddParameter("__VIEWSTATEGENERATOR", _viewStateGenerator);
            requestSignIn.AddParameter("__EVENTVALIDATION", _eventValidation);

            requestSignIn.AddParameter("ctl00$ContentPlaceHolder1$txtUsername", "demicoach@activenetwork.com");
            requestSignIn.AddParameter("ctl00$ContentPlaceHolder1$txtPassword", "active");
            requestSignIn.AddParameter("ctl00$ContentPlaceHolder1$bttnLogin", "Sign In");

            client.Post(requestSignIn);
            this._client = client;
        }
        private string GetInputDomValue(string id, string content)
        {
            var strRegex = string.Format("<input type=\"hidden\" name=\"{0}\" id=\"{0}\" value=\"(?<value>[\\s\\S]*?)\"", id);
            var match = Regex.Match(content, strRegex, RegexOptions.IgnoreCase);

            var value = (match.Groups["value"] != null) ? match.Groups["value"].Value : string.Empty;
            return value;
        }
        #endregion

        #region Action Prospect
        /// <summary>
        /// Get Prospect.
        /// GET: coach/Prospects/GetNewProspects?skip=0&take=100&pageSize=100
        /// </summary>
        public List<ProspectModel> GetProspects()
        {
            var request = new RestRequest("coach/Prospects/GetNewProspects", Method.GET);
            request.AddParameter("skip", 0);
            request.AddParameter("take", 100);
            request.AddParameter("pageSize", 9999);
            var response = this._client.Get(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("[CoachServiceClient]-[GetProspect] error!");
            }

            var contents = JsonConvert.DeserializeObject<List<string>>(response.Content);
            //var prospects = JsonConvert.DeserializeObject<IList<ProspectModel>>(response.Content);
            var prospects = new List<ProspectModel>();
            foreach (var content in contents)
            {
                prospects.Add(JsonConvert.DeserializeObject<ProspectModel>(content));
            }
            return prospects;
        }

        /// <summary>
        /// Update Club information.
        /// POST: coach/ClubDetail.aspx?initialaction=edit&clubid={clubid}
        /// </summary>
        /// <param name="model"></param>
        public void CreateClub(ClubModel model)
        {
            var request = new RestRequest($"coach/ClubDetail.aspx?initialaction=create", Method.POST);
            //Fill form.
            request.AddParameter("ctl00$ddlSport", model.SportId);
            //request.AddParameter("ctl00$cphMain$clubDetails$fvClub$hdnClubId", model.Id);
            //request.AddParameter("ctl00$cphMain$clubDetails$fvClub$hdnSportId", model.SportId);

            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtName", model.Name);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtLeague", model.TeamName);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtLocation", model.Address.LocationName);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtAddress1", model.Address.AddressLine1);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtAddress2", model.Address.AddressLine2);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtAddress3", model.Address.AddressLine3);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtCity", model.Address.City);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtCounty", model.Address.County);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$ddlState", model.Address.StateId);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$ddlCountry", model.Address.CountryId);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtZip", model.Address.ZipCode);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtWebSite", model.ClubWebsite);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$TextBox9", model.MainPhoneNumber);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtSeasonRecord", model.SeasonRecord);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtRecentGameResults", model.RecentGameResults);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$TextBox7", model.HeadCoach.Title);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtFirstName", model.HeadCoach.FirstName);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtLastName", model.HeadCoach.LastName);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$TextBox8", model.HeadCoach.Suffix);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtPhone", model.HeadCoach.HomePhone);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtPhone2", model.HeadCoach.MobilePhone);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$TextBox4", model.HeadCoach.OfficePhone);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$TextBox2", model.HeadCoach.Email);
            //request.AddParameter("ctl00_cphMain_clubAssistants_gvAssistants_ClientState", string.Empty);
            request.AddParameter("ctl00$cphMain$clubProspects$grdRecruits$ctl00$ctl03$ctl01$PageSizeComboBox", "50");
            request.AddParameter("ctl00_cphMain_clubProspects_grdRecruits_ctl00_ctl03_ctl01_PageSizeComboBox_ClientState", "{ \"logEntries\":[],\"value\":\"50\",\"text\":\"50\",\"enabled\":true}");
            request.AddParameter("ctl00_cphMain_clubProspects_grdRecruits_ClientState", string.Empty);
            request.AddParameter("__ASYNCPOST", true);
            request.AddParameter("RadAJAXControlID", "ctl00_cphMain_rap1");
            

            var response = this._client.Post(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("[CoachServiceClient]-[GetProspect] error!");
            }
        }


        /// <summary>
        /// Update Club information.
        /// POST: coach/ClubDetail.aspx?initialaction=edit&clubid={clubid}
        /// </summary>
        /// <param name="model"></param>
        public void UpdateClub(ClubModel model)
        {
            var request = new RestRequest($"coach/ClubDetail.aspx?initialaction=edit&clubid={model.Id}", Method.POST);

            //Fill form.
            request.AddParameter("ctl00$ddlSport", "15");
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$hdnClubId", model.Id);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$hdnSportId", "15");

            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtName", string.Empty);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtLeague", model.TeamName);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtLocation", model.Address.LocationName);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtAddress1", model.Address.AddressLine1);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtAddress2", model.Address.AddressLine2);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtAddress3", model.Address.AddressLine3);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtCity", model.Address.City);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtCounty", model.Address.County);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$ddlState", model.Address.StateId);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$ddlCountry", model.Address.CountryId);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtZip", model.Address.ZipCode);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtWebSite", model.ClubWebsite);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$TextBox9", model.MainPhoneNumber);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtSeasonRecord", model.SeasonRecord);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtRecentGameResults", model.RecentGameResults);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$TextBox7", model.HeadCoach.Title);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtFirstName", model.HeadCoach.FirstName);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtLastName", model.HeadCoach.LastName);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$TextBox8", model.HeadCoach.Suffix);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtPhone", model.HeadCoach.HomePhone);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$txtPhone2", model.HeadCoach.MobilePhone);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$TextBox4", model.HeadCoach.OfficePhone);
            request.AddParameter("ctl00$cphMain$clubDetails$fvClub$TextBox2", model.HeadCoach.Email);
            request.AddParameter("ctl00_cphMain_clubAssistants_gvAssistants_ClientState", string.Empty);
            request.AddParameter("ctl00$cphMain$clubProspects$grdRecruits$ctl00$ctl03$ctl01$PageSizeComboBox", string.Empty);
            request.AddParameter("ctl00_cphMain_clubProspects_grdRecruits_ctl00_ctl03_ctl01_PageSizeComboBox_ClientState", string.Empty);
            request.AddParameter("ctl00_cphMain_clubProspects_grdRecruits_ClientState", string.Empty);

            var response = this._client.Post(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("[CoachServiceClient]-[GetProspect] error!");
            }
        }
        #endregion
    }
}
