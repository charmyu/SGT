using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Power.Controllers
{
    public class MenuInfoController : ApiController
    {
        Power.BLL.MenuInfo menuBLL = new BLL.MenuInfo();
        /// <summary>
        /// 获取菜单拼接字符串
        /// </summary>
        /// <returns></returns>
        public string BindMenuInfo()
        {
            StringBuilder strmenu = new StringBuilder();           
            bool bl = CurrentUser.IsLogon;
            if (bl)
            {

                strmenu.Append(@"  <ul class=""nav sidebar-collapse"" id=""side-menu"">");
                //strmenu.Append(@"<li style=""background:#ffcd00;"" class=""zybor_foot"">");
                //strmenu.Append(@"    <a href=""index.html"">");
                //strmenu.Append(@"  <i class=""glyphicon glyphicon-home""></i>");
                //strmenu.Append(@"  <span class=""nav-label"">首页</span></a></li>");
                List<Power.Model.MenuInfo> list = menuBLL.GetModelList(string.Format(" Menu_Parent=0 and Menu_ID in (select MenuID from User_Menu where UserTypeID={0} ) order by Menu_ID ", CurrentUser.UserTypeID));
                foreach (Power.Model.MenuInfo menu in list)
                {
                    strmenu.Append(@"<li class=""zybor_foot""><a href=""#"">");
                    strmenu.Append(@"<i class=""" + menu.Menu_Link + @"""></i>");
                    strmenu.Append(@" <span class=""nav-label"">" + menu.Menu_Name + "</span>");
                    strmenu.Append(@"<span class=""fa arrow""></span></a><ul class=""nav nav-second-level"">");
                    List<Power.Model.MenuInfo> list_1 = menuBLL.GetModelList(string.Format(" Menu_ID in (select MenuID from User_Menu where UserTypeID={0} ) and Menu_Parent='{1}' order by Menu_ID ", CurrentUser.UserTypeID, menu.Menu_ID));
                    foreach (Power.Model.MenuInfo menu1 in list_1)
                    {
                        strmenu.Append(@"<li><a class=""l-link"" href=""javascript:f_addTab('"+menu1.Menu_ID+@"','"+menu1.Menu_Name+@"','"+menu1 .Menu_Link+@"')"">" + menu1.Menu_Name + @"</a> </li>");
                    }
                    strmenu.Append(" </ul> </li>");
                }
                strmenu.Append(" </ul>");
            }


            return strmenu.ToString();
        }

        /// <summary>
        /// 根据用户类型获取菜单
        /// </summary>
        /// <returns></returns>
        public string GetMenuInfo()
        {
            string result = "";
              bool bl = CurrentUser.IsLogon;
              if (bl)
              {
                  DataSet ds;
                  if (CurrentUser.UserTypeID == 6)
                  {
                       ds = menuBLL.GetList(string.Format(" 1=1  order by Menu_ID "));
                  }
                  else {
                      ds = menuBLL.GetList(string.Format("  Menu_ID in (select MenuID from User_Menu where UserTypeID={0} ) order by Menu_ID ", CurrentUser.UserTypeID));
                  }
                  result = ListToJson.DataTableToJson("Rows",ds.Tables[0]);
              }
            
            return result;
        
        }
    }
}