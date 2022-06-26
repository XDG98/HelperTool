using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HelperTool.ConfigurationHelper
{
    public class AppSettingsHelper
    {
        static IConfiguration Configuration { get; set; }
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
        /// 获取配置文件
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        public static string GetAppSettings(params string[] sections)
        {
            var val = string.Empty;
            for (int i = 0; i < sections.Length; i++)
            {
                val += sections[i] + ":";
            }

            return Configuration[val.TrimEnd(':')];
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        public static async Task SaveAppSettings(string key, string value)
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

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        public static async Task SaveAppSettings(Dictionary<string, string> dataDic)
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
    }
}
