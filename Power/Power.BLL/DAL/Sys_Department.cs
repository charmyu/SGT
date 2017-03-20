/**  版本信息模板在安装目录下，可自行修改。
* Sys_Department.cs
*
* 功 能： N/A
* 类 名： Sys_Department
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
using Power.BLL.DBUtility;
using System.Collections.Generic;//Please add references
namespace Power.DAL
{
	/// <summary>
	/// 数据访问类:Sys_Department
	/// </summary>
	public partial class Sys_Department
	{
		public Sys_Department()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Dep_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Department");
			strSql.Append(" where Dep_ID=@Dep_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Dep_ID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = Dep_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Power.Model.Sys_Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Department(");
			strSql.Append("Dep_ID,Dep_Name,Dep_Contact,Dep_Phone,Dep_Parent,Dep_Type,Dep_imgUrl,Dep_address)");
			strSql.Append(" values (");
			strSql.Append("@Dep_ID,@Dep_Name,@Dep_Contact,@Dep_Phone,@Dep_Parent,@Dep_Type,@Dep_imgUrl,@Dep_address)");
			SqlParameter[] parameters = {
					new SqlParameter("@Dep_ID", SqlDbType.NVarChar,50),
					new SqlParameter("@Dep_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Dep_Contact", SqlDbType.NVarChar,50),
					new SqlParameter("@Dep_Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Dep_Parent", SqlDbType.NVarChar,50),
					new SqlParameter("@Dep_Type", SqlDbType.Int,4),
					new SqlParameter("@Dep_imgUrl", SqlDbType.NVarChar,500),
					new SqlParameter("@Dep_address", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.Dep_ID;
			parameters[1].Value = model.Dep_Name;
			parameters[2].Value = model.Dep_Contact;
			parameters[3].Value = model.Dep_Phone;
			parameters[4].Value = model.Dep_Parent;
			parameters[5].Value = model.Dep_Type;
			parameters[6].Value = model.Dep_imgUrl;
			parameters[7].Value = model.Dep_address;

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
		public bool Update(Power.Model.Sys_Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Department set ");
			strSql.Append("Dep_Name=@Dep_Name,");
			strSql.Append("Dep_Contact=@Dep_Contact,");
			strSql.Append("Dep_Phone=@Dep_Phone,");
			strSql.Append("Dep_Parent=@Dep_Parent,");
			strSql.Append("Dep_Type=@Dep_Type,");
			strSql.Append("Dep_imgUrl=@Dep_imgUrl,");
			strSql.Append("Dep_address=@Dep_address");
			strSql.Append(" where Dep_ID=@Dep_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Dep_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Dep_Contact", SqlDbType.NVarChar,50),
					new SqlParameter("@Dep_Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Dep_Parent", SqlDbType.NVarChar,50),
					new SqlParameter("@Dep_Type", SqlDbType.Int,4),
					new SqlParameter("@Dep_imgUrl", SqlDbType.NVarChar,500),
					new SqlParameter("@Dep_address", SqlDbType.NVarChar,500),
					new SqlParameter("@Dep_ID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Dep_Name;
			parameters[1].Value = model.Dep_Contact;
			parameters[2].Value = model.Dep_Phone;
			parameters[3].Value = model.Dep_Parent;
			parameters[4].Value = model.Dep_Type;
			parameters[5].Value = model.Dep_imgUrl;
			parameters[6].Value = model.Dep_address;
			parameters[7].Value = model.Dep_ID;

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
		public bool Delete(string Dep_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Department ");
			strSql.Append(" where Dep_ID=@Dep_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Dep_ID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = Dep_ID;

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
		public bool DeleteList(string Dep_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Department ");
			strSql.Append(" where Dep_ID in ("+Dep_IDlist + ")  ");
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
		public Power.Model.Sys_Department GetModel(string Dep_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Dep_ID,Dep_Name,Dep_Contact,Dep_Phone,Dep_Parent,Dep_Type,Dep_imgUrl,Dep_address from Sys_Department ");
			strSql.Append(" where Dep_ID=@Dep_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Dep_ID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = Dep_ID;

			Power.Model.Sys_Department model=new Power.Model.Sys_Department();
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
		public Power.Model.Sys_Department DataRowToModel(DataRow row)
		{
			Power.Model.Sys_Department model=new Power.Model.Sys_Department();
			if (row != null)
			{
				if(row["Dep_ID"]!=null)
				{
					model.Dep_ID=row["Dep_ID"].ToString();
				}
				if(row["Dep_Name"]!=null)
				{
					model.Dep_Name=row["Dep_Name"].ToString();
				}
				if(row["Dep_Contact"]!=null)
				{
					model.Dep_Contact=row["Dep_Contact"].ToString();
				}
				if(row["Dep_Phone"]!=null)
				{
					model.Dep_Phone=row["Dep_Phone"].ToString();
				}
				if(row["Dep_Parent"]!=null)
				{
					model.Dep_Parent=row["Dep_Parent"].ToString();
				}
				if(row["Dep_Type"]!=null && row["Dep_Type"].ToString()!="")
				{
					model.Dep_Type=int.Parse(row["Dep_Type"].ToString());
				}
				if(row["Dep_imgUrl"]!=null)
				{
					model.Dep_imgUrl=row["Dep_imgUrl"].ToString();
				}
				if(row["Dep_address"]!=null)
				{
					model.Dep_address=row["Dep_address"].ToString();
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
			strSql.Append("select Dep_ID,Dep_Name,Dep_Contact,Dep_Phone,Dep_Parent,Dep_Type,Dep_imgUrl,Dep_address ");
			strSql.Append(" FROM Sys_Department ");
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
			strSql.Append(" Dep_ID,Dep_Name,Dep_Contact,Dep_Phone,Dep_Parent,Dep_Type,Dep_imgUrl,Dep_address ");
			strSql.Append(" FROM Sys_Department ");
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
			strSql.Append("select count(1) FROM Sys_Department ");
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
				strSql.Append("order by T.Dep_ID desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_Department T ");
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
			parameters[0].Value = "Sys_Department";
			parameters[1].Value = "Dep_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
 
		#endregion  ExtensionMethod
	}
}

