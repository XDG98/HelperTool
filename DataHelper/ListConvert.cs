using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperTool.DataHelper
{
    /// <summary>
    /// List转换
    /// </summary>
    public static class ListConvert
    {
        /// <summary>
        /// List<T>转换为DataTable
        /// </summary>
        /// <param name="list">请求的list</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(List<T> list)
        {
            //创建一个空表
            DataTable dt = new DataTable(typeof(T).Name);

            //创建传入对象名称的列
            foreach (var item in list.FirstOrDefault().GetType().GetProperties())
            {
                dt.Columns.Add(item.Name);
            }
            //循环存储
            foreach (var item in list)
            {
                //新加行
                DataRow value = dt.NewRow();
                //根据DataTable中的值，进行对应的赋值
                foreach (DataColumn dtColumn in dt.Columns)
                {
                    int i = dt.Columns.IndexOf(dtColumn);
                    //基元元素，直接复制，对象类型等，进行序列化
                    if (value.GetType().IsPrimitive)
                    {
                        value[i] = item.GetType().GetProperty(dtColumn.ColumnName).GetValue(item);
                    }
                    else
                    {
                        value[i] = JsonConvert.SerializeObject(item.GetType().GetProperty(dtColumn.ColumnName).GetValue(item));
                    }
                }
                dt.Rows.Add(value);
            }

            return dt;
        }

        /// <summary>
        /// List<T>转换为Json
        /// </summary>
        /// <param name="list">请求的list</param>
        /// <returns></returns>
        public static string ListToJson<T>(List<T> list)
        {
            return JsonConvert.SerializeObject(list);
        }
    }
}
