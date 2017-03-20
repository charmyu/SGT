using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class TempletController : ApiController
    {
        Power.BLL.Templet TempletBll = new BLL.Templet();
        /// <summary>
        /// 获取所有类型
        /// </summary>
        /// <returns></returns>
        public string GetAllTemplet()
        {
            // string result = "";
            DataSet ds = TempletBll.GetAllList();
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);

        }
        /// <summary>
        /// 删除用户类型
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string DelTemplet(string Uid)
        {
            string result = "";
            if (TempletBll.Delete(Uid))
            {
                result = "OK";
            }
            else
            {
                result = "Error";
            }
            return result;
        }

        /// <summary>
        /// 获取单个类型信息
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string GetTempletByUID(string Uid)
        {
            Power.Model.Templet type = TempletBll.GetModel(Uid);
            return ListToJson.OneObjectToJSON(type);
        }


        /// <summary>
        /// 保存参数类型
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="typeid"></param>
        /// <param name="typename"></param>
        /// <returns></returns>
        public string SaveTemplet(string Uid, string Templetname, string Memo)
        {
            string result = "";

            System.Guid guid = System.Guid.NewGuid(); //Guid 类型
            string strGUID = System.Guid.NewGuid().ToString(); //直接返回字符串类型

            Power.Model.Templet templet = new Model.Templet();

            templet.templetname = Templetname;
            templet.memo = Memo;

            if (Uid == "" || Uid == null)
            {
                templet.ID = strGUID;
                if (TempletBll.Add(templet))
                {
                    result = "OK";
                }
                else
                {
                    result = "Error";
                }
            }
            else
            {
                templet.ID = Uid;
                if (TempletBll.Update(templet))
                {
                    result = "OK";
                }
                else
                {
                    result = "Error";
                }
            }

            return result;
        }
    }
}