using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class ParameterTypeController : ApiController
    {
        Power.BLL.ParameterType paramtypeBll = new BLL.ParameterType();
        /// <summary>
        /// 获取所有类型
        /// </summary>
        /// <returns></returns>
        public string GetAllParameterType()
        {
            // string result = "";
            DataSet ds = paramtypeBll.GetAllList();
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);

        }
        /// <summary>
        /// 删除用户类型
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string DelParamtype(string Uid)
        {
            string result = "";
            if (paramtypeBll.Delete(Uid))
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
        public string GetParameterTypeByUID(string Uid)
        {
            Power.Model.ParameterType type = paramtypeBll.GetModel(Uid);
            return ListToJson.OneObjectToJSON(type);
        }


        /// <summary>
        /// 保存参数类型
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="typeid"></param>
        /// <param name="typename"></param>
        /// <returns></returns>
        public string SaveParameterType(string Uid, string typeid, string typename)
        {
            string result = "";

            System.Guid guid = System.Guid.NewGuid(); //Guid 类型
            string strGUID = System.Guid.NewGuid().ToString(); //直接返回字符串类型

            Power.Model.ParameterType paramtype = new Model.ParameterType();

            paramtype.parametertype = Convert.ToInt32(typeid);
            paramtype.parametertypename = typename;

            if (Uid == "" || Uid == null)
            {
                paramtype.ID = strGUID;
                if (paramtypeBll.Add(paramtype))
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
                paramtype.ID = Uid;
                if (paramtypeBll.Update(paramtype))
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