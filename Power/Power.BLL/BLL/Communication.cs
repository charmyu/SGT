using System;
using System.Data;
using System.Collections.Generic;
using Power.Model;
namespace Power.BLL
{
    /// <summary>
    /// Communication
    /// </summary>
    public partial class Communication
    {
        private readonly Power.DAL.Communication dal = new Power.DAL.Communication();
        public Communication()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Int)
        {
            return dal.Exists(Int);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Power.Model.Communication model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Power.Model.Communication model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Int)
        {

            return dal.Delete(Int);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Intlist)
        {
            return dal.DeleteList(Intlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Power.Model.Communication GetModel(int Int)
        {

            return dal.GetModel(Int);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Power.Model.Communication> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Power.Model.Communication> DataTableToList(DataTable dt)
        {
            List<Power.Model.Communication> modelList = new List<Power.Model.Communication>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Power.Model.Communication model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
                /// <summary>
        /// 获得未读的消息发送人
        /// </summary>
        public DataSet GetUNReadSendUser(string strWhere)
        {
           return dal.GetUNReadSendUser(strWhere);
        }
                /// <summary>
        /// 获得消息并改变发送状态
        /// </summary>
        public DataSet GetSendReadAndUpdateState(string strWhere, string userid)
        {
            return dal.GetSendReadAndUpdateState(strWhere, userid);
        }
        #endregion  ExtensionMethod
    }
}

