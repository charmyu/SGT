/**  版本信息模板在安装目录下，可自行修改。
* EventLog.cs
*
* 功 能： N/A
* 类 名： EventLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 9:19:46   N/A    初版
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
	/// 数据访问类:EventLog
	/// </summary>
	public partial class EventLog
	{
		public EventLog()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EventLog");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Power.Model.EventLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EventLog(");
			strSql.Append("ID,deviceID,msgNO,msgID,rtr_TM,runtime,cmd,cmdsource,sysstate,faultcount,normaltime,alarm_state)");
			strSql.Append(" values (");
			strSql.Append("@ID,@deviceID,@msgNO,@msgID,@rtr_TM,@runtime,@cmd,@cmdsource,@sysstate,@faultcount,@normaltime,@alarm_state)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@deviceID", SqlDbType.NVarChar,50),
					new SqlParameter("@msgNO", SqlDbType.NVarChar,50),
					new SqlParameter("@msgID", SqlDbType.NVarChar,50),
					new SqlParameter("@rtr_TM", SqlDbType.DateTime),
					new SqlParameter("@runtime", SqlDbType.Int,4),
					new SqlParameter("@cmd", SqlDbType.NVarChar,50),
					new SqlParameter("@cmdsource", SqlDbType.NVarChar,50),
					new SqlParameter("@sysstate", SqlDbType.Int,4),
					new SqlParameter("@faultcount", SqlDbType.Int,4),
					new SqlParameter("@normaltime", SqlDbType.Int,4),
					new SqlParameter("@alarm_state", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.deviceID;
			parameters[2].Value = model.msgNO;
			parameters[3].Value = model.msgID;
			parameters[4].Value = model.rtr_TM;
			parameters[5].Value = model.runtime;
			parameters[6].Value = model.cmd;
			parameters[7].Value = model.cmdsource;
			parameters[8].Value = model.sysstate;
			parameters[9].Value = model.faultcount;
			parameters[10].Value = model.normaltime;
			parameters[11].Value = model.alarm_state;

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
		public bool Update(Power.Model.EventLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EventLog set ");
			strSql.Append("deviceID=@deviceID,");
			strSql.Append("msgNO=@msgNO,");
			strSql.Append("msgID=@msgID,");
			strSql.Append("rtr_TM=@rtr_TM,");
			strSql.Append("runtime=@runtime,");
			strSql.Append("cmd=@cmd,");
			strSql.Append("cmdsource=@cmdsource,");
			strSql.Append("sysstate=@sysstate,");
			strSql.Append("faultcount=@faultcount,");
			strSql.Append("normaltime=@normaltime,");
			strSql.Append("alarm_state=@alarm_state");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@deviceID", SqlDbType.NVarChar,50),
					new SqlParameter("@msgNO", SqlDbType.NVarChar,50),
					new SqlParameter("@msgID", SqlDbType.NVarChar,50),
					new SqlParameter("@rtr_TM", SqlDbType.DateTime),
					new SqlParameter("@runtime", SqlDbType.Int,4),
					new SqlParameter("@cmd", SqlDbType.NVarChar,50),
					new SqlParameter("@cmdsource", SqlDbType.NVarChar,50),
					new SqlParameter("@sysstate", SqlDbType.Int,4),
					new SqlParameter("@faultcount", SqlDbType.Int,4),
					new SqlParameter("@normaltime", SqlDbType.Int,4),
					new SqlParameter("@alarm_state", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.deviceID;
			parameters[1].Value = model.msgNO;
			parameters[2].Value = model.msgID;
			parameters[3].Value = model.rtr_TM;
			parameters[4].Value = model.runtime;
			parameters[5].Value = model.cmd;
			parameters[6].Value = model.cmdsource;
			parameters[7].Value = model.sysstate;
			parameters[8].Value = model.faultcount;
			parameters[9].Value = model.normaltime;
			parameters[10].Value = model.alarm_state;
			parameters[11].Value = model.ID;

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
			strSql.Append("delete from EventLog ");
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
			strSql.Append("delete from EventLog ");
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
		public Power.Model.EventLog GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,deviceID,msgNO,msgID,rtr_TM,runtime,cmd,cmdsource,sysstate,faultcount,normaltime,alarm_state from EventLog ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = ID;

			Power.Model.EventLog model=new Power.Model.EventLog();
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
		public Power.Model.EventLog DataRowToModel(DataRow row)
		{
			Power.Model.EventLog model=new Power.Model.EventLog();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["deviceID"]!=null)
				{
					model.deviceID=row["deviceID"].ToString();
				}
				if(row["msgNO"]!=null)
				{
					model.msgNO=row["msgNO"].ToString();
				}
				if(row["msgID"]!=null)
				{
					model.msgID=row["msgID"].ToString();
				}
				if(row["rtr_TM"]!=null && row["rtr_TM"].ToString()!="")
				{
					model.rtr_TM=DateTime.Parse(row["rtr_TM"].ToString());
				}
				if(row["runtime"]!=null && row["runtime"].ToString()!="")
				{
					model.runtime=int.Parse(row["runtime"].ToString());
				}
				if(row["cmd"]!=null)
				{
					model.cmd=row["cmd"].ToString();
				}
				if(row["cmdsource"]!=null)
				{
					model.cmdsource=row["cmdsource"].ToString();
				}
				if(row["sysstate"]!=null && row["sysstate"].ToString()!="")
				{
					model.sysstate=int.Parse(row["sysstate"].ToString());
				}
				if(row["faultcount"]!=null && row["faultcount"].ToString()!="")
				{
					model.faultcount=int.Parse(row["faultcount"].ToString());
				}
				if(row["normaltime"]!=null && row["normaltime"].ToString()!="")
				{
					model.normaltime=int.Parse(row["normaltime"].ToString());
				}
				if(row["alarm_state"]!=null)
				{
					model.alarm_state=row["alarm_state"].ToString();
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
			strSql.Append("select ID,deviceID,msgNO,msgID,rtr_TM,runtime,cmd,cmdsource,sysstate,faultcount,normaltime,alarm_state ");
			strSql.Append(" FROM EventLog ");
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
			strSql.Append(" ID,deviceID,msgNO,msgID,rtr_TM,runtime,cmd,cmdsource,sysstate,faultcount,normaltime,alarm_state ");
			strSql.Append(" FROM EventLog ");
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
			strSql.Append("select count(1) FROM EventLog ");
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
			strSql.Append(")AS Row, T.*  from EventLog T ");
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
			parameters[0].Value = "EventLog";
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
        /// 获得关联数据列表
        /// </summary>
        public DataSet GetAllRelationTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select e.ID,deviceID,d.name ,msgNO,msgID,rtr_TM,runtime,cmd,cmdsource,sysstate,faultcount,normaltime,alarm_state ");
            strSql.Append(" from dbo.EventLog e inner join dbo.Device d on e.deviceID =d.ID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  ExtensionMethod
	}
}

