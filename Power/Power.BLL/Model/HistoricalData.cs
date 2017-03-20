/**  版本信息模板在安装目录下，可自行修改。
* HistoricalData.cs
*
* 功 能： N/A
* 类 名： HistoricalData
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
	/// HistoricalData:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HistoricalData
	{
		public HistoricalData()
		{}
		#region Model
		private string _id;
		private string _deviceid;
		private string _parameterid;
		private string _parametername;
		private decimal _paraval;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 设备和模板ID
		/// </summary>
		public string DeviceID
		{
			set{ _deviceid=value;}
			get{return _deviceid;}
		}
		/// <summary>
		/// 参数ID
		/// </summary>
		public string ParameterID
		{
			set{ _parameterid=value;}
			get{return _parameterid;}
		}
		/// <summary>
		/// 参数名
		/// </summary>
		public string ParameterName
		{
			set{ _parametername=value;}
			get{return _parametername;}
		}
		/// <summary>
		/// 数据
		/// </summary>
		public decimal paraVal
		{
			set{ _paraval=value;}
			get{return _paraval;}
		}
		#endregion Model

	}
}

