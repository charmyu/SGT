/**  版本信息模板在安装目录下，可自行修改。
* Log.cs
*
* 功 能： N/A
* 类 名： Log
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
	/// Log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Log
	{
		public Log()
		{}
		#region Model
		private int _log_id;
		private string _log_username="";
		private string _log_memo="";
		private string _log_content="";
		private DateTime _log_addtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int Log_ID
		{
			set{ _log_id=value;}
			get{return _log_id;}
		}
		/// <summary>
		/// 操作用户名
		/// </summary>
		public string Log_UserName
		{
			set{ _log_username=value;}
			get{return _log_username;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Log_Memo
		{
			set{ _log_memo=value;}
			get{return _log_memo;}
		}
		/// <summary>
		/// 日志内容
		/// </summary>
		public string Log_Content
		{
			set{ _log_content=value;}
			get{return _log_content;}
		}
		/// <summary>
		/// 记录日志时间
		/// </summary>
		public DateTime Log_AddTime
		{
			set{ _log_addtime=value;}
			get{return _log_addtime;}
		}
		#endregion Model

	}
}

