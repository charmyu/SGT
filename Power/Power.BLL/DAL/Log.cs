/**  版本信息模板在安装目录下，可自行修改。
* Log.cs
*
* 功 能： N/A
* 类 名： Log
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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Power.BLL.DBUtility;//Please add references
namespace Power.DAL
{
	/// <summary>
	/// 数据访问类:Log
	/// </summary>
	public partial class Log
	{
		public Log()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Log_ID", "Log"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Log_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Log");
			strSql.Append(" where Log_ID=@Log_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Log_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Log_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Power.Model.Log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Log(");
			strSql.Append("Log_UserName,Log_Memo,Log_Content,Log_AddTime)");
			strSql.Append(" values (");
			strSql.Append("@Log_UserName,@Log_Memo,@Log_Content,@Log_AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Log_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Log_Memo", SqlDbType.NVarChar,500),
					new SqlParameter("@Log_Content", SqlDbType.Text),
					new SqlParameter("@Log_AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Log_UserName;
			parameters[1].Value = model.Log_Memo;
			parameters[2].Value = model.Log_Content;
			parameters[3].Value = model.Log_AddTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Power.Model.Log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Log set ");
			strSql.Append("Log_UserName=@Log_UserName,");
			strSql.Append("Log_Memo=@Log_Memo,");
			strSql.Append("Log_Content=@Log_Content,");
			strSql.Append("Log_AddTime=@Log_AddTime");
			strSql.Append(" where Log_ID=@Log_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Log_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Log_Memo", SqlDbType.NVarChar,500),
					new SqlParameter("@Log_Content", SqlDbType.Text),
					new SqlParameter("@Log_AddTime", SqlDbType.DateTime),
					new SqlParameter("@Log_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Log_UserName;
			parameters[1].Value = model.Log_Memo;
			parameters[2].Value = model.Log_Content;
			parameters[3].Value = model.Log_AddTime;
			parameters[4].Value = model.Log_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int Log_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Log ");
			strSql.Append(" where Log_ID=@Log_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Log_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Log_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string Log_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Log ");
			strSql.Append(" where Log_ID in ("+Log_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Power.Model.Log GetModel(int Log_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Log_ID,Log_UserName,Log_Memo,Log_Content,Log_AddTime from Log ");
			strSql.Append(" where Log_ID=@Log_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Log_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Log_ID;

			Power.Model.Log model=new Power.Model.Log();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Power.Model.Log DataRowToModel(DataRow row)
		{
			Power.Model.Log model=new Power.Model.Log();
			if (row != null)
			{
				if(row["Log_ID"]!=null && row["Log_ID"].ToString()!="")
				{
					model.Log_ID=int.Parse(row["Log_ID"].ToString());
				}
				if(row["Log_UserName"]!=null)
				{
					model.Log_UserName=row["Log_UserName"].ToString();
				}
				if(row["Log_Memo"]!=null)
				{
					model.Log_Memo=row["Log_Memo"].ToString();
				}
				if(row["Log_Content"]!=null)
				{
					model.Log_Content=row["Log_Content"].ToString();
				}
				if(row["Log_AddTime"]!=null && row["Log_AddTime"].ToString()!="")
				{
					model.Log_AddTime=DateTime.Parse(row["Log_AddTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Log_ID,Log_UserName,Log_Memo,Log_Content,Log_AddTime ");
			strSql.Append(" FROM Log ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Log_ID,Log_UserName,Log_Memo,Log_Content,Log_AddTime ");
			strSql.Append(" FROM Log ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Log ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Log_ID desc");
			}
			strSql.Append(")AS Row, T.*  from Log T ");
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
			parameters[0].Value = "Log";
			parameters[1].Value = "Log_ID";
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
        /// 获得关联数据列表
        /// </summary>
        public DataSet GetAllRelationTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Log_UserName,RealName,Log_Memo,Log_Content,Log_AddTime ");
            strSql.Append(" from dbo.Log l inner join dbo.Sys_User u on l.Log_UserName=u.LogName ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  ExtensionMethod
	}
}

