/**  版本信息模板在安装目录下，可自行修改。
* RT_CPoint.cs
*
* 功 能： N/A
* 类 名： RT_CPoint
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 9:19:49   N/A    初版
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
	/// RT_CPoint:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RT_CPoint
	{
		public RT_CPoint()
		{}
		#region Model
		private string _id;
		private string _moduleid;
		private string _prarmeterid;
		private string _paraname;
		private decimal _rtval=0M;
		private int _status=0;
		private DateTime _tm;
		private string _setval;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 设备或者模块ID
		/// </summary>
		public string ModuleID
		{
			set{ _moduleid=value;}
			get{return _moduleid;}
		}
		/// <summary>
		/// 参数ID
		/// </summary>
		public string prarmeterID
		{
			set{ _prarmeterid=value;}
			get{return _prarmeterid;}
		}
		/// <summary>
		/// 参数名称
		/// </summary>
		public string paraName
		{
			set{ _paraname=value;}
			get{return _paraname;}
		}
		/// <summary>
		/// 实时数据
		/// </summary>
		public decimal RTVal
		{
			set{ _rtval=value;}
			get{return _rtval;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 获取数据时间
		/// </summary>
		public DateTime TM
		{
			set{ _tm=value;}
			get{return _tm;}
		}
		/// <summary>
		/// 上一次设置值
		/// </summary>
		public string SetVal
		{
			set{ _setval=value;}
			get{return _setval;}
		}
		#endregion Model

	}
}

