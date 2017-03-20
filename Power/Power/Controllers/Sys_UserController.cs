using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Power.Controllers
{
    public class Sys_UserController : ApiController
    {
        Power.BLL.Sys_User userbll = new BLL.Sys_User();
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string Login(string name, string pwd)
        {
            string val = "";
            //val = name+pw
            bool bl = CurrentUser.Logon(name, pwd);
            if (bl)
            {
                val = "OK";
                CurrentUser.WriteLogo(name, "用户登录","登录地址："+ CurrentUser.GetIP());
            }
            else {
                val = "用户名或密码错误！";
            }
            return val;
        }


        /// <summary>
        /// 获取用户登录信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string GetLoginInfo()
        {
            StringBuilder jsonVal = new StringBuilder();
            string val = "";
            //val = name+pw
            bool bl = CurrentUser.IsLogon;
            if (bl)
            {
                // jsonVal.Append("{ Rows :[");
                jsonVal.Append("{");
                jsonVal.Append("UserName:\"" + CurrentUser.UserName + "\"");
                jsonVal.Append(",");
                jsonVal.Append("UserTypeID:\"" + CurrentUser.UserTypeID + "\"");
                jsonVal.Append(",");
                jsonVal.Append("DepartId:\"" + CurrentUser.DepartId + "\"");
                jsonVal.Append(",");
                jsonVal.Append("Password:\"" + CurrentUser.Password + "\"");
                jsonVal.Append(",");
                jsonVal.Append("UserId:\"" + CurrentUser.UserId + "\"");
                jsonVal.Append(",");
                jsonVal.Append("Company:\"" + CurrentUser.Company + "\"");
                jsonVal.Append("}");
                //  jsonVal.Append("]}");

                val = jsonVal.ToString();
            }
            return val;
        }
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public string AllUser()
        {
            string result = "";
            bool bl = CurrentUser.IsLogon;
            if (bl)
            {
                DataSet ds = userbll.GetAllList(string.Format(" DepId like '{0}%'", CurrentUser.DepartId));
                result = ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }
            return result;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string GetUserByUID(string Uid)
        {

            DataSet ds = userbll.GetAllList(string.Format(" LogName = '{0}'", Uid));
            return ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            //Power.Model.Sys_User user = userbll.GetModel(Uid);
            //return ListToJson.OneObjectToJSON(user);
        }


        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public string DelUser(string Uid)
        {
            string result = "";
            if (userbll.Delete(Uid))
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
        /// 保存用户信息
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="LogName"></param>
        /// <param name="Password"></param>
        /// <param name="RealName"></param>
        /// <param name="UserLevel"></param>
        /// <param name="DepId"></param>
        /// <param name="Company"></param>
        /// <param name="Email"></param>
        /// <param name="Phone"></param>
        /// <param name="userQQ"></param>
        /// <param name="userAddress"></param>
        /// <returns></returns>
        public string SaveUser(string Uid, string LogName, string Password, string RealName, string UserLevel, string DepId, string Company, string Email, string Phone, string userQQ, string userAddress, string userImg)
        {
            string result = "";
            Power.Model.Sys_User user = new Model.Sys_User();
            user.Company = Company;
            user.DepId = DepId;
            user.Email = Email;
            user.LogName = LogName;

            user.Phone = Phone;
            user.RealName = RealName;
            user.TM = DateTime.Now;
            user.userAddress = userAddress;
            user.UserLevel = Convert.ToInt32(UserLevel);
            user.userQQ = userQQ;
            user.userImg = userImg;
            user.Password = Password;

            if (Uid == "" || Uid == null)
            {
                if (!userbll.Exists(LogName))
                {
                    user.Password = CurrentUser.MD5Encrypt(Password);
                    if (userbll.Add(user))
                    {
                        result = "OK";
                    }
                    else
                    {
                        result = "Error";
                    }
                }
                else {
                    result = "Error1";
                }

            }
            else
            {
                if (userbll.Update(user))
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

        public string GetEditPassword(string oldpwd, string newpwd)
        {
            string result="";
            if (CurrentUser.Password == CurrentUser.MD5Encrypt(oldpwd))
            {
                Power.Model.Sys_User user = userbll.GetModel(CurrentUser .UserId);
                if (user != null)
                {
                    user.Password = CurrentUser.MD5Encrypt(newpwd);
                    if (userbll.Update(user))
                    {
                        result = "OK";
                    }
                    else {
                        result = "Error!";
                    }
                
                }
            }
            else {
                result = "旧密码不正确！";
            }
            return result;
        
        }
    
    }
}