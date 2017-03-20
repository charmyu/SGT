/**  版本信息模板在安装目录下，可自行修改。
* Device.cs
*
* 功 能： N/A
* 类 名： Device
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
using Power.BLL.DBUtility;

namespace Power.DAL
{
    /// <summary>
    /// 数据访问类:Device
    /// </summary>
    public partial class Device
    {
        public Device()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Device");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Power.Model.Device model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Device(");
            strSql.Append("ID,name,SerialNo,stationname,stationaddress,type,N,E,state,phone,TM,dtuIP,dtuport,dtuTM,templetID,DepId)");
            strSql.Append(" values (");
            strSql.Append("@ID,@name,@SerialNo,@stationname,@stationaddress,@type,@N,@E,@state,@phone,@TM,@dtuIP,@dtuport,@dtuTM,@templetID,@DepId)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@SerialNo", SqlDbType.NVarChar,50),
					new SqlParameter("@stationname", SqlDbType.NVarChar,50),
					new SqlParameter("@stationaddress", SqlDbType.NVarChar,500),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@N", SqlDbType.NVarChar,50),
					new SqlParameter("@E", SqlDbType.NVarChar,50),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@phone", SqlDbType.NVarChar,11),
					new SqlParameter("@TM", SqlDbType.DateTime),
					new SqlParameter("@dtuIP", SqlDbType.NVarChar,50),
					new SqlParameter("@dtuport", SqlDbType.NVarChar,50),
					new SqlParameter("@dtuTM", SqlDbType.DateTime),
					new SqlParameter("@templetID", SqlDbType.NVarChar,50),
					new SqlParameter("@DepId", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.name;
            parameters[2].Value = model.SerialNo;
            parameters[3].Value = model.stationname;
            parameters[4].Value = model.stationaddress;
            parameters[5].Value = model.type;
            parameters[6].Value = model.N;
            parameters[7].Value = model.E;
            parameters[8].Value = model.state;
            parameters[9].Value = model.phone;
            parameters[10].Value = model.TM;
            parameters[11].Value = model.dtuIP;
            parameters[12].Value = model.dtuport;
            parameters[13].Value = model.dtuTM;
            parameters[14].Value = model.templetID;
            parameters[15].Value = model.DepId;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Power.Model.Device model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Device set ");
            strSql.Append("name=@name,");
            strSql.Append("SerialNo=@SerialNo,");
            strSql.Append("stationname=@stationname,");
            strSql.Append("stationaddress=@stationaddress,");
            strSql.Append("type=@type,");
            strSql.Append("N=@N,");
            strSql.Append("E=@E,");
            strSql.Append("state=@state,");
            strSql.Append("phone=@phone,");
            strSql.Append("TM=@TM,");
            strSql.Append("dtuIP=@dtuIP,");
            strSql.Append("dtuport=@dtuport,");
            strSql.Append("dtuTM=@dtuTM,");
            strSql.Append("templetID=@templetID,");
            strSql.Append("DepId=@DepId");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@SerialNo", SqlDbType.NVarChar,50),
					new SqlParameter("@stationname", SqlDbType.NVarChar,50),
					new SqlParameter("@stationaddress", SqlDbType.NVarChar,500),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@N", SqlDbType.NVarChar,50),
					new SqlParameter("@E", SqlDbType.NVarChar,50),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@phone", SqlDbType.NVarChar,11),
					new SqlParameter("@TM", SqlDbType.DateTime),
					new SqlParameter("@dtuIP", SqlDbType.NVarChar,50),
					new SqlParameter("@dtuport", SqlDbType.NVarChar,50),
					new SqlParameter("@dtuTM", SqlDbType.DateTime),
					new SqlParameter("@templetID", SqlDbType.NVarChar,50),
					new SqlParameter("@DepId", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.SerialNo;
            parameters[2].Value = model.stationname;
            parameters[3].Value = model.stationaddress;
            parameters[4].Value = model.type;
            parameters[5].Value = model.N;
            parameters[6].Value = model.E;
            parameters[7].Value = model.state;
            parameters[8].Value = model.phone;
            parameters[9].Value = model.TM;
            parameters[10].Value = model.dtuIP;
            parameters[11].Value = model.dtuport;
            parameters[12].Value = model.dtuTM;
            parameters[13].Value = model.templetID;
            parameters[14].Value = model.DepId;
            parameters[15].Value = model.ID;

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
        public bool Delete(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Device ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)			};
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
            strSql.Append("delete from Device ");
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
        public Power.Model.Device GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,name,SerialNo,stationname,stationaddress,type,N,E,state,phone,TM,dtuIP,dtuport,dtuTM,templetID,DepId from Device ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = ID;

            Power.Model.Device model = new Power.Model.Device();
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
        public Power.Model.Device DataRowToModel(DataRow row)
        {
            Power.Model.Device model = new Power.Model.Device();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["SerialNo"] != null)
                {
                    model.SerialNo = row["SerialNo"].ToString();
                }
                if (row["stationname"] != null)
                {
                    model.stationname = row["stationname"].ToString();
                }
                if (row["stationaddress"] != null)
                {
                    model.stationaddress = row["stationaddress"].ToString();
                }
                if (row["type"] != null && row["type"].ToString() != "")
                {
                    model.type = int.Parse(row["type"].ToString());
                }
                if (row["N"] != null)
                {
                    model.N = row["N"].ToString();
                }
                if (row["E"] != null)
                {
                    model.E = row["E"].ToString();
                }
                if (row["state"] != null && row["state"].ToString() != "")
                {
                    model.state = int.Parse(row["state"].ToString());
                }
                if (row["phone"] != null)
                {
                    model.phone = row["phone"].ToString();
                }
                if (row["TM"] != null && row["TM"].ToString() != "")
                {
                    model.TM = DateTime.Parse(row["TM"].ToString());
                }
                if (row["dtuIP"] != null)
                {
                    model.dtuIP = row["dtuIP"].ToString();
                }
                if (row["dtuport"] != null)
                {
                    model.dtuport = row["dtuport"].ToString();
                }
                if (row["dtuTM"] != null && row["dtuTM"].ToString() != "")
                {
                    model.dtuTM = DateTime.Parse(row["dtuTM"].ToString());
                }
                if (row["templetID"] != null)
                {
                    model.templetID = row["templetID"].ToString();
                }
                if (row["DepId"] != null)
                {
                    model.DepId = row["DepId"].ToString();
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
            strSql.Append("select ID,name,SerialNo,stationname,stationaddress,type,N,E,state,phone,TM,dtuIP,dtuport,dtuTM,templetID,DepId ");
            strSql.Append(" FROM Device ");
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
            strSql.Append(" ID,name,SerialNo,stationname,stationaddress,type,N,E,state,phone,TM,dtuIP,dtuport,dtuTM,templetID,DepId ");
            strSql.Append(" FROM Device ");
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
            strSql.Append("select count(1) FROM Device ");
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
            strSql.Append(")AS Row, T.*  from Device T ");
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
            parameters[0].Value = "Device";
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
        /// 获得多表查询数据列表
        /// </summary>
        public DataSet GetAllList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select d.ID,name,SerialNo,stationname,stationaddress,type,N,E,state,phone,TM,dtuIP,dtuport,dtuTM,templetID,DepId,t.templetname,sd.Dep_Name ");
            strSql.Append(" From dbo.Device d inner join dbo.Templet t on d.templetID=t.ID inner join dbo.Sys_Department sd on sd.Dep_ID=d.DepId ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取设备实时数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDevcieDataList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select rt.ID,ModuleID,rt.prarmeterID,parametertypeid,RTVal,rt.TM,d.state,p.SenderID,p.TargetID,p.LowVal,p.HighVal,datastartbit,p.parametername,datatype,unit,name,dtuTM ");
            strSql.Append("  from dbo.RT_APoint rt inner join dbo.Device d on rt.ModuleID=d.ID inner join dbo.Parameter p on rt.prarmeterID=p.ID ");
           
            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by p.datastartbit ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取设备历史数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDevcieHistoricalData(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select h.ID,DeviceID,h.ParameterID,parametertypeid,p.SenderID,paraVal,h.ParameterName as TM,d.state, datastartbit,p.parametername,datatype,unit,name,dtuTM ");
            strSql.Append("  from dbo.HistoricalData h inner join dbo.Device d on h.DeviceID=d.ID inner join dbo.Parameter p on h.ParameterID=p.ID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }




        /// <summary>
        /// 主要数据显示
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDevcieMainData(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select stationname,parametername, RTVal into #tmpTable from ");
            strSql.Append("( SELECT dbo.Device.stationname, dbo.Parameter.parametername, dbo.RT_APoint.RTVal,dbo.Parameter.datastartbit");
            strSql.Append(" FROM dbo.RT_APoint INNER JOIN dbo.Device ON dbo.RT_APoint.ModuleID = dbo.Device.ID INNER JOIN dbo.Parameter ON dbo.RT_APoint.prarmeterID = dbo.Parameter.ID");
            strSql.Append(" Where dbo.Parameter.IsSave=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }

            strSql.Append(" ) as dev  order by CAST(datastartbit AS INT)");
            strSql.Append(" declare @sql varchar(8000)");
            strSql.Append(" declare @count int select @count= @@rowcount ");
            strSql.Append(" if(@count>0) ");
            strSql.Append(" begin ");
            strSql.Append(" select @sql = isnull(@sql + '],[' , '') + parametername from #tmpTable GROUP BY  parametername ");
            strSql.Append(" select @sql =  '[' + @sql + ']' ");
            strSql.Append(" exec ('select stationname as 基站名称,'+@sql+' from #tmpTable pivot (max(RTVal) for parametername in (' + @sql + '))Tbl')");
            strSql.Append(" end drop table #tmpTable");

            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  ExtensionMethod
    }
}

