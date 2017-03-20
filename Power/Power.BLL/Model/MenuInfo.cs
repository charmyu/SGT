/**  版本信息模板在安装目录下，可自行修改。
* MenuInfo.cs
*
* 功 能： N/A
* 类 名： MenuInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 9:19:47   N/A    初版
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
	/// MenuInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MenuInfo
	{
		public MenuInfo()
		{}
		#region Model
		private int _menu_id;
		private string _menu_name;
		private string _menu_link;
		private int _menu_isvisible;
		private string _menu_parent;
		private int _menu_usertype;
		private string _menu_imgurl="";
		/// <summary>
		/// 
		/// </summary>
		public int Menu_ID
		{
			set{ _menu_id=value;}
			get{return _menu_id;}
		}
		/// <summary>
		/// 菜单名称
		/// </summary>
		public string Menu_Name
		{
			set{ _menu_name=value;}
			get{return _menu_name;}
		}
		/// <summary>
		/// 连接的页面
		/// </summary>
		public string Menu_Link
		{
			set{ _menu_link=value;}
			get{return _menu_link;}
		}
		/// <summary>
		/// 是否显示
		/// </summary>
		public int Menu_IsVisible
		{
			set{ _menu_isvisible=value;}
			get{return _menu_isvisible;}
		}
		/// <summary>
		/// 关联父菜单
		/// </summary>
		public string Menu_Parent
		{
			set{ _menu_parent=value;}
			get{return _menu_parent;}
		}
		/// <summary>
		/// 用户类型
		/// </summary>
		public int Menu_UserType
		{
			set{ _menu_usertype=value;}
			get{return _menu_usertype;}
		}
		/// <summary>
		/// 图标
		/// </summary>
		public string Menu_Imgurl
		{
			set{ _menu_imgurl=value;}
			get{return _menu_imgurl;}
		}
		#endregion Model

	}
}

