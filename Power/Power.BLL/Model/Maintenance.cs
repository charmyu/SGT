using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Model
{
    /// <summary>
    /// Maintenance:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Maintenance
    {
        public Maintenance()
        { }
        #region Model
        private int _id;
        private string _deviceid;
        private string _dep_id;
        private string _userid;
        private DateTime _tm;
        private string _memo = "";
        private string _imgname = "";
        private string _reserver = "";
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 设备ID
        /// </summary>
        public string DeviceID
        {
            set { _deviceid = value; }
            get { return _deviceid; }
        }
        /// <summary>
        /// 设备 所属机构ID
        /// </summary>
        public string Dep_ID
        {
            set { _dep_id = value; }
            get { return _dep_id; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime TM
        {
            set { _tm = value; }
            get { return _tm; }
        }
        /// <summary>
        /// 维护说明
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImgName
        {
            set { _imgname = value; }
            get { return _imgname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string reserver
        {
            set { _reserver = value; }
            get { return _reserver; }
        }
        #endregion Model

    }
}


