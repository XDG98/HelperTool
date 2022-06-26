using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Json;

namespace HelperTool.NetWorkHelper
{
    public class HttpClienttHelper
    {
        public static readonly IHttpClientFactory httpClientFactory;
        static HttpClienttHelper()
        {
            httpClientFactory = new ServiceCollection()
                .AddHttpClient()
                .BuildServiceProvider()
                .GetRequiredService<IHttpClientFactory>();
        }

        public static async Task<object> Get(string url)
        {
            try
            {
                HttpClient httpClient = httpClientFactory.CreateClient();
                return await httpClient.GetFromJsonAsync<object>(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<object> Post(string url, string parameter)
        {
            try
            {
                HttpClient httpClient = httpClientFactory.CreateClient();
                return await httpClient.PostAsJsonAsync<object>(url, parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
