using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;


/// <summary>
/// CurrentUser 登录及用户信息。
/// </summary>
public class CurrentUser
{
    public CurrentUser()
    {
        //
        // TODO: 在此处新增构造函数逻辑
        //
    }
    private const string SESSION_USER = "HUINONGMANAGE_SESSION_USER";
    private const string SESSION_USER_TRUE = "HUINONGMANAGE_SESSION_USER_TRUE";

    private const string COOKIES_USERID = "HUINONGMANAGE_COOKIES_USERID";
    private const string COOKIES_USERID_TRUE = "HUINONGMANAGE_COOKIES_USERID_TRUE";

    /// <summary>
    /// 用户注销操作
    /// </summary>

    public static void Logout()
    {
        //清除Session
        HttpContext.Current.Session.Abandon();

        //清除Cookies
        HttpContext.Current.Response.Cookies[COOKIES_USERID].Value = "";
        HttpContext.Current.Response.Cookies[COOKIES_USERID_TRUE].Value = "";

    }

    /// <summary>
    /// 重新登录，跳转至登录页面
    /// </summary>
    public static void ReLogon()
    {
        System.Web.HttpContext.Current.Response.Write(@"
<script language=""javascript"">
function ReLogon(win)
{
	try
	{
		if(win.top.opener == null)
		{
			win.top.location.href = '../login.html';
		}
		else
		{
			ReLogon(win.top.opener);
			win.top.close();
		}
	}
	catch(e)
	{
		win.top.location.href = '../login.html';
	}
	finally{}
}

ReLogon(window);
</script>");
        System.Web.HttpContext.Current.Response.End();
    }


    /// <summary>
    /// 用户登录验证
    /// </summary>
    public static bool Logon(string name, string password)
    {
        try
        {
          //  string where = string.Format("User_Id='{0}' and User_Pwd='{1}'", name, GetRedirect.MD5Encrypt(password));

          ////  User_ListBLL userBLL = new User_ListBLL();
          //  IList<UserInfo> list = userBLL.GetModelList(where);
            Power.Model.Sys_User obj = new Power.BLL.Sys_User().GetModel(name);
            if (obj != null)
            {
                if (obj.Password == MD5Encrypt(password))
                {
                    LogonSuccess(obj);
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
            return false;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    /// <summary>
    /// 加密  16位
    /// </summary>
    /// <param name="pwd">要加密的字符串</param>
    public static string MD5Encrypt(string pwd)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(pwd)), 4, 8);
        t2 = t2.Replace("-", "");
        return t2;
    }

    /// <summary>
    /// 用户登录成功的后续操作，设置Session和Cookies
    /// </summary>
    public static void LogonSuccess(Power.Model.Sys_User user)
    {
        //设置SESSION
        System.Web.HttpContext.Current.Session[SESSION_USER] = user;
        System.Web.HttpContext.Current.Session[SESSION_USER_TRUE] = user;
    }



    /// <summary>
    /// 仅判断用户是否登录，不自动登录
    /// </summary>
    public static bool IsLogon
    {
        get
        {
            if (HttpContext.Current.Session[SESSION_USER] != null
                && HttpContext.Current.Session[SESSION_USER_TRUE] != null)
            {
                return true;	//如果有用户信息的Session表示已登录
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 当前用户信息
    /// </summary>
    private static Power.Model.Sys_User userInfo
    {
        get
        {
            if (IsLogon)
            {
                return (Power.Model.Sys_User)HttpContext.Current.Session[SESSION_USER];
            }
            else
            {
                ReLogon();
                return null;	//不会执行
            }
        }
    }


    /// <summary>
    /// 用户id
    /// </summary>
    public static string UserId
    {
        get
        {
            return userInfo.LogName;
        }
    }

    /// <summary>
    /// 用户名
    /// </summary>
    public static string UserName
    {
        get
        {
            return userInfo.RealName;
        }
    }

    /// <summary>
    /// 密码
    /// </summary>
    public static string Password
    {
        get
        {
            return userInfo.Password;
        }
    }

    /// <summary>
    /// 所属企业
    /// </summary>
    public static string Company
    {
        get
        {
            return userInfo.Company;
        }
    }

    /// <summary>
    /// 所属企业id
    /// </summary>
    public static string DepartId
    {
        get
        {
            return userInfo.DepId;
        }
    }

    /// <summary>
    /// 所属企业
    /// </summary>
    public static Power.Model .Sys_Department department
    {
        get {
          //  Department_ListBLL departBLL = new Department_ListBLL();
            Power.Model.Sys_Department depart = new Power.BLL.Sys_Department().GetModel(userInfo.DepId);
            if (depart != null)
                return depart;
            else
                return null;
        }
    }

    /// <summary>               
    /// 用户类型编号
    /// </summary>
    public static int UserTypeID
    {
        get
        {
            return userInfo.UserLevel;
        }
    }


    public static Power.Model.Sys_UserType UserTypeName
    {
        get
        {
            Power.BLL.Sys_UserType typeBLL = new Power.BLL.Sys_UserType();
            int id = (int)userInfo.UserLevel;
            Power.Model.Sys_UserType typeModel = new Power.Model.Sys_UserType();
            typeModel = typeBLL.GetModel(id);
            if (typeModel == null)
            {
                typeModel.typename = "游客组";
                typeModel.typeId = 0;
                return typeModel;
            }

            return typeModel;
        }
    }


    /// <summary>
    /// 获取客户端地址
    /// </summary>
    /// <returns>ip地址</returns>
    public static string GetIP()
    {
        string ip = "127.0.0.1";
        if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null) // using proxy
        {
            ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            // Return real client IP.
        }
        else// not using proxy or can't get the Client IP
        {
            ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            //While it can't get the Client IP, it will return proxy IP.
        }
        return ip;
    }

    /// <summary>
    /// 用户日志
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="mome">操作记录</param>
    /// <param name="text">操作详细</param>
    /// <returns></returns>
    public static bool WriteLogo(string username, string mome, string text)
    {
        bool flag;
        try
        {
            Power.Model.Log model = new Power.Model.Log();
            model.Log_UserName = username;
            model.Log_Memo = mome;
            model.Log_Content = text;
            if (new Power.BLL.Log().Add(model) > 0)
            {
                return true;
            }
            flag = false;
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        return flag;
    }


}
