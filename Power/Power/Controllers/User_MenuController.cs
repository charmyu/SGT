using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class User_MenuController : ApiController
    {
        Power.BLL.User_Menu bll = new BLL.User_Menu();
        /// <summary>
        /// 编辑用户类型权限
        /// </summary>
        /// <param name="usertypeid"></param>
        /// <param name="menuidlist"></param>
        /// <returns></returns>
        public string SaveUsertypeMenu(string usertypeid,string menuidlist)
        {
            string result = "";
           
            List<Power.Model.User_Menu> mlist = bll.GetModelList(" UserTypeID="+usertypeid);
            if(mlist.Count>0)
            {
                bll.DeleteList("select ID from User_Menu where UserTypeID=" + usertypeid);

            }
            
                string[] menuid = menuidlist.TrimEnd(',').Split(',');
                for (int i = 0; i < menuid.Length;i++ )
                {
                    Power.Model.User_Menu Umenu = new Model.User_Menu();
                    Umenu.MenuID =Convert.ToInt32( menuid[i]);
                    Umenu.UserTypeID = Convert.ToInt32(usertypeid);
                    Umenu.reserver = "";
                    bll.Add(Umenu);
                }
                result = "OK";
            

            return result;
        
        }
        /// <summary>
        /// 获取用户类型页面
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public string GetUserTypeMenu(string typeid)
        {
            DataSet ds = bll.GetList(string.Format(" UserTypeID = '{0}'", typeid));
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);
           
        }
    }
}