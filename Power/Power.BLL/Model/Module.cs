/**  版本信息模板在安装目录下，可自行修改。
* Module.cs
*
* 功 能： N/A
* 类 名： Module
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
	/// Module:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Module
	{
		public Module()
		{}
		#region Model
		private string _id;
		private string _modulename;
		private string _deviceid;
		private DateTime _tm;
		private int _state=1;
		private string _templetid="";
        private string _no;

        /// <summary>
        /// 模块编号
        /// </summary>
        public string NO
        {
            set { _no = value; }
            get { return _no; }
        }
		/// <summary>
		/// 模块ID
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 模块名称
		/// </summary>
		public string ModuleName
		{
			set{ _modulename=value;}
			get{return _modulename;}
		}
		/// <summary>
		/// 主设备ID
		/// </summary>
		public string deviceID
		{
			set{ _deviceid=value;}
			get{return _deviceid;}
		}
		/// <summary>
		/// 新增模块时间
		/// </summary>
		public DateTime TM
		{
			set{ _tm=value;}
			get{return _tm;}
		}
		/// <summary>
		/// 模块状态
		/// </summary>
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string templetID
		{
			set{ _templetid=value;}
			get{return _templetid;}
		}
		#endregion Model

	}
}

