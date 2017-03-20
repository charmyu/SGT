using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class SelectDataController : ApiController
    {
        Power.BLL.Device devBLL = new BLL.Device();
        /// <summary>
        /// 获取设备实时数据
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public string GetDeviceData(string deviceId)
        {
            string result = "";
            bool bl = CurrentUser.IsLogon;
            if (bl)
            {
                DataSet ds = devBLL.GetDevcieDataList(string.Format("d.ID='{0}' and p.usertype<={1}", deviceId, CurrentUser.UserTypeID));
                result = ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }
            return result;

        }


        /// <summary>
        /// 获取设备实时数据
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        public string GetDeviceDataByModuleID(string deviceId, string moduleID)
        {
            string result = "";
            bool bl = CurrentUser.IsLogon;
            if (bl)
            {
                DataSet ds = devBLL.GetDevcieDataList(string.Format("d.ID='{0}' and p.usertype<={1} and p.SenderID='{2}'", deviceId, CurrentUser.UserTypeID,moduleID));
                result = ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }
            return result;

        }

        /// <summary>
        /// 获取设备历史数据
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public string GetDevcieHistoricalData(string devId, string hisdata)
        {
            string result = "";
            bool bl = CurrentUser.IsLogon;
            if (bl)
            {
                DataSet ds = devBLL.GetDevcieHistoricalData(string.Format("d.ID='{0}' and p.usertype>={1}", devId, CurrentUser.UserTypeID));
                result = ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }
            return result;

        }


        /// <summary>
        /// 获取设备主要数据
        /// </summary>
        /// <param name="sname">基站名称</param>
        /// <param name="NO">设备序列号</param>
        /// <param name="depID">机构ID</param>
        /// <returns></returns>
        public string GetDevcieMainData(string sname, string NO, string depID)
        {
            string result = "";
            string sql = "";
            if (!string .IsNullOrEmpty(sname))
            {
                sql += string.Format(" and dbo.Device.stationname like'%{0}%' ", sname);
            }
            if (!string .IsNullOrEmpty(NO))
            {
                sql += string.Format(" and dbo.Device.name like'%{0}%' ", NO);
            }
            if (depID != "")
            {
                sql += string.Format(" and dbo.Device.DepId like'%{0}%' ", depID);
            }
            else {
                sql += string.Format(" and d.DepId like'{0}%'", CurrentUser.DepartId);
            }
            bool bl = CurrentUser.IsLogon;
            if (bl)
            {
                DataSet ds = devBLL.GetDevcieMainData(sql);
                if(ds.Tables .Count>0)
                result = ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }
            return result;

        }


        /// <summary>
        /// 获取设备CVM实时数据
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        public string GetDeviceCVMDataByModuleID(string depid,string deviceId, string moduleID)
        {
            string result = "{'Rows':[]}"; 
            bool bl = CurrentUser.IsLogon;
            if (bl)
            {
                DataSet ds = devBLL.GetDevcieDataList(string.Format("d.ID='{0}' and p.usertype<={1} and p.parametertypeid=5 and p.SenderID='{2}'", deviceId, CurrentUser.UserTypeID, moduleID));
                if (ds.Tables.Count > 0)
                {
                    result = ListToJson.DataTableToJson("Rows", ds.Tables[0]);
                }
            }
            return result;

        }
    }
}