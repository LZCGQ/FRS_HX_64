﻿/**  版本信息模板在安装目录下，可自行修改。
* person.cs
*
* 功 能： N/A
* 类 名： person
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/12/26 16:42:45   N/A    初版
*
* Copyright (c) 2012 DataAngineSet Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using DataAngineSet.Model;
namespace DataAngineSet.BLL
{
	/// <summary>
	/// person
	/// </summary>
	public partial class person
	{
		private readonly DataAngineSet.DAL.person dal=new DataAngineSet.DAL.person();
		public person()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataAngineSet.Model.person model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DataAngineSet.Model.person model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByName(string name)
        {
            return dal.DeleteByName(name);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByName(string name, string libraryid)
        {
            return dal.DeleteByName(name, libraryid);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DataAngineSet.Model.person GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

        public List<Model.person> GetAllUser()
        {

            DataSet ds = dal.GetList(string.Empty);
            List<Model.person> allUsers;
            DataTable dt = ds.Tables[0];

            allUsers = DataTableToList(dt);

            return allUsers;
        }


        public List<Model.person> GetAllUser(string libraryid)
        {

            DataSet ds = dal.GetList(libraryid);
            List<Model.person> allUsers;
            DataTable dt = ds.Tables[0];

            allUsers = DataTableToList(dt);

            return allUsers;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList(string libraryid)
		{
            return dal.GetList(libraryid);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DataAngineSet.Model.person> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DataAngineSet.Model.person> DataTableToList(DataTable dt)
		{
			List<DataAngineSet.Model.person> modelList = new List<DataAngineSet.Model.person>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DataAngineSet.Model.person model;
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


        public DataSet GetList_Library(string libraryid)
        {
            return dal.GetList(libraryid);
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
        public DataSet GetList(int PageSize, int PageIndex, string libraryid)
        {
            return dal.GetList(PageSize, PageIndex, libraryid);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

