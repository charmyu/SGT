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
using System.Collections.Generic;
 
using Power.Model;
namespace Power.BLL
{
	/// <summary>
	/// Sys_User
	/// </summary>
	public partial class Sys_User
	{
		private readonly Power.DAL.Sys_User dal=new Power.DAL.Sys_User();
		public Sys_User()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string LogName)
		{
			return dal.Exists(LogName);
		}

  

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Power.Model.Sys_User model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Power.Model.Sys_User model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string LogName)
		{
			
			return dal.Delete(LogName);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string LogNamelist )
		{
			return dal.DeleteList(LogNamelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Power.Model.Sys_User GetModel(string LogName)
		{
			
			return dal.GetModel(LogName);
		}

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public Power.Model.Sys_User GetModelByCache(string LogName)
        //{
			
        //    string CacheKey = "Sys_UserModel-" + LogName;
        //    object objModel = Power.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(LogName);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Power.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Power.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Power.Model.Sys_User)objModel;
        //}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Power.Model.Sys_User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Power.Model.Sys_User> DataTableToList(DataTable dt)
		{
			List<Power.Model.Sys_User> modelList = new List<Power.Model.Sys_User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Power.Model.Sys_User model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得关联表数据列表
		/// </summary>
		public DataSet GetAllList(string sqlwhere)
		{
            return dal.GetAllList(sqlwhere);
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

