/**  版本信息模板在安装目录下，可自行修改。
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
using System.Text;
using MySql.Data.MySqlClient;
using DataAngineSet.DBUtility;//Please add references
namespace DataAngineSet.DAL
{
	/// <summary>
	/// 数据访问类:person
	/// </summary>
	public partial class person
	{
		public person()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "person"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from person");
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
		public bool Add(DataAngineSet.Model.person model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into person(");
			strSql.Append("person_dataset_id,name,gender,card_id,bitrhday,image_id,face_image_path,feature_data,type,create_time,modified_time,quality_score,remark)");
			strSql.Append(" values (");
			strSql.Append("@person_dataset_id,@name,@gender,@card_id,@bitrhday,@image_id,@face_image_path,@feature_data,@type,@create_time,@modified_time,@quality_score,@remark)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@person_dataset_id", MySqlDbType.Int32,11),
					new MySqlParameter("@name", MySqlDbType.VarChar,50),
					new MySqlParameter("@gender", MySqlDbType.VarChar,1),
					new MySqlParameter("@card_id", MySqlDbType.VarChar,50),
					new MySqlParameter("@bitrhday", MySqlDbType.DateTime),
					new MySqlParameter("@image_id", MySqlDbType.VarChar,60),
					new MySqlParameter("@face_image_path", MySqlDbType.VarChar,200),
					new MySqlParameter("@feature_data", MySqlDbType.LongBlob),
					new MySqlParameter("@type", MySqlDbType.VarChar,1),
					new MySqlParameter("@create_time", MySqlDbType.DateTime),
					new MySqlParameter("@modified_time", MySqlDbType.DateTime),
					new MySqlParameter("@quality_score", MySqlDbType.Float),
					new MySqlParameter("@remark", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.person_dataset_id;
			parameters[1].Value = model.name;
			parameters[2].Value = model.gender;
			parameters[3].Value = model.card_id;
			parameters[4].Value = model.bitrhday;
			parameters[5].Value = model.image_id;
			parameters[6].Value = model.face_image_path;
			parameters[7].Value = model.feature_data;
			parameters[8].Value = model.type;
			parameters[9].Value = model.create_time;
			parameters[10].Value = model.modified_time;
			parameters[11].Value = model.quality_score;
			parameters[12].Value = model.remark;

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
		public bool Update(DataAngineSet.Model.person model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update person set ");
			strSql.Append("person_dataset_id=@person_dataset_id,");
			strSql.Append("name=@name,");
			strSql.Append("gender=@gender,");
			strSql.Append("card_id=@card_id,");
			strSql.Append("bitrhday=@bitrhday,");
			strSql.Append("image_id=@image_id,");
			strSql.Append("face_image_path=@face_image_path,");
			strSql.Append("feature_data=@feature_data,");
			strSql.Append("type=@type,");
			strSql.Append("create_time=@create_time,");
			strSql.Append("modified_time=@modified_time,");
			strSql.Append("quality_score=@quality_score,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@person_dataset_id", MySqlDbType.Int32,11),
					new MySqlParameter("@name", MySqlDbType.VarChar,50),
					new MySqlParameter("@gender", MySqlDbType.VarChar,1),
					new MySqlParameter("@card_id", MySqlDbType.VarChar,50),
					new MySqlParameter("@bitrhday", MySqlDbType.DateTime),
					new MySqlParameter("@image_id", MySqlDbType.VarChar,60),
					new MySqlParameter("@face_image_path", MySqlDbType.VarChar,200),
					new MySqlParameter("@feature_data", MySqlDbType.LongBlob),
					new MySqlParameter("@type", MySqlDbType.VarChar,1),
					new MySqlParameter("@create_time", MySqlDbType.DateTime),
					new MySqlParameter("@modified_time", MySqlDbType.DateTime),
					new MySqlParameter("@quality_score", MySqlDbType.Float),
					new MySqlParameter("@remark", MySqlDbType.VarChar,50),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.person_dataset_id;
			parameters[1].Value = model.name;
			parameters[2].Value = model.gender;
			parameters[3].Value = model.card_id;
			parameters[4].Value = model.bitrhday;
			parameters[5].Value = model.image_id;
			parameters[6].Value = model.face_image_path;
			parameters[7].Value = model.feature_data;
			parameters[8].Value = model.type;
			parameters[9].Value = model.create_time;
			parameters[10].Value = model.modified_time;
			parameters[11].Value = model.quality_score;
			parameters[12].Value = model.remark;
			parameters[13].Value = model.id;

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
			strSql.Append("delete from person ");
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
			strSql.Append("delete from person ");
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
		public DataAngineSet.Model.person GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,person_dataset_id,name,gender,card_id,bitrhday,image_id,face_image_path,feature_data,type,create_time,modified_time,quality_score,remark from person ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			DataAngineSet.Model.person model=new DataAngineSet.Model.person();
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
		public DataAngineSet.Model.person DataRowToModel(DataRow row)
		{
			DataAngineSet.Model.person model=new DataAngineSet.Model.person();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["person_dataset_id"]!=null && row["person_dataset_id"].ToString()!="")
				{
					model.person_dataset_id=int.Parse(row["person_dataset_id"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["gender"]!=null)
				{
					model.gender=row["gender"].ToString();
				}
				if(row["card_id"]!=null)
				{
					model.card_id=row["card_id"].ToString();
				}
				if(row["bitrhday"]!=null && row["bitrhday"].ToString()!="")
				{
					model.bitrhday=DateTime.Parse(row["bitrhday"].ToString());
				}
				if(row["image_id"]!=null)
				{
					model.image_id=row["image_id"].ToString();
				}
				if(row["face_image_path"]!=null)
				{
					model.face_image_path=row["face_image_path"].ToString();
				}
					//model.feature_data=row["feature_data"].ToString();
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
				if(row["create_time"]!=null && row["create_time"].ToString()!="")
				{
					model.create_time=DateTime.Parse(row["create_time"].ToString());
				}
				if(row["modified_time"]!=null && row["modified_time"].ToString()!="")
				{
					model.modified_time=DateTime.Parse(row["modified_time"].ToString());
				}
				if(row["quality_score"]!=null && row["quality_score"].ToString()!="")
				{
					model.quality_score=decimal.Parse(row["quality_score"].ToString());
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
			strSql.Append("select id,person_dataset_id,name,gender,card_id,bitrhday,image_id,face_image_path,feature_data,type,create_time,modified_time,quality_score,remark ");
			strSql.Append(" FROM person ");
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
			strSql.Append("select count(1) FROM person ");
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
			strSql.Append(")AS Row, T.*  from person T ");
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
			parameters[0].Value = "person";
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

