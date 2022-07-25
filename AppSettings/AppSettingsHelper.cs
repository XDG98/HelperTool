using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConfigurationHelper
{
    /// <summary>
    /// appsettings.json助手
    /// </summary>
    public class AppSettingsHelper
    {
        /// <summary>
        /// 配置
        /// </summary>
        public static IConfiguration Configuration { get; set; }
        static AppSettingsHelper()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .Add(new JsonConfigurationSource
                {
                    Path = "appsettings.json",
                    //ReloadOnChange = true; 当appsettings.json被修改时重新加载
                    ReloadOnChange = true
                })
                .Build();
        }

        /// <summary>
        /// 获取配置key
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        private static string GetKey(string[] sections)
        {
            var val = string.Empty;
            for (int i = 0; i < sections.Length; i++)
            {
                val += sections[i] + ":";
            }
            return val.TrimEnd(':');
        }

        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        public static string GetAppSettings(params string[] sections)
        {
            try
            {
                string key = GetKey(sections);
                return Configuration[key];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="dataDic">配置</param>
        /// <returns></returns>
        public static void GetAppSettings(ref Dictionary<string, string> dataDic)
        {
            try
            {
                foreach (var config in dataDic)
                {
                    dataDic[config.Key] = Configuration[config.Value];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        public static T GetAppSettings<T>(params string[] sections)
        {
            try
            {
                string key = GetKey(sections);
                return Configuration.GetSection(key).Get<T>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="key">配置键</param>
        /// <param name="value">配置值</param>
        /// <returns></returns>
        public static async Task SaveAppSettings(string key, string value)
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

                StreamReader streamReader = File.OpenText(filePath);
                JsonTextReader jsonTextReader = new JsonTextReader(streamReader);
                JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);

                jsonObject[key] = value;

                streamReader.Close();
                string contents = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                await File.WriteAllTextAsync(filePath, contents);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="dataDic">配置</param>
        /// <returns></returns>
        public static async Task SaveAppSettings(Dictionary<string, string> dataDic)
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

                StreamReader streamReader = File.OpenText(filePath);
                JsonTextReader jsonTextReader = new JsonTextReader(streamReader);
                JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);

                foreach (var item in dataDic)
                {
                    jsonObject[item.Key] = item.Value;
                }

                streamReader.Close();
                string contents = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                await File.WriteAllTextAsync(filePath, contents);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
