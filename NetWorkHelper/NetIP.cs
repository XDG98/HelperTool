using HelperTool.NetWorkHelper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HelperTool.NetworkHelper
{
    /// <summary>
    /// 网络IP
    /// </summary>
    public static class NetIP
    {
        /// <summary>
        /// 获取本地机器名
        /// </summary>
        /// <returns>本地机器名</returns>
        public static string GetHostName()
        {
            return Dns.GetHostName();
        }

        /// <summary>
        /// 获取本地IPv4
        /// </summary>
        /// <returns>本地IPv4</returns>
        public static string GetCurrentLocalIPv4()
        {
            string _myHostName = GetHostName();
            return Dns.GetHostEntry(_myHostName).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
        }

        /// <summary>
        /// 获取本地IPv6
        /// </summary>
        /// <returns>本地IPv6</returns>
        public static string GetCurrentLocalIPv6()
        {
            string _myHostName = GetHostName();
            return Dns.GetHostEntry(_myHostName).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetworkV6")).ToString();
        }

        /// <summary>
        /// 获取局域网IPv4
        /// </summary>
        /// <returns>局域网IPv4</returns>
        public static async Task<List<string>> GetCurrentLocalAreaNetworkIPv4()
        {
            List<string> ipList = new List<string>();

            string _myIPv4HostIP = GetCurrentLocalIPv4();
            //截取IP网段
            string ipDuan = _myIPv4HostIP.Remove(_myIPv4HostIP.LastIndexOf('.'));
            //枚举网段计算机
            Ping myPing = new Ping();
            for (int i = 1; i <= 255; i++)
            {
                string pingIP = ipDuan + "." + i.ToString();
                PingReply pingReply = await myPing.SendPingAsync(pingIP);
                if (pingReply.Status == IPStatus.Success)
                {
                    ipList.Add(pingIP);
                }
            }

            return ipList;
        }

        /// <summary>  
        /// 根据IP获取物理地址  
        /// </summary>  
        /// <param name="ip">Ip地址</param>  
        /// <returns></returns>  
        public static async Task<object> GetIpAddress(string ip)
        {
            string url = $"http://ip-api.com/json/{ip}?lang=zh-CN";
            return await HttpClienttHelper.Get(url);
        }
    }
}
