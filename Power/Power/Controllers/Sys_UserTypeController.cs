using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class Sys_UserTypeController : ApiController
    {
        Power.BLL.Sys_UserType usertypeBll = new BLL.Sys_UserType();
      /// <summary>
      /// 获取所有类型
      /// </summary>
      /// <returns></returns>
        public string GetAllUserType()
        {
           // string result = "";
            DataSet ds = usertypeBll.GetList(string.Format(" typeId<={0}  order by typeId",CurrentUser .UserTypeID));
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);
         
        }
        /// <summary>
        /// 删除用户类型
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string DelUser(string Uid)
        {
            string result = "";
            if (usertypeBll.Delete(Uid))
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
        /// 获取单个类型信息
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string GetUserTypeByUID(string Uid)
        {
            Power.Model.Sys_UserType type = usertypeBll.GetModel(Uid);
            return ListToJson.OneObjectToJSON(type);
        }

        public string SaveUserType(string Uid, string typeid, string typename)
        {
            string result = "";

             System.Guid guid = System.Guid.NewGuid(); //Guid 类型
             string strGUID = System.Guid.NewGuid().ToString(); //直接返回字符串类型

             Power.Model.Sys_UserType usertype = new Model.Sys_UserType();
            
             usertype.typeId =Convert .ToInt32(typeid);
             usertype.typename = typename;

             if (Uid == "" || Uid == null)
             {
                 usertype.ID = strGUID;
                 if (usertypeBll.Add(usertype))
                 {
                     result = "OK";
                 }
                 else
                 {
                     result = "Error";
                 }
             }
             else {
                 usertype.ID = Uid;
                 if (usertypeBll.Update(usertype))
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