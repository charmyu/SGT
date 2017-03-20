using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class RT_APointController : ApiController
    {

        Power.BLL.RT_APoint rtapointBLL = new BLL.RT_APoint();
        /// <summary>
        /// 获取设备实时数据
        /// </summary>
        /// <param name="deviceid"></param>
        /// <returns></returns>
        public string GetDeviceDataByDeviceId(string deviceid)
        {
            DataSet ds = rtapointBLL.GetList(string.Format("  ModuleID='{0}'", deviceid));
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);
        }
    }
}