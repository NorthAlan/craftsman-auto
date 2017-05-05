using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core
{
    /// <summary>
    /// Management test setting.
    /// </summary>
    public class SettingManager
    {
        public static string GetAppSetting(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName];
        }
    }
}
