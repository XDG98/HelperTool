using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperTool.DataHelper
{
    /// <summary>
    /// DataTable转换
    /// </summary>
    public static class DataTableConvert
    {
        /// <summary>
        /// DataTable转换为List<T>对象
        /// </summary>
        /// <param name="dataTable">DataTable 对象</param>
        /// <returns>List<T>集合</returns>
        public static List<T> DataTableToList<T>(DataTable dataTable) where T : class, new()
        {
            // 定义集合
            List<T> ts = new List<T>();
            //定义一个临时变量
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行
            foreach (DataRow dr in dataTable.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性
                System.Reflection.PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性
                foreach (System.Reflection.PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量
                                       //检查DataTable是否包含此列（列名==对象的属性名）
                    if (dataTable.Columns.Contains(tempName))
                    {
                        //取值
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                //对象添加到泛型集合中
                ts.Add(t);
            }
            return ts;
        }

        /// <summary>
        /// DataTable转换为Json
        /// </summary>
        /// <param name="dataTable">DataTable 对象</param>
        /// <returns>JSON字符串</returns>
        public static string DataTableToJson(DataTable dataTable)
        {
            //定义ArrayList
            ArrayList arrayList = new ArrayList();
            //遍历DataTable中所有的数据行
            foreach (DataRow dr in dataTable.Rows)
            {
                //定义字典【列名，值】
                Dictionary<string, object> columnsDic = new Dictionary<string, object>();
                //遍历DataTable中所有的数据列
                foreach (DataColumn dc in dataTable.Columns)
                {
                    //字典添加列名，值
                    columnsDic.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                //arrayList添加字典
                arrayList.Add(columnsDic);
            }
            //序列化
            return JsonConvert.SerializeObject(arrayList);
        }
    }
}
