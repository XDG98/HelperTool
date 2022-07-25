// See https://aka.ms/new-console-template for more information
using ConfigurationHelper;
using NetworkHelper;

Dictionary<string, string> dic = new Dictionary<string, string>();
dic.Add("Test1", "Test1");
dic.Add("CTest2_1", "Test2:CTest2_1");
dic.Add("CCTest2_1", "Test2:CTest2_2:CCTest2_1");
AppSettingsHelper.GetAppSettings(ref dic);
foreach (var item in dic)
{
    Console.WriteLine($"{item.Key}：{item.Value}");
}
List<string> a = AppSettingsHelper.GetAppSettings<List<string>>("Test2", "CTest2_2", "BrowserOptions");
Console.WriteLine(a);

Console.ReadKey();
