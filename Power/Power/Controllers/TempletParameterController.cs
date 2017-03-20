using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class TempletParameterController : ApiController
    {
        Power.BLL.TempletPara tpBLL = new BLL.TempletPara();
       /// <summary>
       /// 获取模板中的参数
       /// </summary>
       /// <param name="templet"></param>
       /// <param name="paramID"></param>
       /// <returns></returns>
        public string GetTempletParam(string templet, string mark)
        {
            string sqlwhere = "";
            if (mark == "in")
            {
                //模板中已有参数
                sqlwhere = string.Format(" ID in( select parameterID from dbo.TempletPara  where templetID='{0}')", templet);

            }
            else {
                sqlwhere = string.Format(" ID not in( select parameterID from dbo.TempletPara  where templetID='{0}') order by parametername", templet);   
            }
            DataSet ds = tpBLL.GetTempletParaByTID(sqlwhere);
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);
        }
        /// <summary>
        /// 多表查询获取模板参数
        /// </summary>
        /// <param name="tempID">模板ID</param>
        /// <returns></returns>
        public string GetTempletParamByTempID(string tempID)
        {
            DataSet ds = tpBLL.GetTempletParaByTempletID(tempID);
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string DelTempletParam(string Uid)
        {
            string result = "";
            if (tpBLL.Delete(Uid))
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
        /// 获取单个信息
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string GetParameterByUID(string Uid)
        {
            Power.Model.TempletPara tparam = tpBLL.GetModel(Uid);
            if (tparam != null)
            {
                return ListToJson.OneObjectToJSON(tparam);
            }
            else {
                return "";
            }
        }
       /// <summary>
       /// 保存模板参数
       /// </summary>
       /// <param name="Uid"></param>
       /// <param name="paramid"></param>
       /// <param name="tempid"></param>
       /// <param name="paramindex"></param>
       /// <returns></returns>
        public string SaveTempletParameter(string Uid, string paramid, string tempid,string paramindex)
        {
            string result = "";

            System.Guid guid = System.Guid.NewGuid(); //Guid 类型
            string strGUID = System.Guid.NewGuid().ToString(); //直接返回字符串类型

            Power.Model.TempletPara tparam = new Model.TempletPara();

            tparam.parameterID = paramid;
            tparam.templetID = tempid;
            tparam.parameterindex = Convert.ToInt32(paramindex);

            if (Uid == "" || Uid == null)
            {
                tparam.ID = strGUID;
                if (tpBLL.Add(tparam))
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
                tparam.ID = Uid;
                if (tpBLL.Update(tparam))
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