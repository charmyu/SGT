using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class LogController : ApiController
    {

        Power.BLL.Log logBLL = new BLL.Log();
        public string GetUserLogByUserID(string username,string btime,string etime)
        {
            string result = "";
            string sqlwhere = "";
            bool bl = CurrentUser.IsLogon;
            if (bl)
            {
                if (username == "00")
                {
                    sqlwhere = string.Format(" DepId like'{0}%' AND Log_AddTime BETWEEN '{1}' AND '{2}' ", CurrentUser.DepartId, btime, etime + " 23:59:59");
                }
                else
                {
                    sqlwhere = string.Format(" Log_UserName ='{0}' AND Log_AddTime BETWEEN '{1}' AND '{2}' ", username,btime ,etime+" 23:59:59");
                }
                DataSet ds = logBLL.GetAllRelationTable(sqlwhere);
                result = ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }
            else
            {
                CurrentUser.ReLogon();
            }
            return result;
        }
    }
}