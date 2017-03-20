/**  版本信息模板在安装目录下，可自行修改。
* Device.cs
*
* 功 能： N/A
* 类 名： Device
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
	/// Device:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Device
	{
		public Device()
		{}
		#region Model
		private string _id;
		private string _name;
		private string _serialno;
		private string _stationname;
		private string _stationaddress="";
		private int? _type=1;
		private string _n;
		private string _e;
		private int _state=1;
		private string _phone="";
		private DateTime _tm=DateTime.Now ;
		private string _dtuip="";
		private string _dtuport="";
		private DateTime? _dtutm=DateTime.Now ;
		private string _templetid="";
        private string _depid;

        /// <summary>
        /// 机构ID
        /// </summary>
        public string DepId
        {
            set { _depid = value; }
            get { return _depid; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 设备名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 设备序列号
		/// </summary>
		public string SerialNo
		{
			set{ _serialno=value;}
			get{return _serialno;}
		}
		/// <summary>
		/// 基站名称
		/// </summary>
		public string stationname
		{
			set{ _stationname=value;}
			get{return _stationname;}
		}
		/// <summary>
		/// 基站地址
		/// </summary>
		public string stationaddress
		{
			set{ _stationaddress=value;}
			get{return _stationaddress;}
		}
		/// <summary>
		/// 设备类型
		/// </summary>
		public int? type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 北纬
		/// </summary>
		public string N
		{
			set{ _n=value;}
			get{return _n;}
		}
		/// <summary>
		/// 东经
		/// </summary>
		public string E
		{
			set{ _e=value;}
			get{return _e;}
		}
		/// <summary>
		/// 设备状态
		/// </summary>
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 分机号码
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 设备注册时间
		/// </summary>
		public DateTime TM
		{
			set{ _tm=value;}
			get{return _tm;}
		}
		/// <summary>
		/// dtu设备连接IP
		/// </summary>
		public string dtuIP
		{
			set{ _dtuip=value;}
			get{return _dtuip;}
		}
		/// <summary>
		/// dtu设备连接端口
		/// </summary>
		public string dtuport
		{
			set{ _dtuport=value;}
			get{return _dtuport;}
		}
		/// <summary>
		/// dtu最后一次连接时间
		/// </summary>
		public DateTime? dtuTM
		{
			set{ _dtutm=value;}
			get{return _dtutm;}
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

