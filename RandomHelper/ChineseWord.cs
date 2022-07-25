using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateHelper
{
    /// <summary>
    /// 随机中文汉字
    /// </summary>
    public static class ChineseWord
    {
        static ChineseWord()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        /// <summary>
        /// 获取一个中文汉字
        /// </summary>
        /// <returns>一个中文汉字</returns>
        public static string GetOneChineseWord()
        {
            return GetDefinedChineseWord(1);
        }

        /// <summary>
        /// 获取两个中文汉字
        /// </summary>
        /// <returns>两个中文汉字</returns>
        public static string GetTwoChineseWord()
        {
            return GetDefinedChineseWord(2);
        }

        /// <summary>
        /// 获取三个中文汉字
        /// </summary>
        /// <returns>三个中文汉字</returns>
        public static string GetThreeChineseWord()
        {
            return GetDefinedChineseWord(3);
        }

        /// <summary>
        /// 获取指定数量的中文汉字
        /// </summary>
        /// <param name="num">要生成汉字的个数</param>
        /// <returns>指定数量的中文汉字</returns>
        public static string GetDefinedChineseWord(int num)
        {
            List<string> chineseWords = GetDefinedChineseWordList(num);

            return string.Join("", chineseWords);
        }

        /// <summary>
        /// 获取指定数量的中文汉字
        /// </summary>
        /// <param name="num">要生成汉字的个数</param>
        /// <returns>指定数量的中文汉字</returns>
        public static List<string> GetDefinedChineseWordList(int num)
        {
            List<string> chineseWords = GenerateChineseWordList(num);

            return chineseWords;
        }
        
        /// <summary>
        /// 生成中文汉字
        /// </summary>
        /// <param name="num">要生成汉字的个数</param>
        /// <returns>中文汉字</returns>
        public static List<string> GenerateChineseWordList(int num)
        {
            List<string> chineseWords = new List<string>();
            Random rm = new Random();
            Encoding gb = Encoding.GetEncoding("GB2312");

            for (int i = 0; i < num; i++)
            {
                // 获取区码(常用汉字的区码范围为16-55)
                int regionCode = rm.Next(16, 56);
                // 获取位码(位码范围为1-94 由于55区的90,91,92,93,94为空,故将其排除)
                int positionCode;
                if (regionCode == 55)
                {
                    // 55区排除90,91,92,93,94
                    positionCode = rm.Next(1, 90);
                }
                else
                {
                    positionCode = rm.Next(1, 95);
                }

                // 转换区位码为机内码
                int regionCode_Machine = regionCode + 160;// 160即为十六进制的20H+80H=A0H
                int positionCode_Machine = positionCode + 160;// 160即为十六进制的20H+80H=A0H

                // 转换为汉字
                byte[] bytes = new byte[] { (byte)regionCode_Machine, (byte)positionCode_Machine };
                chineseWords.Add(gb.GetString(bytes));
            }

            return chineseWords;
        }

    }
}
