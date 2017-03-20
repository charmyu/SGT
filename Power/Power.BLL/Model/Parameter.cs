/**  版本信息模板在安装目录下，可自行修改。
* Parameter.cs
*
* 功 能： N/A
* 类 名： Parameter
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 9:19:48   N/A    初版
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
    /// Parameter:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Parameter
    {
        public Parameter()
        { }
        #region Model
        private string _id;
        private string _parametername;
        private int _parametertypeid;
        private string _datatype;
        private int _datastartbit;
        private int _datalen;
        private int _databit = 0;
        private string _code;
        private string _cmd = "0";
        private string _senderid = "0";
        private int? _targetid = 0;
        private string _unit;
        private decimal _k = 1M;
        private decimal _b = 0M;
        private decimal _defaultvalue = 0M;
        private int _issave = 1;
        private int _usertype = 0;
        private string _memo = "";
        private string _lowval = "-";
        private string _highval = "-";
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string parametername
        {
            set { _parametername = value; }
            get { return _parametername; }
        }
        /// <summary>
        /// 参数类型，控制，值，状态
        /// </summary>
        public int parametertypeid
        {
            set { _parametertypeid = value; }
            get { return _parametertypeid; }
        }
        /// <summary>
        /// 参数解析的数据类型
        /// </summary>
        public string datatype
        {
            set { _datatype = value; }
            get { return _datatype; }
        }
        /// <summary>
        /// 参数起始位
        /// </summary>
        public int datastartbit
        {
            set { _datastartbit = value; }
            get { return _datastartbit; }
        }
        /// <summary>
        /// 参数长度
        /// </summary>
        public int datalen
        {
            set { _datalen = value; }
            get { return _datalen; }
        }
        /// <summary>
        /// 数据 字节中的  bit位
        /// </summary>
        public int databit
        {
            set { _databit = value; }
            get { return _databit; }
        }
        /// <summary>
        /// 代码
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 发送命令
        /// </summary>
        public string cmd
        {
            set { _cmd = value; }
            get { return _cmd; }
        }
        /// <summary>
        /// 发送id
        /// </summary>
        public string SenderID
        {
            set { _senderid = value; }
            get { return _senderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TargetID
        {
            set { _targetid = value; }
            get { return _targetid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 数据斜率
        /// </summary>
        public decimal k
        {
            set { _k = value; }
            get { return _k; }
        }
        /// <summary>
        /// 数据截距
        /// </summary>
        public decimal b
        {
            set { _b = value; }
            get { return _b; }
        }
        /// <summary>
        /// 默认值
        /// </summary>
        public decimal DefaultValue
        {
            set { _defaultvalue = value; }
            get { return _defaultvalue; }
        }
        /// <summary>
        /// 是否保存数据
        /// </summary>
        public int IsSave
        {
            set { _issave = value; }
            get { return _issave; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int usertype
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LowVal
        {
            set { _lowval = value; }
            get { return _lowval; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HighVal
        {
            set { _highval = value; }
            get { return _highval; }
        }
        #endregion Model

    }
}

