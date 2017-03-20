/**  版本信息模板在安装目录下，可自行修改。
* Templet.cs
*
* 功 能： N/A
* 类 名： Templet
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 9:19:51   N/A    初版
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
	/// Templet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Templet
	{
		public Templet()
		{}
		#region Model
		private string _id;
		private string _templetname;
		private string _memo;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 模板名称
		/// </summary>
		public string templetname
		{
			set{ _templetname=value;}
			get{return _templetname;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string memo
		{
			set{ _memo=value;}
			get{return _memo;}
		}
		#endregion Model

	}
}

