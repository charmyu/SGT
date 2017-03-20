using Power.Model;
using System;
using System.Data;
using System.Web.Http;

namespace Power.Controllers
{
    public class EventLogController : ApiController
    {
        Power.BLL.EventLog eventBLL = new BLL.EventLog();

        /// <summary>
        /// 获取设备事件记录
        /// </summary>
        /// <param name="deviceid"></param>
        /// <returns></returns>
        public string GetDeviceEventLogByDeviceId(string deviceid, string btime, string etime)
        {
            string sqlwhere = "";
            if (deviceid == "00")
            {
                sqlwhere = string.Format(" rtr_TM BETWEEN '{0}' AND '{1}' ", btime, etime);
            }
            else
            {
                sqlwhere = string.Format(" deviceID='{0}' AND rtr_TM BETWEEN '{1}' AND '{2}' ", deviceid, btime, etime);
            }
            DataSet ds = eventBLL.GetAllRelationTable(sqlwhere);
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);
        }
    }
}