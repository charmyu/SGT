using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class RT_CPointController : ApiController
    {

        Power.BLL.RT_CPoint rtcpointBLL = new BLL.RT_CPoint();
        /// <summary>
        /// 获取设备实时数据
        /// </summary>
        /// <param name="deviceid"></param>
        /// <returns></returns>
        public bool SetParameter(string ModuleID, string prarmeterID, string SetVal)
        {
            Power.Model.RT_CPoint model = new Model.RT_CPoint();
            model.ID = Guid.NewGuid().ToString();
            model.ModuleID = ModuleID;
            model.prarmeterID = prarmeterID;
            model.paraName = string.Empty;
            model.RTVal = 0m;
            model.SetVal = SetVal;
            model.Status = 1;
            model.TM = DateTime.Now;
            return rtcpointBLL.Add(model); 
        }
        public bool SetParameter()
        {
            Power.Model.RT_CPoint model = new Model.RT_CPoint();
            model.ID = Guid.NewGuid().ToString();
            model.ModuleID = "0x0";
            model.prarmeterID = "0x0";
            model.paraName = string.Empty;
            model.RTVal = 0m;
            model.SetVal = "command";
            model.Status = 1;
            model.TM = DateTime.Now;
            return rtcpointBLL.Add(model);
        }
    }
}