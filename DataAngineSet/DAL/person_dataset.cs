/**  版本信息模板在安装目录下，可自行修改。
* person_dataset.cs
*
* 功 能： N/A
* 类 名： person_dataset
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
using System.Text;
using MySql.Data.MySqlClient;
using DataAngineSet.DBUtility;//Please add references
namespace DataAngineSet.DAL
{
	/// <summary>
	/// 数据访问类:person_dataset
	/// </summary>
	public partial class person_dataset
	{
		public person_dataset()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "person_dataset"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from person_dataset");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataAngineSet.Model.person_dataset model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into person_dataset(");
			strSql.Append("name,type,source,create_time,remark)");
			strSql.Append(" values (");
			strSql.Append("@name,@type,@source,@create_time,@remark)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,50),
					new MySqlParameter("@type", MySqlDbType.VarChar,50),
					new MySqlParameter("@source", MySqlDbType.VarChar,50),
					new MySqlParameter("@create_time", MySqlDbType.DateTime),
					new MySqlParameter("@remark", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.type;
			parameters[2].Value = model.source;
			parameters[3].Value = model.create_time;
			parameters[4].Value = model.remark;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(DataAngineSet.Model.person_dataset model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update person_dataset set ");
			strSql.Append("name=@name,");
			strSql.Append("type=@type,");
			strSql.Append("source=@source,");
			strSql.Append("create_time=@create_time,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,50),
					new MySqlParameter("@type", MySqlDbType.VarChar,50),
					new MySqlParameter("@source", MySqlDbType.VarChar,50),
					new MySqlParameter("@create_time", MySqlDbType.DateTime),
					new MySqlParameter("@remark", MySqlDbType.VarChar,50),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.type;
			parameters[2].Value = model.source;
			parameters[3].Value = model.create_time;
			parameters[4].Value = model.remark;
			parameters[5].Value = model.id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from person_dataset ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from person_dataset ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public DataAngineSet.Model.person_dataset GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,name,type,source,create_time,remark from person_dataset ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			DataAngineSet.Model.person_dataset model=new DataAngineSet.Model.person_dataset();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
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
        public DataAngineSet.Model.person_dataset GetModel(string name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,type,source,create_time,remark from person_dataset ");
            strSql.Append(" where name=@name");
            MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.String)
			};
            parameters[0].Value = name;

            DataAngineSet.Model.person_dataset model = new DataAngineSet.Model.person_dataset();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
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
		public DataAngineSet.Model.person_dataset DataRowToModel(DataRow row)
		{
			DataAngineSet.Model.person_dataset model=new DataAngineSet.Model.person_dataset();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
				if(row["source"]!=null)
				{
					model.source=row["source"].ToString();
				}
				if(row["create_time"]!=null && row["create_time"].ToString()!="")
				{
					model.create_time=DateTime.Parse(row["create_time"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
			strSql.Append("select id,name,type,source,create_time,remark ");
			strSql.Append(" FROM person_dataset ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM person_dataset ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from person_dataset T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "person_dataset";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

