/**  版本信息模板在安装目录下，可自行修改。
* Sys_Department.cs
*
* 功 能： N/A
* 类 名： Sys_Department
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
	/// Sys_Department:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_Department
	{
		public Sys_Department()
		{}
		#region Model
		private string _dep_id;
		private string _dep_name;
		private string _dep_contact="";
		private string _dep_phone="";
		private string _dep_parent="";
		private int _dep_type=1;
		private string _dep_imgurl;
		private string _dep_address;
		/// <summary>
		/// 机构ID
		/// </summary>
		public string Dep_ID
		{
			set{ _dep_id=value;}
			get{return _dep_id;}
		}
		/// <summary>
		/// 机构名称
		/// </summary>
		public string Dep_Name
		{
			set{ _dep_name=value;}
			get{return _dep_name;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string Dep_Contact
		{
			set{ _dep_contact=value;}
			get{return _dep_contact;}
		}
		/// <summary>
		/// 联系人电话
		/// </summary>
		public string Dep_Phone
		{
			set{ _dep_phone=value;}
			get{return _dep_phone;}
		}
		/// <summary>
		/// 父机构编号
		/// </summary>
		public string Dep_Parent
		{
			set{ _dep_parent=value;}
			get{return _dep_parent;}
		}
		/// <summary>
		/// 机构类型
		/// </summary>
		public int Dep_Type
		{
			set{ _dep_type=value;}
			get{return _dep_type;}
		}
		/// <summary>
		/// 背景图片
		/// </summary>
		public string Dep_imgUrl
		{
			set{ _dep_imgurl=value;}
			get{return _dep_imgurl;}
		}
		/// <summary>
		/// 机构地址
		/// </summary>
		public string Dep_address
		{
			set{ _dep_address=value;}
			get{return _dep_address;}
		}
		#endregion Model

	}
}

