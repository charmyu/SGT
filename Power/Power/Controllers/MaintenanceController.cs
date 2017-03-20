using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class MaintenanceController : ApiController
    {
        Power.BLL.Maintenance bll = new BLL.Maintenance();
       



        /// <summary>
        /// 添加维护日志
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="depID"></param>
        /// <param name="content"></param>
        /// <param name="DevID"></param>
        /// <param name="imgpath"></param>
        /// <returns></returns>
        public string AddMaintenance(string Uid,string depID,string content,string DevID,string imgpath )
        {
             string result = "";


            

             if (Uid == "" || Uid == null)
             {
                 Power.Model.Maintenance model = new Model.Maintenance();

                 model.Dep_ID = depID;
                 model.DeviceID = DevID;
                 model.Memo = content;
                 model.ImgName = imgpath;
                 model.reserver = "";
                 model.TM = DateTime.Now;
                 model.UserID = CurrentUser.UserId;
                 if (bll.Add(model)>0)
                 {
                     result = "OK";
                 }
                 else
                 {
                     result = "Error";
                 }
             }
             else {
                 Power.Model.Maintenance model = bll.GetModel (Convert.ToInt32(Uid));

                 model.Dep_ID = depID;
                 model.DeviceID = DevID;
                 model.Memo = content;
                 model.ImgName = imgpath;
                 model.UserID = CurrentUser.UserId;
                // model.reserver = "";
                model.ID =Convert.ToInt32( Uid);
                 if (bll.Update(model))
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
        /// 返回设备日志
        /// </summary>
        /// <param name="depID"></param>
        /// <param name="sname"></param>
        /// <returns></returns>
        public string GetMaintenanceLogByDepId(string depID, string sname)
        {
            string result = "";
            string sql = " 1=1 ";
            if (!string.IsNullOrEmpty(sname))
            {
                sql += string.Format(" and Device.stationname like'%{0}%' ", sname);
            }
            if (depID != "")
            {
                sql += string.Format(" and Maintenance.Dep_ID like'%{0}%' ", depID);
            }
            else
            {
                sql += string.Format(" and Maintenance.Dep_ID like'{0}%'", CurrentUser.DepartId);
            }
            bool bl = CurrentUser.IsLogon;
            if (bl)
            {
                DataSet ds = bll.GetDataSet(sql);
                if (ds.Tables.Count > 0)
                    result = ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }
            return result;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string DelMaintenanceLog(string Uid)
        {
            string result = "";
            
            if (bll.Delete(Convert.ToInt32(Uid)))
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
        /// 获取单个实例
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string GetModelByUID(string Uid)
        {
            DataSet ds = bll.GetDataSet(string.Format(" Maintenance.ID ={0}", Convert.ToInt32(Uid)));
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);
           
        }

    }
}