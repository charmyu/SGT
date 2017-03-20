/**  版本信息模板在安装目录下，可自行修改。
* EventLog.cs
*
* 功 能： N/A
* 类 名： EventLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 9:19:46   N/A    初版
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
	/// EventLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EventLog
	{
		public EventLog()
		{}
		#region Model
		private string _id;
		private string _deviceid;
		private string _msgno;
		private string _msgid;
		private DateTime _rtr_tm;
		private int _runtime;
		private string _cmd="";
		private string _cmdsource="";
		private int _sysstate=0;
		private int _faultcount=0;
		private int _normaltime=0;
		private string _alarm_state;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 设备ID
		/// </summary>
		public string deviceID
		{
			set{ _deviceid=value;}
			get{return _deviceid;}
		}
		/// <summary>
		/// 消息编号
		/// </summary>
		public string msgNO
		{
			set{ _msgno=value;}
			get{return _msgno;}
		}
		/// <summary>
		/// 消息ID 区分消息类型
		/// </summary>
		public string msgID
		{
			set{ _msgid=value;}
			get{return _msgid;}
		}
		/// <summary>
		/// 记录时间
		/// </summary>
		public DateTime rtr_TM
		{
			set{ _rtr_tm=value;}
			get{return _rtr_tm;}
		}
		/// <summary>
		/// 运行时间 单位“分”
		/// </summary>
		public int runtime
		{
			set{ _runtime=value;}
			get{return _runtime;}
		}
		/// <summary>
		/// 开关机命令
		/// </summary>
		public string cmd
		{
			set{ _cmd=value;}
			get{return _cmd;}
		}
		/// <summary>
		/// 开关机命令来源
		/// </summary>
		public string cmdsource
		{
			set{ _cmdsource=value;}
			get{return _cmdsource;}
		}
		/// <summary>
		/// 系统状态
		/// </summary>
		public int sysstate
		{
			set{ _sysstate=value;}
			get{return _sysstate;}
		}
		/// <summary>
		/// 一天内的故障次数
		/// </summary>
		public int faultcount
		{
			set{ _faultcount=value;}
			get{return _faultcount;}
		}
		/// <summary>
		/// 正常待机计数
		/// </summary>
		public int normaltime
		{
			set{ _normaltime=value;}
			get{return _normaltime;}
		}
		/// <summary>
		/// 报警代码
		/// </summary>
		public string alarm_state
		{
			set{ _alarm_state=value;}
			get{return _alarm_state;}
		}
		#endregion Model

	}
}

