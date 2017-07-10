using Craftsman.Core;
using Craftsman.Core.Factory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Craftsman.Core.Utilities
{
    public class RouteMapper
    {
        private IWebDriver _driver;

        private Dictionary<string, string> _dicMap;

        private Dictionary<string, string> _dicAppBaseUrl;

        public RouteMapper(IWebDriver driver)
        {
            this._driver = driver;
        }

        /// <summary>
        /// bulid base url
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        protected string BuildBaseUrl(string appName)
        {
            var baseUrl = string.Empty;
            var environment = SettingManager.GetAppSetting(SettingName.ENVIRONMENT);

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

        public void SetUpPageObject(Type type, string subPath, string appName)
        {
            var keyPageObject = type.FullName;
            var url = string.Format("{0}/{1}", BuildBaseUrl(appName), subPath);

            if (_dicMap.ContainsKey(keyPageObject))
            {
                throw new Exception(string.Format("[Craftsman] : Can't add same page object key {0}", keyPageObject));
            }
            _dicMap.Add(keyPageObject, url);
        }

        public void SetUpBaseUrl(string appName, string baseUrl)
        {
            if (_dicAppBaseUrl == null)
            {
                _dicAppBaseUrl = new Dictionary<string, string>();
            }
            if (_dicAppBaseUrl.ContainsKey(appName))
            {
                throw new Exception(string.Format("[Craftsman] : Can't add same app key {0}", appName));
            }

            _dicAppBaseUrl.Add(appName, baseUrl);
        }

        protected string BuildPageUrl(string appName, string subUrl)
        {
            var baseUrl = BuildBaseUrl(appName);
            return string.Format("{0}/{1}", baseUrl, subUrl);
        }

        #region 
        public T GoTo<T>() where T : PageObjectBase
        {
            var key = typeof(T).FullName;
            _driver.Url = _dicMap[key];
            return CraftsmanFactory.CreatePageObject<T>(_driver);
        }

        public T Build<T>() where T : PageObjectBase
        {
            return CraftsmanFactory.CreatePageObject<T>(_driver);
        }

        #endregion
    }
}
