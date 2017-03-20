using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Model
{/// <summary>
    /// Device_CMD:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Device_CMD
    {
        public Device_CMD()
        { }
        #region Model
        private string _id;
        private string _cmd;
        private string _cmdname;
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CMD
        {
            set { _cmd = value; }
            get { return _cmd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CMDName
        {
            set { _cmdname = value; }
            get { return _cmdname; }
        }
        #endregion Model

    }
}
