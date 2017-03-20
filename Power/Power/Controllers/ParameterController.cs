using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class ParameterController : ApiController
    {
        Power.BLL.TempletPara tpBLL = new BLL.TempletPara();
        Power.BLL.Parameter paramBLL = new BLL.Parameter();
        /// <summary>
        /// 获取所有参数
        /// </summary>
        /// <returns></returns>
        public string GetAllParameter()
        {
            // string result = "";
            DataSet ds = paramBLL.GetAllList();
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);

        }

        public string GetAllParameter(string deviceID, string SendID)
        {
            // string result = "";
            DataSet ds = paramBLL.GetAllList(SendID);
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);
        }
        /// <summary>
        /// 删除参数
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string DelUser(string Uid, string tID)
        {
            string result = "";
            if (paramBLL.Delete(Uid))
            {
                tpBLL.DeleteList(string.Format(" select ID from TempletPara where templetID='{0}' and parameterID='{1}'", tID, Uid));
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
            Power.Model.Parameter type = paramBLL.GetModel(Uid);
            return ListToJson.OneObjectToJSON(type);
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="devID">设备ID</param>
        /// <param name="senderID">模块NO  发送ID</param>
        /// <returns></returns>
        public string GetParameterByDeviceID(string devID, string senderID)
        {

            DataSet ds = paramBLL.GetParamListByDeviceID(string.Format(" Device.ID='{0}' and Parameter.SenderID='{1}' and Parameter.parametertypeid=1", devID, senderID));

            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);

        }
        /// <summary>
        /// 保存参数
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="tID">型号ID</param>
        /// <param name="parametername"></param>
        /// <param name="parametertypeid"></param>
        /// <param name="datatype"></param>
        /// <param name="datastartbit"></param>
        /// <param name="datalen"></param>
        /// <param name="databit"></param>
        /// <param name="code"></param>
        /// <param name="cmd"></param>
        /// <param name="SenderID"></param>
        /// <param name="TargetID"></param>
        /// <param name="unit"></param>
        /// <param name="k"></param>
        /// <param name="b"></param>
        /// <param name="DefaultValue"></param>
        /// <param name="IsSave"></param>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public string SaveParameter(string Uid,string tID, string parametername, string parametertypeid, string datatype, string datastartbit, string datalen, string databit, string code, string cmd, string SenderID, string TargetID, string unit, string k, string b, string DefaultValue, string IsSave, string usertype, string memo, string high,string low)
        {
            string result = "";

            System.Guid guid = System.Guid.NewGuid(); //Guid 类型
            string strGUID = System.Guid.NewGuid().ToString(); //直接返回字符串类型

            Power.Model.Parameter param = new Model.Parameter();

            param.b =Convert .ToInt32 (b);
            param.cmd = cmd;
            param.code = code;
            param.databit = Convert.ToInt32(databit);
            param.datalen = Convert.ToInt32(datalen );
            param.datastartbit = Convert.ToInt32(datastartbit);
            param.datatype = datatype;
            param.DefaultValue =Convert .ToInt32 ( DefaultValue);
            param.IsSave =Convert .ToInt32 ( IsSave);
            param.k = Convert.ToInt32(k);
            param.parametername = parametername;
            param.parametertypeid =Convert .ToInt32( parametertypeid);
            param.SenderID =SenderID;
            param.TargetID = Convert.ToInt32(TargetID);
            param.unit = unit;
            param.usertype = Convert.ToInt32(usertype);
            param.Memo = memo;
            param.LowVal = low;
            param.HighVal = high;

            if (Uid == "" || Uid == null)
            {
                param.ID = strGUID;
                if (paramBLL.Add(param))
                {
                    result = "OK";
                    SaveTempletParameter(strGUID, tID,1);
                }
                else
                {
                    result = "Error";
                }
            }
            else
            {
                param.ID = Uid;
                if (paramBLL.Update(param))
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

        public void SaveTempletParameter(string paramid, string tempid, int index)
        {

           
            System.Guid guid = System.Guid.NewGuid(); //Guid 类型
            string strGUID = System.Guid.NewGuid().ToString(); //直接返回字符串类型

            Power.Model.TempletPara tparam = new Model.TempletPara();

            tparam.parameterID = paramid;
            tparam.templetID = tempid;
            tparam.parameterindex = index;
            tparam.ID = strGUID;
            tpBLL.Add(tparam);
          
        }
   
    }
}