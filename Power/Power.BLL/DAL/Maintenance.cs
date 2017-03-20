using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Power.BLL.DBUtility;//Please add references

namespace Power.DAL
{
    /// <summary>
    /// 数据访问类:Maintenance
    /// </summary>
    public partial class Maintenance
    {
        public Maintenance()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Maintenance");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Power.Model.Maintenance model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Maintenance(");
            strSql.Append("DeviceID,Dep_ID,UserID,TM,Memo,ImgName,reserver)");
            strSql.Append(" values (");
            strSql.Append("@DeviceID,@Dep_ID,@UserID,@TM,@Memo,@ImgName,@reserver)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DeviceID", SqlDbType.NVarChar,50),
					new SqlParameter("@Dep_ID", SqlDbType.NVarChar,50),
					new SqlParameter("@UserID", SqlDbType.NVarChar,50),
					new SqlParameter("@TM", SqlDbType.DateTime),
					new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
					new SqlParameter("@ImgName", SqlDbType.NVarChar,100),
					new SqlParameter("@reserver", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.DeviceID;
            parameters[1].Value = model.Dep_ID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.TM;
            parameters[4].Value = model.Memo;
            parameters[5].Value = model.ImgName;
            parameters[6].Value = model.reserver;

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
        public bool Update(Power.Model.Maintenance model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Maintenance set ");
            strSql.Append("DeviceID=@DeviceID,");
            strSql.Append("Dep_ID=@Dep_ID,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("TM=@TM,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("ImgName=@ImgName,");
            strSql.Append("reserver=@reserver");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@DeviceID", SqlDbType.NVarChar,50),
					new SqlParameter("@Dep_ID", SqlDbType.NVarChar,50),
					new SqlParameter("@UserID", SqlDbType.NVarChar,50),
					new SqlParameter("@TM", SqlDbType.DateTime),
					new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
					new SqlParameter("@ImgName", SqlDbType.NVarChar,100),
					new SqlParameter("@reserver", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.DeviceID;
            parameters[1].Value = model.Dep_ID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.TM;
            parameters[4].Value = model.Memo;
            parameters[5].Value = model.ImgName;
            parameters[6].Value = model.reserver;
            parameters[7].Value = model.ID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Maintenance ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Maintenance ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public Power.Model.Maintenance GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,DeviceID,Dep_ID,UserID,TM,Memo,ImgName,reserver from Maintenance ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Power.Model.Maintenance model = new Power.Model.Maintenance();
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
        public Power.Model.Maintenance DataRowToModel(DataRow row)
        {
            Power.Model.Maintenance model = new Power.Model.Maintenance();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["DeviceID"] != null)
                {
                    model.DeviceID = row["DeviceID"].ToString();
                }
                if (row["Dep_ID"] != null)
                {
                    model.Dep_ID = row["Dep_ID"].ToString();
                }
                if (row["UserID"] != null)
                {
                    model.UserID = row["UserID"].ToString();
                }
                if (row["TM"] != null && row["TM"].ToString() != "")
                {
                    model.TM = DateTime.Parse(row["TM"].ToString());
                }
                if (row["Memo"] != null)
                {
                    model.Memo = row["Memo"].ToString();
                }
                if (row["ImgName"] != null)
                {
                    model.ImgName = row["ImgName"].ToString();
                }
                if (row["reserver"] != null)
                {
                    model.reserver = row["reserver"].ToString();
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
            strSql.Append("select ID,DeviceID,Dep_ID,UserID,TM,Memo,ImgName,reserver ");
            strSql.Append(" FROM Maintenance ");
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
            strSql.Append(" ID,DeviceID,Dep_ID,UserID,TM,Memo,ImgName,reserver ");
            strSql.Append(" FROM Maintenance ");
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
            strSql.Append("select count(1) FROM Maintenance ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from Maintenance T ");
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
            parameters[0].Value = "Maintenance";
            parameters[1].Value = "ID";
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT     dbo.Device.stationname, dbo.Maintenance.DeviceID, dbo.Maintenance.Dep_ID, dbo.Maintenance.UserID, dbo.Maintenance.TM, dbo.Maintenance.Memo, dbo.Maintenance.ID, ");
            strSql.Append(" dbo.Maintenance.ImgName, dbo.Sys_Department.Dep_Name ");
            strSql.Append(" FROM dbo.Sys_Department INNER JOIN ");
            strSql.Append(" dbo.Maintenance ON dbo.Sys_Department.Dep_ID = dbo.Maintenance.Dep_ID INNER JOIN ");
            strSql.Append("  dbo.Device ON dbo.Maintenance.DeviceID = dbo.Device.ID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}


