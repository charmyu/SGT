using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Power.BLL.DBUtility;

namespace Power.DAL
{
    /// <summary>
    /// 数据访问类:Communication
    /// </summary>
    public partial class Communication
    {
        public Communication()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Int)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Communication");
            strSql.Append(" where Int=@Int");
            SqlParameter[] parameters = {
					new SqlParameter("@Int", SqlDbType.Int,4)
			};
            parameters[0].Value = Int;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Power.Model.Communication model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Communication(");
            strSql.Append("ReceiveID,SenderID,Content,Img,TM,State)");
            strSql.Append(" values (");
            strSql.Append("@ReceiveID,@SenderID,@Content,@Img,@TM,@State)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ReceiveID", SqlDbType.NVarChar,50),
					new SqlParameter("@SenderID", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.VarChar,2000),
					new SqlParameter("@Img", SqlDbType.VarChar,100),
					new SqlParameter("@TM", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4)};
            parameters[0].Value = model.ReceiveID;
            parameters[1].Value = model.SenderID;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.Img;
            parameters[4].Value = model.TM;
            parameters[5].Value = model.State;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Power.Model.Communication model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Communication set ");
            strSql.Append("ReceiveID=@ReceiveID,");
            strSql.Append("SenderID=@SenderID,");
            strSql.Append("Content=@Content,");
            strSql.Append("Img=@Img,");
            strSql.Append("TM=@TM,");
            strSql.Append("State=@State");
            strSql.Append(" where Int=@Int");
            SqlParameter[] parameters = {
					new SqlParameter("@ReceiveID", SqlDbType.NVarChar,50),
					new SqlParameter("@SenderID", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.VarChar,2000),
					new SqlParameter("@Img", SqlDbType.VarChar,100),
					new SqlParameter("@TM", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Int", SqlDbType.Int,4)};
            parameters[0].Value = model.ReceiveID;
            parameters[1].Value = model.SenderID;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.Img;
            parameters[4].Value = model.TM;
            parameters[5].Value = model.State;
            parameters[6].Value = model.Int;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Int)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Communication ");
            strSql.Append(" where Int=@Int");
            SqlParameter[] parameters = {
					new SqlParameter("@Int", SqlDbType.Int,4)
			};
            parameters[0].Value = Int;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Intlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Communication ");
            strSql.Append(" where Int in (" + Intlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Power.Model.Communication GetModel(int Int)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Int,ReceiveID,SenderID,Content,Img,TM,State from Communication ");
            strSql.Append(" where Int=@Int");
            SqlParameter[] parameters = {
					new SqlParameter("@Int", SqlDbType.Int,4)
			};
            parameters[0].Value = Int;

            Power.Model.Communication model = new Power.Model.Communication();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Power.Model.Communication DataRowToModel(DataRow row)
        {
            Power.Model.Communication model = new Power.Model.Communication();
            if (row != null)
            {
                if (row["Int"] != null && row["Int"].ToString() != "")
                {
                    model.Int = int.Parse(row["Int"].ToString());
                }
                if (row["ReceiveID"] != null)
                {
                    model.ReceiveID = row["ReceiveID"].ToString();
                }
                if (row["SenderID"] != null)
                {
                    model.SenderID = row["SenderID"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["Img"] != null)
                {
                    model.Img = row["Img"].ToString();
                }
                if (row["TM"] != null && row["TM"].ToString() != "")
                {
                    model.TM = DateTime.Parse(row["TM"].ToString());
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Int,ReceiveID,SenderID,Content,Img,TM,State ");
            strSql.Append(" FROM Communication ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Int,ReceiveID,SenderID,Content,Img,TM,State ");
            strSql.Append(" FROM Communication ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Communication ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Int desc");
            }
            strSql.Append(")AS Row, T.*  from Communication T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Communication";
            parameters[1].Value = "Int";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获得未读的消息发送人
        /// </summary>
        public DataSet GetUNReadSendUser(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  SenderID ,RealName FROM dbo.Communication inner join dbo.Sys_User on SenderID=LogName ");
           
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by SenderID,RealName ");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得消息并改变发送状态
        /// </summary>
        public DataSet GetSendReadAndUpdateState(string strWhere,string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select [Int],ReceiveID,SenderID,Content,Img,TM,[State] into #tmpTable from ");
            strSql.Append("  (select [Int],ReceiveID,SenderID,Content,Img,TM,[State] FROM Communication  ");           
            if (strWhere.Trim() != "")
            {
                strSql.Append(" Where " + strWhere);
            }
            strSql.Append(" ) as c order by TM ");
            strSql.Append("  select * from #tmpTable ");
            strSql.Append(" update Communication set [State] =2 where ReceiveID='" + userid + "' and [Int] in(select [Int] from #tmpTable) ");
            strSql.Append(" drop table #tmpTable ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}
