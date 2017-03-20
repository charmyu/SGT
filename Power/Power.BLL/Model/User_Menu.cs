using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Model
{/// <summary>
    /// User_Menu:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class User_Menu
    {
        public User_Menu()
        { }
        #region Model
        private int _id;
        private int _usertypeid;
        private int _menuid;
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
        /// 
        /// </summary>
        public int UserTypeID
        {
            set { _usertypeid = value; }
            get { return _usertypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MenuID
        {
            set { _menuid = value; }
            get { return _menuid; }
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
