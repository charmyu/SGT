/**  版本信息模板在安装目录下，可自行修改。
* Sys_User.cs
*
* 功 能： N/A
* 类 名： Sys_User
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 9:19:50   N/A    初版
*
* Copyright (c) 2012 Power Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Power.Model
{
	/// <summary>
	/// Sys_User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_User
	{
		public Sys_User()
		{}
		#region Model
		private string _logname;
		private string _password="";
		private int _userlevel=0;
		private string _realname;
		private string _company;
		private string _depid;
		private string _email;
		private string _phone;
		private string _userqq;
		private string _useraddress;
		private string _userimg;
		private DateTime? _tm;
		/// <summary>
		/// 登录ID
		/// </summary>
		public string LogName
		{
			set{ _logname=value;}
			get{return _logname;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 用户类型
		/// </summary>
		public int UserLevel
		{
			set{ _userlevel=value;}
			get{return _userlevel;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 用户单位名称
		/// </summary>
		public string Company
		{
			set{ _company=value;}
			get{return _company;}
		}
		/// <summary>
		/// 机构 id
		/// </summary>
		public string DepId
		{
			set{ _depid=value;}
			get{return _depid;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userQQ
		{
			set{ _userqq=value;}
			get{return _userqq;}
		}
		/// <summary>
		/// 用户联系地址
		/// </summary>
		public string userAddress
		{
			set{ _useraddress=value;}
			get{return _useraddress;}
		}
		/// <summary>
		/// 用户头像，图片文件名
		/// </summary>
		public string userImg
		{
			set{ _userimg=value;}
			get{return _userimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TM
		{
			set{ _tm=value;}
			get{return _tm;}
		}
		#endregion Model

	}
}

