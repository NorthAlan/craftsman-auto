using Craftsman.Core.AppSetting;
using System;
using System.Collections.Generic;

namespace Craftsman.Core.Tools
{
    public class RouteMapper
    {
        //private static Dictionary<PageAlias, string> _dicMap;
        private static Dictionary<string, string> _dicMap;

        static RouteMapper()
        {
            InitializationDicMap();
        }

        /// <summary>
        /// bulid base url
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        protected static string BuildBaseUrl(string appName)
        {
            var baseUrl = string.Empty;
            var environment = TestSettingManager.GetAppSetting(SettingName.ENVIRONMENT);

            if (environment != "QA")
            {
                throw new Exception("[Craftsman] : Unknown environment type!");
            }

            switch (appName)
            {
                case "AppAlias.Coach":
                    baseUrl = "https://college-china.jumpforward.com";
                    break;
                case "AppAlias.Elevation":
                    baseUrl = "http://elevation-test.jumpforward.com";
                    break;
                default: throw new Exception("[Craftsman] : Unknown application name.");
            }
            return baseUrl.ToLower();
        }

        public static string BuildPageUrl(string appName, string subUrl)
        {
            var baseUrl = BuildBaseUrl(appName);
            return string.Format("{0}/{1}", baseUrl, subUrl);
        }

        private static void InitializationDicMap()
        {
            _dicMap = new Dictionary<string, string>(100);

            var baseUrl = string.Empty;

            #region Coach
            baseUrl = BuildBaseUrl("AppAlias.Coach");
            _dicMap.Add("AppAlias.Coach_SignIn", string.Format("{0}/#/Login", baseUrl));
            #endregion Coach

            #region Elevation
            baseUrl = BuildBaseUrl("AppAlias.Elevation");
            _dicMap.Add("AppAlias.Elevation_SignIn", string.Format("{0}/#/Login", baseUrl));
            #endregion Elevation
        }
    }
}
