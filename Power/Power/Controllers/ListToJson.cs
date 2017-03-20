using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Power.Controllers
{
    public class ListToJson
    {

        //
        // ObjectListToJSON
        // Copyright (c) 2008 pcode. All rights reserved.
        //
        //  Author(s):
        //
        //      pcode,jy@cjlu.edu.cn
        //  此类用于将List<object>转换为json数据格式
        //  目前仅能处理一个object的基础数据类型而且对[ { }] \等对json有伤害影响特殊符号没有特殊处理
        //  希望有兄弟继续完善


        #region 反射一个对象所有属性和属性值和将一个对象的反射结果封装成jsons格式
        /**
         * 对象的全部属性和属性值。用于填写json的{}内数据
         * 生成后的格式类似
         * "属性1":"属性值"
         * 将这些属性名和属性值写入字符串列表返回
         * */
        public static List<string> GetObjectProperty(object o)
        {
            List<string> propertyslist = new List<string>();
            PropertyInfo[] propertys = o.GetType().GetProperties();
            foreach (PropertyInfo p in propertys)
            {
                propertyslist.Add("\"" + p.Name.ToString() + "\":\"" + p.GetValue(o, null) + "\"");
            }
            return propertyslist;
        }
        /**
         * 将一个对象的所有属性和属性值按json的格式要求输入为一个封装后的结果。
         *
         * 返回值类似{"属性1":"属性1值","属性2":"属性2值","属性3":"属性3值"}
         * 
         * */
        public static string OneObjectToJSON(object o)
        {
            string result = "{";
            List<string> ls_propertys = new List<string>();
            ls_propertys = GetObjectProperty(o);
            foreach (string str_property in ls_propertys)
            {
                if (result.Equals("{"))
                {
                    result = result + str_property;
                }
                else
                {
                    result = result + "," + str_property + "";
                }
            }
            return result + "}";
        }
        #endregion
        /**
         * 把对象列表转换成json串
         * */
        public static string toJSON(List<object> objlist)
        {//覆写，给懒人一个不写classname的机会
            return toJSON(objlist, string.Empty);
        }
        public static string toJSON(List<object> objlist, string classname)
        {
            if (objlist.Count > 0)
            {
                string result = "{";
                if (classname.Equals(string.Empty))//如果没有给定类的名称，那么自做聪明地安一个
                {
                    object o = objlist[0];
                    classname = o.GetType().ToString();
                }
                result += "\"" + classname + "\":[";
                bool firstline = true;//处理第一行前面不加","号
                foreach (object oo in objlist)
                {
                    if (!firstline)
                    {
                        result = result + "," + OneObjectToJSON(oo);
                    }
                    else
                    {
                        result = result + OneObjectToJSON(oo) + "";
                        firstline = false;
                    }
                }
                return result + "]}";
            }
            else
            {
                return "";
            }
        }

        #region dataTable转换成Json格式
        /// <summary>  
        /// dataTable转换成Json格式  
        /// </summary>  
        /// <param name="dt"></param>  
        /// <returns></returns>  
        public static string DataTable2Json(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"");
            jsonBuilder.Append(dt.TableName);
            jsonBuilder.Append("\":[");
            jsonBuilder.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        #endregion dataTable转换成Json格式
        #region DataSet转换成Json格式
        /// <summary>  
        /// DataSet转换成Json格式  
        /// </summary>  
        /// <param name="ds">DataSet</param> 
        /// <returns></returns>  
        public static string Dataset2Json(DataSet ds)
        {
            StringBuilder json = new StringBuilder();

            foreach (DataTable dt in ds.Tables)
            {
                json.Append("{\"");
                json.Append(dt.TableName);
                json.Append("\":");
                json.Append(DataTable2Json(dt));
                json.Append("}");
            } return json.ToString();
        }
        #endregion

        /// <summary>
        /// dataTable转换成Json格式
        /// </summary>
        /// <param name="jsonName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(string jsonName, DataTable dt)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + dt.Rows[i][j].ToString() + "\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();
        }

        /// <summary>
        /// 科学计数法转数字
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        private static Decimal ChangeDataToD(string strData)
        {
            Decimal dData = 0.0M;
            if (strData.Contains("E"))
            {
                dData = Convert.ToDecimal(Decimal.Parse(strData.ToString(), System.Globalization.NumberStyles.Float));
            }
            return dData;
        }
    }
}