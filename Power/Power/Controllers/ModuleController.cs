using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class ModuleController : ApiController
    {
        Power.BLL.Module mBll = new BLL.Module();
        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <returns></returns>
        public string GetAllModule()
        {
            string result = "";
            bool bl = CurrentUser.IsLogon;
            if (bl)
            {
                DataSet ds = mBll.GetAllList(string.Format(" 1=1"));
                result = ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }
            return result;

        }
        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string DelModule(string Uid)
        {
            string result = "";
            if (mBll.Delete(Uid))
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
        /// 获取单个模块信息
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string GetModuleByUID(string Uid)
        {
            Power.Model.Module type = mBll.GetModel(Uid);
            return ListToJson.OneObjectToJSON(type);
        }


        /// <summary>
        /// 保存模块信息
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="typeid"></param>
        /// <param name="typename"></param>
        /// <returns></returns>
        public string SaveModule(string Uid, string name, string deviceID, string state,  string templetID,string NO)
        {
            string result = "";

            System.Guid guid = System.Guid.NewGuid(); //Guid 类型
            string strGUID = System.Guid.NewGuid().ToString(); //直接返回字符串类型

            Power.Model.Module module = null;
            if (Uid == "" || Uid == null)
            {
                module = new Model.Module();

            }
            else
            {
                module = mBll.GetModel(Uid);
            }
            module.NO = NO;
            module.deviceID = deviceID;
            module.ModuleName = name;
            module.state = Convert.ToInt32(state);
            module.templetID = templetID;
           
            


            if (Uid == "" || Uid == null)
            { 
                module.TM = DateTime.Now;
                module.ID = strGUID;
                if (mBll.Add(module))
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
                module.ID = Uid;
                if (mBll.Update(module))
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
       
        /// <summary>
        /// 获取设备下的模块信息
        /// </summary>
        /// <param name="templetID">设备型号ID</param>
        /// <returns></returns>
        public string GetModuleByDeviceId(string templetID, int id)
        {

            DataSet ds = mBll.GetList(string.Format("  templetID='{0}'", templetID));
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);
        }

        /// <summary>
        /// 获取设备下的模块信息
        /// </summary>
        /// <param name="deviceid">设备ID</param>
        /// <returns></returns>
        public string ModuleByDeviceId(string deviceid)
        {
            DataSet ds=null;
            Power.Model.Device model = new Power.BLL.Device().GetModel(deviceid);
            if (model != null)
            {

                 ds = mBll.GetList(string.Format("  templetID='{0}'", model.templetID ));
            }
            if (ds!=null&&ds.Tables.Count > 0)
            {
                return ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }
            else
            {
                return "{'Rows':[]}";
            }
        }
    }
}