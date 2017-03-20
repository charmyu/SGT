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
using System.Collections.Generic;
 
using Power.Model;
namespace Power.BLL
{
	/// <summary>
	/// Sys_Department
	/// </summary>
	public partial class Sys_Department
	{
		private readonly Power.DAL.Sys_Department dal=new Power.DAL.Sys_Department();
		public Sys_Department()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Dep_ID)
		{
			return dal.Exists(Dep_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Power.Model.Sys_Department model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Power.Model.Sys_Department model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Dep_ID)
		{
			
			return dal.Delete(Dep_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Dep_IDlist )
		{
			return dal.DeleteList(Dep_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Power.Model.Sys_Department GetModel(string Dep_ID)
		{
			
			return dal.GetModel(Dep_ID);
		}

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public Power.Model.Sys_Department GetModelByCache(string Dep_ID)
        //{
			
        //    string CacheKey = "Sys_DepartmentModel-" + Dep_ID;
        //    object objModel = Power.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Dep_ID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Power.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Power.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Power.Model.Sys_Department)objModel;
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
		public List<Power.Model.Sys_Department> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Power.Model.Sys_Department> DataTableToList(DataTable dt)
		{
			List<Power.Model.Sys_Department> modelList = new List<Power.Model.Sys_Department>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Power.Model.Sys_Department model;
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
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
        /// <summary>
        /// 获取新机构编号
        /// </summary>
        /// <param name="parentId">父机构编号</param>
        /// <returns></returns>
        public string GetDepartId(string parentId)
        {
            string childId = "";
            IList<Power.Model.Sys_Department> list = GetModelList(string.Format("Dep_Parent='{0}' order by Dep_Id asc", parentId));   //取所有子机构
            if (list.Count != 0)
            {
                string strNumId = list[list.Count - 1].Dep_ID.Substring(parentId.Length, 2);
                int nNumId = Convert.ToInt32(strNumId) + 1;
                childId = parentId + nNumId.ToString("D2");
            }
            else
            {
                childId = parentId + "01";
            }
            return childId;
        }
		#endregion  ExtensionMethod
	}
}

