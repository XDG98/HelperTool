using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationHelper
{
    /// <summary>
    /// App.config助手
    /// </summary>
    public class AppConfigHelper
    {
        public static string GetAppSettings(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static string SaveAppSettings(string key)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["Debug"].Value = "0";

                configuration.Save(ConfigurationSaveMode.Modified);

                //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //增加节点
                //configuration.AppSettings.Settings.Add("Test2", "456");
                //configuration.Save(ConfigurationSaveMode.Modified);
                //ConfigurationManager.RefreshSection("App.config");
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
