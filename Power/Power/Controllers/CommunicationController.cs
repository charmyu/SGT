using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Power.Controllers
{
    public class CommunicationController : ApiController
    {
        Power.BLL.Sys_Department DepBLL = new BLL.Sys_Department();
        Power.BLL.Sys_User userBLL = new BLL.Sys_User();
        Power.BLL.Communication commBLL = new BLL.Communication();

        /// <summary>
        /// 根据登录的用户权限 获取机构和用户  
        /// </summary>
        /// <returns></returns>
        public string GetDepartmentUser()
        {

            string result = "{'Rows':[]}";
            if (CurrentUser.IsLogon)
            {  
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("ParentID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Count");
                string s = CurrentUser.UserTypeName.typename;
               List<Power .Model .Sys_Department> deplist = DepBLL.GetModelList(string.Format(" Dep_ID like '{0}%' order by Dep_ID", CurrentUser.DepartId));

               foreach (Power.Model.Sys_Department model in deplist)
               {
                   DataRow dr = dt.NewRow();
                   dr["ID"] = model.Dep_ID;
                   dr["ParentID"] = model.Dep_Parent;
                   dr["Name"] = model.Dep_Name;
                   dr["Count"] = 0;
                   dt.Rows.Add(dr);
                   List<Power.Model.Sys_User> userlist = userBLL.GetModelList(string.Format(" DepId = '{0}' ", model .Dep_ID));
                   foreach (Power.Model.Sys_User user in userlist)
                   {
                       DataRow dr1 = dt.NewRow();
                       dr1["ID"] = user.LogName;
                       dr1["ParentID"] = user.DepId;
                       dr1["Name"] =user.RealName;
                       dr1["Count"] = 1;
                       dt.Rows.Add(dr1);
                   }
                
               }
                result = ListToJson.DataTableToJson("Rows", dt);
            }

            return result;

        }

        /// <summary>
        /// 获取通信记录
        /// </summary>
        /// <param name="UserID">通信对象</param>
        /// <param name="Flag">实时/ 消息记录</param>
        /// <returns></returns>
        public string GetCommunication(string UserID,string Flag)
        {
            string result = "{'Rows':[]}";
            string sqlstr = string.Format(" (ReceiveID='{0}' and SenderID='{1}') or (ReceiveID='{1}' and SenderID='{0}')", UserID, CurrentUser.UserId);
            if (Flag == "new")
            {
                sqlstr = sqlstr + string.Format(" and TM BETWEEN '{0}' and '{1}'", DateTime.Now.AddDays(-7), DateTime.Now);
            }
            else
            {
                sqlstr = sqlstr + string.Format(" and TM BETWEEN '{0}' and '{1}'", DateTime.Now.AddMonths(-3), DateTime.Now);
            }
            DataSet ds = commBLL.GetSendReadAndUpdateState(sqlstr, CurrentUser.UserId);
            if (ds.Tables.Count > 0)
            {                
                result = ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }

            return result;
        }


        public string SendCommunication(string ReceiveID, string Content)
        {
            string result = "";

          
            if (!string.IsNullOrEmpty(Content))
            {  
                Power.Model.Communication model = new Model.Communication();
                model.Content = HttpUtility.UrlDecode(Content);
                model.ReceiveID = ReceiveID;
                model.SenderID = CurrentUser.UserId;
                model.State = 1;
                model.TM = DateTime.Now;
                model.Img = "";
                if (commBLL.Add(model) > 0)
                {
                    result = "OK";
                }
                else {
                    result = "Error";
                }
            
            }

            return result;
        }

        /// <summary>
        /// 获取未读的通信记录 
        /// </summary>
        /// <returns></returns>
        public string GetCommunicationByUserID(string rid)
        {
            string result = "{'Rows':[]}";
            string sqlstr = string.Format(" Communication.State=1 and ReceiveID='{0}'  and Communication.TM BETWEEN '{1}' and '{2}'  ", CurrentUser.UserId, DateTime.Now.AddDays(-7), DateTime.Now);

            DataSet ds = commBLL.GetUNReadSendUser(sqlstr);
            if (ds.Tables.Count > 0)
            {               
                result = ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }

            return result;
        }

    }
}