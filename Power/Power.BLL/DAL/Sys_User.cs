/**  版本信息模板在安装目录下，可自行修改。
* Sys_User.cs
*
* 功 能： N/A
* 类 名： Sys_User
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 9:19:50   N/A    初版
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
	/// 数据访问类:Sys_User
	/// </summary>
	public partial class Sys_User
	{
		public Sys_User()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string LogName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_User");
			strSql.Append(" where LogName=@LogName ");
			SqlParameter[] parameters = {
					new SqlParameter("@LogName", SqlDbType.NVarChar,50)			};
			parameters[0].Value = LogName;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Power.Model.Sys_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_User(");
			strSql.Append("LogName,Password,UserLevel,RealName,Company,DepId,Email,Phone,userQQ,userAddress,userImg,TM)");
			strSql.Append(" values (");
			strSql.Append("@LogName,@Password,@UserLevel,@RealName,@Company,@DepId,@Email,@Phone,@userQQ,@userAddress,@userImg,@TM)");
			SqlParameter[] parameters = {
					new SqlParameter("@LogName", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@UserLevel", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Company", SqlDbType.NVarChar,50),
					new SqlParameter("@DepId", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@userQQ", SqlDbType.VarChar,20),
					new SqlParameter("@userAddress", SqlDbType.VarChar,100),
					new SqlParameter("@userImg", SqlDbType.VarChar,100),
					new SqlParameter("@TM", SqlDbType.DateTime)};
			parameters[0].Value = model.LogName;
			parameters[1].Value = model.Password;
			parameters[2].Value = model.UserLevel;
			parameters[3].Value = model.RealName;
			parameters[4].Value = model.Company;
			parameters[5].Value = model.DepId;
			parameters[6].Value = model.Email;
			parameters[7].Value = model.Phone;
			parameters[8].Value = model.userQQ;
			parameters[9].Value = model.userAddress;
			parameters[10].Value = model.userImg;
			parameters[11].Value = model.TM;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Power.Model.Sys_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_User set ");
			strSql.Append("Password=@Password,");
			strSql.Append("UserLevel=@UserLevel,");
			strSql.Append("RealName=@RealName,");
			strSql.Append("Company=@Company,");
			strSql.Append("DepId=@DepId,");
			strSql.Append("Email=@Email,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("userQQ=@userQQ,");
			strSql.Append("userAddress=@userAddress,");
			strSql.Append("userImg=@userImg,");
			strSql.Append("TM=@TM");
			strSql.Append(" where LogName=@LogName ");
			SqlParameter[] parameters = {
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@UserLevel", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Company", SqlDbType.NVarChar,50),
					new SqlParameter("@DepId", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@userQQ", SqlDbType.VarChar,20),
					new SqlParameter("@userAddress", SqlDbType.VarChar,100),
					new SqlParameter("@userImg", SqlDbType.VarChar,100),
					new SqlParameter("@TM", SqlDbType.DateTime),
					new SqlParameter("@LogName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Password;
			parameters[1].Value = model.UserLevel;
			parameters[2].Value = model.RealName;
			parameters[3].Value = model.Company;
			parameters[4].Value = model.DepId;
			parameters[5].Value = model.Email;
			parameters[6].Value = model.Phone;
			parameters[7].Value = model.userQQ;
			parameters[8].Value = model.userAddress;
			parameters[9].Value = model.userImg;
			parameters[10].Value = model.TM;
			parameters[11].Value = model.LogName;

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
		public bool Delete(string LogName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_User ");
			strSql.Append(" where LogName=@LogName ");
			SqlParameter[] parameters = {
					new SqlParameter("@LogName", SqlDbType.NVarChar,50)			};
			parameters[0].Value = LogName;

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
		public bool DeleteList(string LogNamelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_User ");
			strSql.Append(" where LogName in ("+LogNamelist + ")  ");
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
		public Power.Model.Sys_User GetModel(string LogName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LogName,Password,UserLevel,RealName,Company,DepId,Email,Phone,userQQ,userAddress,userImg,TM from Sys_User ");
			strSql.Append(" where LogName=@LogName ");
			SqlParameter[] parameters = {
					new SqlParameter("@LogName", SqlDbType.NVarChar,50)			};
			parameters[0].Value = LogName;

			Power.Model.Sys_User model=new Power.Model.Sys_User();
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
		public Power.Model.Sys_User DataRowToModel(DataRow row)
		{
			Power.Model.Sys_User model=new Power.Model.Sys_User();
			if (row != null)
			{
				if(row["LogName"]!=null)
				{
					model.LogName=row["LogName"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["UserLevel"]!=null && row["UserLevel"].ToString()!="")
				{
					model.UserLevel=int.Parse(row["UserLevel"].ToString());
				}
				if(row["RealName"]!=null)
				{
					model.RealName=row["RealName"].ToString();
				}
				if(row["Company"]!=null)
				{
					model.Company=row["Company"].ToString();
				}
				if(row["DepId"]!=null)
				{
					model.DepId=row["DepId"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["userQQ"]!=null)
				{
					model.userQQ=row["userQQ"].ToString();
				}
				if(row["userAddress"]!=null)
				{
					model.userAddress=row["userAddress"].ToString();
				}
				if(row["userImg"]!=null)
				{
					model.userImg=row["userImg"].ToString();
				}
				if(row["TM"]!=null && row["TM"].ToString()!="")
				{
					model.TM=DateTime.Parse(row["TM"].ToString());
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
			strSql.Append("select LogName,Password,UserLevel,RealName,Company,DepId,Email,Phone,userQQ,userAddress,userImg,TM ");
			strSql.Append(" FROM Sys_User ");
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
			strSql.Append(" LogName,Password,UserLevel,RealName,Company,DepId,Email,Phone,userQQ,userAddress,userImg,TM ");
			strSql.Append(" FROM Sys_User ");
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
			strSql.Append("select count(1) FROM Sys_User ");
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
				strSql.Append("order by T.LogName desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_User T ");
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
			parameters[0].Value = "Sys_User";
			parameters[1].Value = "LogName";
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
        /// 获得关联表数据列表
        /// </summary>
        public DataSet GetAllList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LogName,Password,UserLevel,RealName,Company,DepId,Email,Phone,userQQ,userAddress,userImg,TM,typename,Dep_Name ");
            strSql.Append(" from dbo.Sys_User su left join dbo.Sys_Department sd on su.DepId=sd.Dep_ID left join dbo.Sys_UserType sut on su.UserLevel= sut.typeId ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  ExtensionMethod
	}
}

