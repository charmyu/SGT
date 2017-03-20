/**  版本信息模板在安装目录下，可自行修改。
* HistoricalData.cs
*
* 功 能： N/A
* 类 名： HistoricalData
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
	/// 数据访问类:HistoricalData
	/// </summary>
	public partial class HistoricalData
	{
		public HistoricalData()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from HistoricalData");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Power.Model.HistoricalData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HistoricalData(");
			strSql.Append("ID,DeviceID,ParameterID,ParameterName,paraVal)");
			strSql.Append(" values (");
			strSql.Append("@ID,@DeviceID,@ParameterID,@ParameterName,@paraVal)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@DeviceID", SqlDbType.NVarChar,50),
					new SqlParameter("@ParameterID", SqlDbType.NVarChar,50),
					new SqlParameter("@ParameterName", SqlDbType.NVarChar,50),
					new SqlParameter("@paraVal", SqlDbType.Float,8)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.DeviceID;
			parameters[2].Value = model.ParameterID;
			parameters[3].Value = model.ParameterName;
			parameters[4].Value = model.paraVal;

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
		public bool Update(Power.Model.HistoricalData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HistoricalData set ");
			strSql.Append("DeviceID=@DeviceID,");
			strSql.Append("ParameterID=@ParameterID,");
			strSql.Append("ParameterName=@ParameterName,");
			strSql.Append("paraVal=@paraVal");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DeviceID", SqlDbType.NVarChar,50),
					new SqlParameter("@ParameterID", SqlDbType.NVarChar,50),
					new SqlParameter("@ParameterName", SqlDbType.NVarChar,50),
					new SqlParameter("@paraVal", SqlDbType.Float,8),
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.DeviceID;
			parameters[1].Value = model.ParameterID;
			parameters[2].Value = model.ParameterName;
			parameters[3].Value = model.paraVal;
			parameters[4].Value = model.ID;

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
		public bool Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HistoricalData ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HistoricalData ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public Power.Model.HistoricalData GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,DeviceID,ParameterID,ParameterName,paraVal from HistoricalData ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = ID;

			Power.Model.HistoricalData model=new Power.Model.HistoricalData();
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
		public Power.Model.HistoricalData DataRowToModel(DataRow row)
		{
			Power.Model.HistoricalData model=new Power.Model.HistoricalData();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["DeviceID"]!=null)
				{
					model.DeviceID=row["DeviceID"].ToString();
				}
				if(row["ParameterID"]!=null)
				{
					model.ParameterID=row["ParameterID"].ToString();
				}
				if(row["ParameterName"]!=null)
				{
					model.ParameterName=row["ParameterName"].ToString();
				}
				if(row["paraVal"]!=null && row["paraVal"].ToString()!="")
				{
					model.paraVal=decimal.Parse(row["paraVal"].ToString());
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
			strSql.Append("select ID,DeviceID,ParameterID,ParameterName,paraVal ");
			strSql.Append(" FROM HistoricalData ");
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
			strSql.Append(" ID,DeviceID,ParameterID,ParameterName,paraVal ");
			strSql.Append(" FROM HistoricalData ");
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
			strSql.Append("select count(1) FROM HistoricalData ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from HistoricalData T ");
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
			parameters[0].Value = "HistoricalData";
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
        /// 获取历史曲线数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetLineDataByDeviceID(string strWhere, string sdate, string sfun)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("  SELECT     " + sfun + "(hd.paraVal)as Val,DATEPART(" + sdate + ",hd.ParameterName) as TM ");
            strSql.Append(" FROM         dbo.Parameter p INNER JOIN dbo.HistoricalData hd ON p.ID = hd.ParameterID ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("   GROUP BY   DATEPART(" + sdate + ",hd.ParameterName)");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获取历史表格数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDataTableByDeviceID(string strWhere, string sdate, string sfun)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("  SELECT parametername,Val,TM  into #tmpTable from ");
            strSql.Append(" (SELECT  p.parametername, " + sfun + "(hd.paraVal)as Val,DATEPART(" + sdate + ",hd.ParameterName) as TM ");
            strSql.Append(" FROM  dbo.Parameter p INNER JOIN dbo.HistoricalData hd ON p.ID = hd.ParameterID ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("   GROUP BY   DATEPART(" + sdate + ",hd.ParameterName),p.parametername");
            strSql.Append(") as dev order by TM");
            strSql.Append(" declare @sql varchar(8000) ");
            strSql.Append(" declare @count int select @count= @@rowcount");
            strSql.Append(" if(@count>0)   begin");
            strSql.Append("  select @sql = isnull(@sql + '],[' , '') + cast(TM as varchar(10)) from #tmpTable GROUP BY  TM  ");
            strSql.Append("select @sql ='[' + @sql + ']'  ");
            strSql.Append(" exec ('select parametername as 设备参数名称,'+@sql+' from #tmpTable pivot (max(Val) for TM in (' + @sql + '))Tbl') ");
            strSql.Append(" end drop table #tmpTable ");
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  ExtensionMethod
	}
}

