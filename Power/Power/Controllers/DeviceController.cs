using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class DeviceController : ApiController
    {
        Power.BLL.Device devBll = new BLL.Device();
        /// <summary>
        /// 获取所有基站信息
        /// </summary>
        /// <returns></returns>
        public string GetAllDevice()
        {
            string result = "";
              bool bl = CurrentUser.IsLogon;
              if (bl)
              {
                  DataSet ds = devBll.GetAllList(string.Format(" d.DepId like'{0}%'",CurrentUser .DepartId));
                  result= ListToJson.DataTableToJson("Rows", ds.Tables[0]);
              }
              return result;
        }
        /// <summary>
        /// 获取基站信息
        /// </summary>
        /// <param name="depID"></param>
        /// <returns></returns>
        public string DeviceByDepID(string depID)
        {
            string result = "";
            bool bl = CurrentUser.IsLogon;
            if (bl)
            {
                DataSet ds = devBll.GetAllList(string.Format(" d.DepId like'{0}%'", depID));
                result = ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }
            return result;
        }
        /// <summary>
        /// 删除基站信息
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string DelDevice(string Uid)
        {
            string result = "";
            if (devBll.Delete(Uid))
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
        /// 获取单个基站信息
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string GetDeviceByUID(string Uid)
        {
            DataSet ds = devBll.GetAllList(string.Format(" d.ID ='{0}'", Uid));
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);
        }

        /// <summary>
        /// 条件返回基站信息
        /// </summary>
        /// <param name="depID"></param>
        /// <param name="sname"></param>
        /// <param name="NO"></param>
        /// <returns></returns>
        public string GetDeviceByDepId(string depID,string sname,string NO)
        {
            string result = "";
            string sql = " 1=1 ";
            if (!string.IsNullOrEmpty(sname))
            {
                sql += string.Format(" and d.stationname like'%{0}%' ", sname);
            }
            if (!string.IsNullOrEmpty(NO))
            {
                sql += string.Format(" and d.name like'%{0}%' ", NO);
            }
            if (depID != "")
            {
                sql += string.Format(" and d.DepId like'%{0}%' ", depID);
            }
            else {
                sql += string.Format(" and d.DepId like'{0}%'", CurrentUser.DepartId);
            }
            bool bl = CurrentUser.IsLogon;
            if (bl)
            {
                DataSet ds = devBll.GetAllList(sql);
                if (ds.Tables.Count > 0)
                result = ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }
            return result;
        }

        /// <summary>
        /// 保存基站信息
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="typeid"></param>
        /// <param name="typename"></param>
        /// <returns></returns>
        public string SaveDevice(string Uid, string name, string stationname,string SerialNo,string N,string E,string state,string phone,string stationaddress,string templetID,string DepId)
        {
            string result = "";

            System.Guid guid = System.Guid.NewGuid(); //Guid 类型
            string strGUID = System.Guid.NewGuid().ToString(); //直接返回字符串类型

            Power.Model.Device dev = null;
            if (Uid == "" || Uid == "-")
            {
                dev = new Model.Device();

            }
            else {
                dev = devBll.GetModel(Uid);
            }

            dev.name = name;
            dev.SerialNo = SerialNo;
            dev.DepId = DepId;
            dev.E = E;
            dev.N = N;
            dev.phone = phone;
            dev.state = 1;// Convert.ToInt32(state);
            if (!string.IsNullOrEmpty(stationaddress))
            {
                dev.stationaddress = stationaddress;
            }
            else { dev.stationaddress = ""; }
            dev.stationname = stationname;
            dev.templetID = templetID;
            

            if (Uid == "" || Uid == "-")
            {
                dev.ID = strGUID;
                dev.TM = DateTime.Now;
                dev.dtuTM = DateTime.Now;
                if (devBll.Add(dev))
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
                dev.ID = Uid;
                if (devBll.Update(dev))
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