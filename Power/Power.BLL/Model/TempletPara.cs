/**  版本信息模板在安装目录下，可自行修改。
* TempletPara.cs
*
* 功 能： N/A
* 类 名： TempletPara
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
	/// TempletPara:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TempletPara
	{
		public TempletPara()
		{}
		#region Model
		private string _id;
		private string _templetid;
		private string _parameterid;
		private int _parameterindex;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 模板ID
		/// </summary>
		public string templetID
		{
			set{ _templetid=value;}
			get{return _templetid;}
		}
		/// <summary>
		/// 参数ID
		/// </summary>
		public string parameterID
		{
			set{ _parameterid=value;}
			get{return _parameterid;}
		}
		/// <summary>
		/// 参数序号
		/// </summary>
		public int parameterindex
		{
			set{ _parameterindex=value;}
			get{return _parameterindex;}
		}
		#endregion Model

	}
}

