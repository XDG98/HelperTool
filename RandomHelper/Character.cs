using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperTool.GenerateHelper
{
    /// <summary>
    /// 字符
    /// </summary>
    public static class Character
    {
        /// <summary>
        /// 获取一个字符
        /// </summary>
        /// <returns></returns>
        public static string GetOneCharacter()
        {
            return GenerateCharacter(1);
        }

        /// <summary>
        /// 获取四个字符
        /// </summary>
        /// <returns></returns>
        public static string GetFourCharacter()
        {
            return GenerateCharacter(4);
        }

        /// <summary>
        /// 获取六个字符
        /// </summary>
        /// <returns></returns>
        public static string GetSixCharacter()
        {
            return GenerateCharacter(6);
        }

        /// <summary>
        /// 获取指定数量字符
        /// </summary>
        /// <param name="num">要生成字符的个数</param>
        /// <returns></returns>
        public static string GetDefinedCharacter(int num)
        {
            return GenerateCharacter(num);
        }

        /// <summary>
        /// 生成字符
        /// </summary>
        /// <param name="num">要生成字符的个数</param>
        /// <returns></returns>
        public static string GenerateCharacter(int num)
        {
            string code = string.Empty;

            List<string> str = new List<string>()
            {
                "0","1","2","3","4","5","6","7","8","9",
                "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
                "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"
            };

            Random random = new Random();
            for (int i = 0; i < num; i++)
            {
                code += str[random.Next(0, str.Count)];
            }

            return code;
        }
    }
}
