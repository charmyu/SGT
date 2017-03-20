/**  版本信息模板在安装目录下，可自行修改。
* Parameter.cs
*
* 功 能： N/A
* 类 名： Parameter
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 9:19:48   N/A    初版
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
    /// 数据访问类:Parameter
    /// </summary>
    public partial class Parameter
    {
        public Parameter()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Parameter");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Power.Model.Parameter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Parameter(");
            strSql.Append("ID,parametername,parametertypeid,datatype,datastartbit,datalen,databit,code,cmd,SenderID,TargetID,unit,k,b,DefaultValue,IsSave,usertype,Memo,LowVal,HighVal)");
            strSql.Append(" values (");
            strSql.Append("@ID,@parametername,@parametertypeid,@datatype,@datastartbit,@datalen,@databit,@code,@cmd,@SenderID,@TargetID,@unit,@k,@b,@DefaultValue,@IsSave,@usertype,@Memo,@LowVal,@HighVal)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@parametername", SqlDbType.NVarChar,50),
					new SqlParameter("@parametertypeid", SqlDbType.Int,4),
					new SqlParameter("@datatype", SqlDbType.NVarChar,50),
					new SqlParameter("@datastartbit", SqlDbType.Int,4),
					new SqlParameter("@datalen", SqlDbType.Int,4),
					new SqlParameter("@databit", SqlDbType.Int,4),
					new SqlParameter("@code", SqlDbType.NVarChar,50),
					new SqlParameter("@cmd", SqlDbType.NVarChar,50),
					new SqlParameter("@SenderID", SqlDbType.NVarChar,50),
					new SqlParameter("@TargetID", SqlDbType.Int,4),
					new SqlParameter("@unit", SqlDbType.NVarChar,50),
					new SqlParameter("@k", SqlDbType.Float,8),
					new SqlParameter("@b", SqlDbType.Float,8),
					new SqlParameter("@DefaultValue", SqlDbType.Float,8),
					new SqlParameter("@IsSave", SqlDbType.Int,4),
					new SqlParameter("@usertype", SqlDbType.Int,4),
					new SqlParameter("@Memo", SqlDbType.NVarChar,500),
					new SqlParameter("@LowVal", SqlDbType.NVarChar,50),
					new SqlParameter("@HighVal", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.parametername;
            parameters[2].Value = model.parametertypeid;
            parameters[3].Value = model.datatype;
            parameters[4].Value = model.datastartbit;
            parameters[5].Value = model.datalen;
            parameters[6].Value = model.databit;
            parameters[7].Value = model.code;
            parameters[8].Value = model.cmd;
            parameters[9].Value = model.SenderID;
            parameters[10].Value = model.TargetID;
            parameters[11].Value = model.unit;
            parameters[12].Value = model.k;
            parameters[13].Value = model.b;
            parameters[14].Value = model.DefaultValue;
            parameters[15].Value = model.IsSave;
            parameters[16].Value = model.usertype;
            parameters[17].Value = model.Memo;
            parameters[18].Value = model.LowVal;
            parameters[19].Value = model.HighVal;

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
        public bool Update(Power.Model.Parameter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Parameter set ");
            strSql.Append("parametername=@parametername,");
            strSql.Append("parametertypeid=@parametertypeid,");
            strSql.Append("datatype=@datatype,");
            strSql.Append("datastartbit=@datastartbit,");
            strSql.Append("datalen=@datalen,");
            strSql.Append("databit=@databit,");
            strSql.Append("code=@code,");
            strSql.Append("cmd=@cmd,");
            strSql.Append("SenderID=@SenderID,");
            strSql.Append("TargetID=@TargetID,");
            strSql.Append("unit=@unit,");
            strSql.Append("k=@k,");
            strSql.Append("b=@b,");
            strSql.Append("DefaultValue=@DefaultValue,");
            strSql.Append("IsSave=@IsSave,");
            strSql.Append("usertype=@usertype,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("LowVal=@LowVal,");
            strSql.Append("HighVal=@HighVal");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@parametername", SqlDbType.NVarChar,50),
					new SqlParameter("@parametertypeid", SqlDbType.Int,4),
					new SqlParameter("@datatype", SqlDbType.NVarChar,50),
					new SqlParameter("@datastartbit", SqlDbType.Int,4),
					new SqlParameter("@datalen", SqlDbType.Int,4),
					new SqlParameter("@databit", SqlDbType.Int,4),
					new SqlParameter("@code", SqlDbType.NVarChar,50),
					new SqlParameter("@cmd", SqlDbType.NVarChar,50),
					new SqlParameter("@SenderID", SqlDbType.NVarChar,50),
					new SqlParameter("@TargetID", SqlDbType.Int,4),
					new SqlParameter("@unit", SqlDbType.NVarChar,50),
					new SqlParameter("@k", SqlDbType.Float,8),
					new SqlParameter("@b", SqlDbType.Float,8),
					new SqlParameter("@DefaultValue", SqlDbType.Float,8),
					new SqlParameter("@IsSave", SqlDbType.Int,4),
					new SqlParameter("@usertype", SqlDbType.Int,4),
					new SqlParameter("@Memo", SqlDbType.NVarChar,500),
					new SqlParameter("@LowVal", SqlDbType.NVarChar,50),
					new SqlParameter("@HighVal", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.parametername;
            parameters[1].Value = model.parametertypeid;
            parameters[2].Value = model.datatype;
            parameters[3].Value = model.datastartbit;
            parameters[4].Value = model.datalen;
            parameters[5].Value = model.databit;
            parameters[6].Value = model.code;
            parameters[7].Value = model.cmd;
            parameters[8].Value = model.SenderID;
            parameters[9].Value = model.TargetID;
            parameters[10].Value = model.unit;
            parameters[11].Value = model.k;
            parameters[12].Value = model.b;
            parameters[13].Value = model.DefaultValue;
            parameters[14].Value = model.IsSave;
            parameters[15].Value = model.usertype;
            parameters[16].Value = model.Memo;
            parameters[17].Value = model.LowVal;
            parameters[18].Value = model.HighVal;
            parameters[19].Value = model.ID;

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
            strSql.Append("delete from Parameter ");
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
            strSql.Append("delete from Parameter ");
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
        public Power.Model.Parameter GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,parametername,parametertypeid,datatype,datastartbit,datalen,databit,code,cmd,SenderID,TargetID,unit,k,b,DefaultValue,IsSave,usertype,Memo,LowVal,HighVal from Parameter ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = ID;

            Power.Model.Parameter model = new Power.Model.Parameter();
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
        public Power.Model.Parameter DataRowToModel(DataRow row)
        {
            Power.Model.Parameter model = new Power.Model.Parameter();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["parametername"] != null)
                {
                    model.parametername = row["parametername"].ToString();
                }
                if (row["parametertypeid"] != null && row["parametertypeid"].ToString() != "")
                {
                    model.parametertypeid = int.Parse(row["parametertypeid"].ToString());
                }
                if (row["datatype"] != null)
                {
                    model.datatype = row["datatype"].ToString();
                }
                if (row["datastartbit"] != null && row["datastartbit"].ToString() != "")
                {
                    model.datastartbit = int.Parse(row["datastartbit"].ToString());
                }
                if (row["datalen"] != null && row["datalen"].ToString() != "")
                {
                    model.datalen = int.Parse(row["datalen"].ToString());
                }
                if (row["databit"] != null && row["databit"].ToString() != "")
                {
                    model.databit = int.Parse(row["databit"].ToString());
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["cmd"] != null)
                {
                    model.cmd = row["cmd"].ToString();
                }
                if (row["SenderID"] != null)
                {
                    model.SenderID = row["SenderID"].ToString();
                }
                if (row["TargetID"] != null && row["TargetID"].ToString() != "")
                {
                    model.TargetID = int.Parse(row["TargetID"].ToString());
                }
                if (row["unit"] != null)
                {
                    model.unit = row["unit"].ToString();
                }
                if (row["k"] != null && row["k"].ToString() != "")
                {
                    model.k = decimal.Parse(row["k"].ToString());
                }
                if (row["b"] != null && row["b"].ToString() != "")
                {
                    model.b = decimal.Parse(row["b"].ToString());
                }
                if (row["DefaultValue"] != null && row["DefaultValue"].ToString() != "")
                {
                    model.DefaultValue = decimal.Parse(row["DefaultValue"].ToString());
                }
                if (row["IsSave"] != null && row["IsSave"].ToString() != "")
                {
                    model.IsSave = int.Parse(row["IsSave"].ToString());
                }
                if (row["usertype"] != null && row["usertype"].ToString() != "")
                {
                    model.usertype = int.Parse(row["usertype"].ToString());
                }
                if (row["Memo"] != null)
                {
                    model.Memo = row["Memo"].ToString();
                }
                if (row["LowVal"] != null)
                {
                    model.LowVal = row["LowVal"].ToString();
                }
                if (row["HighVal"] != null)
                {
                    model.HighVal = row["HighVal"].ToString();
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
            strSql.Append("select ID,parametername,parametertypeid,datatype,datastartbit,datalen,databit,code,cmd,SenderID,TargetID,unit,k,b,DefaultValue,IsSave,usertype,Memo,LowVal,HighVal ");
            strSql.Append(" FROM Parameter ");
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
            strSql.Append(" ID,parametername,parametertypeid,datatype,datastartbit,datalen,databit,code,cmd,SenderID,TargetID,unit,k,b,DefaultValue,IsSave,usertype,Memo,LowVal,HighVal ");
            strSql.Append(" FROM Parameter ");
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
            strSql.Append("select count(1) FROM Parameter ");
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
            strSql.Append(")AS Row, T.*  from Parameter T ");
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
            parameters[0].Value = "Parameter";
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
        /// 获得关联表数据列表
        /// </summary>
        public DataSet GetAllList(string strWhere)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append(" select para.ID,parametername,parametertypeid,datatype,datastartbit,datalen,databit,code,cmd,SenderID,");
            //strSql.Append("  TargetID,unit,k, b,DefaultValue,IsSave,usertype,ut.typename,pt.parametertypename ");
            //strSql.Append("  from dbo.Parameter para inner join dbo.Sys_UserType ut on para .usertype=ut .typeId  ");
            //strSql.Append(" inner join dbo.ParameterType pt on pt.parametertype= para .parametertypeid ");

            StringBuilder strSql = new StringBuilder();
            strSql.Append("  SELECT  tp.templetID, t.templetname, dbo.Module.ModuleName, dbo.Module.ID AS ModuleID, pt.parametertypename,");
            strSql.Append(" p.parametername, tp.parameterID, p.parametertypeid, p.SenderID, p.datatype, ");
            strSql.Append("  p.datastartbit, p.datalen, p.databit, p.code, p.cmd, p.TargetID, p.unit, ");
            strSql.Append("  p.k, p.b, p.DefaultValue, p.IsSave, p.usertype,p.Memo,p.LowVal,p.HighVal,ut.typeId,ut.typename");
            strSql.Append(" FROM  dbo.Module INNER JOIN");
            strSql.Append("  dbo.Templet t ON dbo.Module.templetID = t.ID INNER JOIN");
            strSql.Append("  dbo.TempletPara tp ON t.ID = tp.templetID INNER JOIN");
            strSql.Append("  dbo.Parameter p ON tp.parameterID = p.ID AND dbo.Module.NO = p.SenderID INNER JOIN");
            strSql.Append("  dbo.ParameterType pt ON p.parametertypeid = pt.parametertype INNER JOIN dbo.Sys_UserType ut on p.usertype=ut .typeId ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


       /// <summary>
        ///  获得参数
       /// </summary>
       /// <param name="strWhere">设备ID</param>
       /// <returns></returns>
        public DataSet GetParamListByDeviceID(string strWhere)
        {
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  SELECT  dbo.Device.ID, dbo.Device.templetID, dbo.Parameter.parametername, dbo.Parameter.ID AS ParamID, dbo.Parameter.SenderID, dbo.Parameter.parametertypeid ");
            strSql.Append(" FROM   dbo.Device INNER JOIN ");
            strSql.Append("   dbo.TempletPara ON dbo.Device.templetID = dbo.TempletPara.templetID INNER JOIN ");
            strSql.Append("  dbo.Parameter ON dbo.TempletPara.parameterID = dbo.Parameter.ID");
          
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}

