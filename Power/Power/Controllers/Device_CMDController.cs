using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class Device_CMDController : ApiController
    {
        Power.BLL.Device_CMD cmdBll = new BLL.Device_CMD();
        /// <summary>
        /// 获取所有类型
        /// </summary>
        /// <returns></returns>
        public string GetAllDeviceCMD()
        {
            // string result = "";
            DataSet ds = cmdBll.GetAllList();
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);

        }
        /// <summary>
        /// 删除用户类型
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string DelUser(string Uid)
        {
            string result = "";
            if (cmdBll.Delete(Uid))
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
        public string GetDeviceCMDByUID(string Uid)
        {
            Power.Model.Device_CMD cmd = cmdBll.GetModel(Uid);
            return ListToJson.OneObjectToJSON(cmd);
        }

        public string SaveDeviceCMD(string Uid, string cmd, string cmdname)
        {
            string result = "";

            System.Guid guid = System.Guid.NewGuid(); //Guid 类型
            string strGUID = System.Guid.NewGuid().ToString(); //直接返回字符串类型

            Power.Model.Device_CMD cmdModel = new Model.Device_CMD();

            cmdModel.CMD = cmd;
            cmdModel.CMDName = cmdname;

            if (Uid == "" || Uid == null)
            {
                cmdModel.ID = strGUID;
                if (cmdBll.Add(cmdModel))
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
                cmdModel.ID = Uid;
                if (cmdBll.Update(cmdModel))
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