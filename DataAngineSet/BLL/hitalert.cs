/**  版本信息模板在安装目录下，可自行修改。
* hitalert.cs
*
* 功 能： N/A
* 类 名： hitalert
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
	/// hitalert
	/// </summary>
	public partial class hitalert
	{
        private readonly DataAngineSet.DAL.hitalert dal = new DataAngineSet.DAL.hitalert();
        #region  BasicMethod
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(DataAngineSet.Model.hitalert model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(DataAngineSet.Model.hitalert model)
        {
            return dal.Update(model);

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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        public List<DataAngineSet.Model.hitalert> DataTableToList(DataTable table)
        {
            List<DataAngineSet.Model.hitalert> modelList = new List<Model.hitalert>();
            List<DataTable> newTables = new List<DataTable>();
            HashSet<int> groupIds = new HashSet<int>();
            foreach (DataRow row in table.Rows)
            {
                int groupId = int.Parse(row["id"].ToString());
                if (!groupIds.Contains(groupId))
                {
                    groupIds.Add(groupId);
                    DataTable newTable = table.Clone();
                    newTable.TableName = groupId.ToString();
                    newTable.ImportRow(row);
                    newTables.Add(newTable);
                }
                else
                {
                    DataTable newTable = newTables.Find(x => x.TableName == groupId.ToString());
                    newTable.ImportRow(row);
                }
            }

            foreach (var tb in newTables)
            {
                modelList.Add(dal.DataTableToModel(tb));
            }
            return modelList;
        }

        #endregion  BasicMethod
		
        #region  ExtensionMethod
        /// <summary>
        /// 通过时间得到对象实体
        /// </summary>
        public List<DataAngineSet.Model.hitalert> GetModelByTime(DateTime startTime, DateTime endTime)
        {
            DataSet ds = dal.GetModelByTime(startTime, endTime);

            return DataTableToList(ds.Tables[0]);

        }

        public DataSet GetListByTime(DateTime startTime, DateTime endTime)
        {
            string strWhere = string.Format("occur_time between '{0}' and '{1}'", startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"));
            return dal.GetList(strWhere);
        }

        public DataSet GetListByTime(DateTime startTime, DateTime endTime, string libraryid)
        {
            string strWhere = string.Format("occur_time between '{0}' and '{1}'", startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"));
            return dal.GetList(strWhere, libraryid);
        }

        //分页时间查询
        public DataSet GetListByTime(DateTime startTime, DateTime endTime, int startIndex, int pageSize)
        {
            string strWhere = string.Format("occur_time between '{0}' and '{1}'", startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"));
            return dal.GetList(strWhere, startIndex, pageSize);
        }

        //分页时间查询
        public DataSet GetListByTime(DateTime startTime, DateTime endTime, int startIndex, int pageSize, string libraryid)
        {
            string strWhere = string.Format("occur_time between '{0}' and '{1}'", startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"));
            return dal.GetList(strWhere, startIndex, pageSize, libraryid);
        }

        //匹配人员查询
        public DataSet GetListById(int userId)
        {
            return dal.GetList(userId);
        }
        
		#endregion  ExtensionMethod
	}
}

