/**  版本信息模板在安装目录下，可自行修改。
* MenuInfo.cs
*
* 功 能： N/A
* 类 名： MenuInfo
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
	/// 数据访问类:MenuInfo
	/// </summary>
	public partial class MenuInfo
	{
		public MenuInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Menu_ID", "MenuInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Menu_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MenuInfo");
			strSql.Append(" where Menu_ID=@Menu_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Menu_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Menu_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Power.Model.MenuInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MenuInfo(");
			strSql.Append("Menu_Name,Menu_Link,Menu_IsVisible,Menu_Parent,Menu_UserType,Menu_Imgurl)");
			strSql.Append(" values (");
			strSql.Append("@Menu_Name,@Menu_Link,@Menu_IsVisible,@Menu_Parent,@Menu_UserType,@Menu_Imgurl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Menu_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Menu_Link", SqlDbType.NVarChar,200),
					new SqlParameter("@Menu_IsVisible", SqlDbType.Int,4),
					new SqlParameter("@Menu_Parent", SqlDbType.NVarChar,50),
					new SqlParameter("@Menu_UserType", SqlDbType.Int,4),
					new SqlParameter("@Menu_Imgurl", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.Menu_Name;
			parameters[1].Value = model.Menu_Link;
			parameters[2].Value = model.Menu_IsVisible;
			parameters[3].Value = model.Menu_Parent;
			parameters[4].Value = model.Menu_UserType;
			parameters[5].Value = model.Menu_Imgurl;

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
		public bool Update(Power.Model.MenuInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MenuInfo set ");
			strSql.Append("Menu_Name=@Menu_Name,");
			strSql.Append("Menu_Link=@Menu_Link,");
			strSql.Append("Menu_IsVisible=@Menu_IsVisible,");
			strSql.Append("Menu_Parent=@Menu_Parent,");
			strSql.Append("Menu_UserType=@Menu_UserType,");
			strSql.Append("Menu_Imgurl=@Menu_Imgurl");
			strSql.Append(" where Menu_ID=@Menu_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Menu_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Menu_Link", SqlDbType.NVarChar,200),
					new SqlParameter("@Menu_IsVisible", SqlDbType.Int,4),
					new SqlParameter("@Menu_Parent", SqlDbType.NVarChar,50),
					new SqlParameter("@Menu_UserType", SqlDbType.Int,4),
					new SqlParameter("@Menu_Imgurl", SqlDbType.NVarChar,500),
					new SqlParameter("@Menu_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Menu_Name;
			parameters[1].Value = model.Menu_Link;
			parameters[2].Value = model.Menu_IsVisible;
			parameters[3].Value = model.Menu_Parent;
			parameters[4].Value = model.Menu_UserType;
			parameters[5].Value = model.Menu_Imgurl;
			parameters[6].Value = model.Menu_ID;

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
		public bool Delete(int Menu_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MenuInfo ");
			strSql.Append(" where Menu_ID=@Menu_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Menu_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Menu_ID;

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
		public bool DeleteList(string Menu_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MenuInfo ");
			strSql.Append(" where Menu_ID in ("+Menu_IDlist + ")  ");
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
		public Power.Model.MenuInfo GetModel(int Menu_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Menu_ID,Menu_Name,Menu_Link,Menu_IsVisible,Menu_Parent,Menu_UserType,Menu_Imgurl from MenuInfo ");
			strSql.Append(" where Menu_ID=@Menu_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Menu_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Menu_ID;

			Power.Model.MenuInfo model=new Power.Model.MenuInfo();
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
		public Power.Model.MenuInfo DataRowToModel(DataRow row)
		{
			Power.Model.MenuInfo model=new Power.Model.MenuInfo();
			if (row != null)
			{
				if(row["Menu_ID"]!=null && row["Menu_ID"].ToString()!="")
				{
					model.Menu_ID=int.Parse(row["Menu_ID"].ToString());
				}
				if(row["Menu_Name"]!=null)
				{
					model.Menu_Name=row["Menu_Name"].ToString();
				}
				if(row["Menu_Link"]!=null)
				{
					model.Menu_Link=row["Menu_Link"].ToString();
				}
				if(row["Menu_IsVisible"]!=null && row["Menu_IsVisible"].ToString()!="")
				{
					model.Menu_IsVisible=int.Parse(row["Menu_IsVisible"].ToString());
				}
				if(row["Menu_Parent"]!=null)
				{
					model.Menu_Parent=row["Menu_Parent"].ToString();
				}
				if(row["Menu_UserType"]!=null && row["Menu_UserType"].ToString()!="")
				{
					model.Menu_UserType=int.Parse(row["Menu_UserType"].ToString());
				}
				if(row["Menu_Imgurl"]!=null)
				{
					model.Menu_Imgurl=row["Menu_Imgurl"].ToString();
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
			strSql.Append("select Menu_ID,Menu_Name,Menu_Link,Menu_IsVisible,Menu_Parent,Menu_UserType,Menu_Imgurl ");
			strSql.Append(" FROM MenuInfo ");
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
			strSql.Append(" Menu_ID,Menu_Name,Menu_Link,Menu_IsVisible,Menu_Parent,Menu_UserType,Menu_Imgurl ");
			strSql.Append(" FROM MenuInfo ");
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
			strSql.Append("select count(1) FROM MenuInfo ");
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
				strSql.Append("order by T.Menu_ID desc");
			}
			strSql.Append(")AS Row, T.*  from MenuInfo T ");
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
			parameters[0].Value = "MenuInfo";
			parameters[1].Value = "Menu_ID";
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

