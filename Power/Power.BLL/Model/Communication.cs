using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Power.Model
{
	/// <summary>
	/// Communication:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Communication
	{
		public Communication()
		{}
		#region Model
		private int _int;
		private string _receiveid;
		private string _senderid;
		private string _content;
		private string _img;
		private DateTime? _tm;
		private int? _state;
		/// <summary>
		/// 
		/// </summary>
		public int Int
		{
			set{ _int=value;}
			get{return _int;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReceiveID
		{
			set{ _receiveid=value;}
			get{return _receiveid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SenderID
		{
			set{ _senderid=value;}
			get{return _senderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Img
		{
			set{ _img=value;}
			get{return _img;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TM
		{
			set{ _tm=value;}
			get{return _tm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? State
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

