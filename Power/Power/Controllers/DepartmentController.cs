using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class DepartmentController : ApiController
    {

        Power.BLL.Sys_Department DepBLL = new BLL.Sys_Department();


        /// <summary>
        /// 获取单个机构信息
        /// </summary>  z
        /// <param name="depid">机构ID 主键</param>
        /// <returns></returns>
        public string GetDepartmentByUID(string depid)
        {
            Power.Model.Sys_Department type = DepBLL.GetModel(depid);
            return ListToJson.OneObjectToJSON(type);
        }


        /// <summary>
        /// 获取机构信息
        /// </summary>
        /// <returns></returns>
        public string DepartmentByUser()
        {

            string result="";
            if (CurrentUser.IsLogon)
            {
               string s= CurrentUser.UserTypeName.typename;
               DataSet ds = DepBLL.GetList(string.Format(" Dep_ID like '{0}%' order by Dep_ID", CurrentUser.DepartId)); 
                result = ListToJson.DataTableToJson("Rows",ds.Tables[0]);
            }

            return result;
        
        }

        /// <summary>
        /// 保存机构信息
        /// </summary>
        /// <param name="Dep_Name"></param>
        /// <param name="Dep_Contact"></param>
        /// <param name="Dep_Phone"></param>
        /// <param name="Dep_address"></param>
        /// <param name="Dep_Type"></param>
        /// <param name="ParentID">父机构信息</param>
        /// <returns></returns>
        public string SaveDepartment(string Mark,string Dep_Name, string Dep_Contact, string Dep_Phone, string Dep_address, string Dep_Type, string ParentID)
        {
            string result = "";

            if (ParentID != ""&& ParentID!=null&&Mark != "" && Mark != null)
            {
                Power.Model.Sys_Department dep = null;
                if (Mark == "add")
                {
                    dep = new Model.Sys_Department();

                }
                else
                {
                    dep = DepBLL.GetModel(ParentID);
                }

                dep.Dep_address = Dep_address;
                if (Dep_Contact == null)
                {
                    Dep_Contact = "";
                }
                dep.Dep_Contact = Dep_Contact;

                dep.Dep_imgUrl = "";
                dep.Dep_Name = Dep_Name;
                if (Dep_Phone == null)
                {
                    Dep_Phone = "";                
                }
                dep.Dep_Phone = Dep_Phone;

                dep.Dep_Type = Convert.ToInt32(Dep_Type);



                if (Mark == "add")
                {
                    dep.Dep_Parent = ParentID;
                    dep.Dep_ID =DepBLL.GetDepartId(ParentID);
                    if (DepBLL.Add(dep))
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
                    dep.Dep_ID = ParentID;
                    if (DepBLL.Update(dep))
                    {
                        result = "OK";
                    }
                    else
                    {
                        result = "Error";
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 删除机构
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string DelDepartment(string Uid)
        {
            string result = "";

       
            if (DepBLL.Delete(Uid))
            {
                result = "OK";
            }
            else
            {
                result = "Error";
            }
            return result;
        }

    }
}