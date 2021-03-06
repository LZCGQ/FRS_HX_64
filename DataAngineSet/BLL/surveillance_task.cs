﻿/**  版本信息模板在安装目录下，可自行修改。
* surveillance_task.cs
*
* 功 能： N/A
* 类 名： surveillance_task
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/12/26 16:42:46   N/A    初版
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
    /// surveillance_task
    /// </summary>
    public partial class surveillance_task
    {
        private readonly DataAngineSet.DAL.surveillance_task dal = new DataAngineSet.DAL.surveillance_task();
        public surveillance_task()
        { }
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
        public bool Add(DataAngineSet.Model.surveillance_task model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DataAngineSet.Model.surveillance_task model)
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
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataAngineSet.Model.surveillance_task GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataSet GetModel_Cascade(int id)
        {

            return dal.GetModel_Cascade(id);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList_Cascade(string strWhere)
        {
            return dal.GetList_Cascade(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DataAngineSet.Model.surveillance_task> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DataAngineSet.Model.surveillance_task> DataTableToList(DataTable dt)
        {
            List<DataAngineSet.Model.surveillance_task> modelList = new List<DataAngineSet.Model.surveillance_task>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DataAngineSet.Model.surveillance_task model;
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList_Cascade()
        {
            return GetList_Cascade("");
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
        public DataSet GetAllList(int startIndex, int pageSize, string strWhere)
        {
            return dal.GetList(startIndex, pageSize, strWhere);
        }

        public DataSet GetAllList_Cascade(int startIndex, int pageSize, string strWhere)
        {
            return dal.GetList_Cascade(startIndex, pageSize, strWhere);
        }
        #endregion  ExtensionMethod
    }
}

