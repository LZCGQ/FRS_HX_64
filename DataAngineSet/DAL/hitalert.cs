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
using System.Text;
using MySql.Data.MySqlClient;
using DataAngineSet.DBUtility;//Please add references
namespace DataAngineSet.DAL
{
	/// <summary>
	/// 数据访问类:hitalert
	/// </summary>
	public partial class hitalert
	{
		public hitalert()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataAngineSet.Model.hitalert model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into hitalert(");
			strSql.Append("id,face_query_image_path,threshold,occur_time,task_id,detail_id,rank,score,user_id,user_name,user_gender,user_card_id,user_person_dataset_id,user_image_id,user_face_image_path,user_type,user_create_time,user_modified_time,user_quality_score)");
			strSql.Append(" values (");
			strSql.Append("@id,@face_query_image_path,@threshold,@occur_time,@task_id,@detail_id,@rank,@score,@user_id,@user_name,@user_gender,@user_card_id,@user_person_dataset_id,@user_image_id,@user_face_image_path,@user_type,@user_create_time,@user_modified_time,@user_quality_score)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,11),
					new MySqlParameter("@face_query_image_path", MySqlDbType.VarChar,200),
					new MySqlParameter("@threshold", MySqlDbType.Float),
					new MySqlParameter("@occur_time", MySqlDbType.DateTime),
					new MySqlParameter("@task_id", MySqlDbType.Int32,11),
					new MySqlParameter("@detail_id", MySqlDbType.Int32,11),
					new MySqlParameter("@rank", MySqlDbType.Int32,11),
					new MySqlParameter("@score", MySqlDbType.Float),
					new MySqlParameter("@user_id", MySqlDbType.Int32,11),
					new MySqlParameter("@user_name", MySqlDbType.VarChar,50),
					new MySqlParameter("@user_gender", MySqlDbType.VarChar,1),
					new MySqlParameter("@user_card_id", MySqlDbType.VarChar,50),
					new MySqlParameter("@user_person_dataset_id", MySqlDbType.Int32,11),
					new MySqlParameter("@user_image_id", MySqlDbType.VarChar,60),
					new MySqlParameter("@user_face_image_path", MySqlDbType.VarChar,200),
					new MySqlParameter("@user_type", MySqlDbType.VarChar,1),
					new MySqlParameter("@user_create_time", MySqlDbType.DateTime),
					new MySqlParameter("@user_modified_time", MySqlDbType.DateTime),
					new MySqlParameter("@user_quality_score", MySqlDbType.Float)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.face_query_image_path;
			parameters[2].Value = model.threshold;
			parameters[3].Value = model.occur_time;
			parameters[4].Value = model.task_id;
			parameters[5].Value = model.detail_id;
			parameters[6].Value = model.rank;
			parameters[7].Value = model.score;
			parameters[8].Value = model.user_id;
			parameters[9].Value = model.user_name;
			parameters[10].Value = model.user_gender;
			parameters[11].Value = model.user_card_id;
			parameters[12].Value = model.user_person_dataset_id;
			parameters[13].Value = model.user_image_id;
			parameters[14].Value = model.user_face_image_path;
			parameters[15].Value = model.user_type;
			parameters[16].Value = model.user_create_time;
			parameters[17].Value = model.user_modified_time;
			parameters[18].Value = model.user_quality_score;

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
		public bool Update(DataAngineSet.Model.hitalert model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update hitalert set ");
			strSql.Append("id=@id,");
			strSql.Append("face_query_image_path=@face_query_image_path,");
			strSql.Append("threshold=@threshold,");
			strSql.Append("occur_time=@occur_time,");
			strSql.Append("task_id=@task_id,");
			strSql.Append("detail_id=@detail_id,");
			strSql.Append("rank=@rank,");
			strSql.Append("score=@score,");
			strSql.Append("user_id=@user_id,");
			strSql.Append("user_name=@user_name,");
			strSql.Append("user_gender=@user_gender,");
			strSql.Append("user_card_id=@user_card_id,");
			strSql.Append("user_person_dataset_id=@user_person_dataset_id,");
			strSql.Append("user_image_id=@user_image_id,");
			strSql.Append("user_face_image_path=@user_face_image_path,");
			strSql.Append("user_type=@user_type,");
			strSql.Append("user_create_time=@user_create_time,");
			strSql.Append("user_modified_time=@user_modified_time,");
			strSql.Append("user_quality_score=@user_quality_score");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,11),
					new MySqlParameter("@face_query_image_path", MySqlDbType.VarChar,200),
					new MySqlParameter("@threshold", MySqlDbType.Float),
					new MySqlParameter("@occur_time", MySqlDbType.DateTime),
					new MySqlParameter("@task_id", MySqlDbType.Int32,11),
					new MySqlParameter("@detail_id", MySqlDbType.Int32,11),
					new MySqlParameter("@rank", MySqlDbType.Int32,11),
					new MySqlParameter("@score", MySqlDbType.Float),
					new MySqlParameter("@user_id", MySqlDbType.Int32,11),
					new MySqlParameter("@user_name", MySqlDbType.VarChar,50),
					new MySqlParameter("@user_gender", MySqlDbType.VarChar,1),
					new MySqlParameter("@user_card_id", MySqlDbType.VarChar,50),
					new MySqlParameter("@user_person_dataset_id", MySqlDbType.Int32,11),
					new MySqlParameter("@user_image_id", MySqlDbType.VarChar,60),
					new MySqlParameter("@user_face_image_path", MySqlDbType.VarChar,200),
					new MySqlParameter("@user_type", MySqlDbType.VarChar,1),
					new MySqlParameter("@user_create_time", MySqlDbType.DateTime),
					new MySqlParameter("@user_modified_time", MySqlDbType.DateTime),
					new MySqlParameter("@user_quality_score", MySqlDbType.Float)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.face_query_image_path;
			parameters[2].Value = model.threshold;
			parameters[3].Value = model.occur_time;
			parameters[4].Value = model.task_id;
			parameters[5].Value = model.detail_id;
			parameters[6].Value = model.rank;
			parameters[7].Value = model.score;
			parameters[8].Value = model.user_id;
			parameters[9].Value = model.user_name;
			parameters[10].Value = model.user_gender;
			parameters[11].Value = model.user_card_id;
			parameters[12].Value = model.user_person_dataset_id;
			parameters[13].Value = model.user_image_id;
			parameters[14].Value = model.user_face_image_path;
			parameters[15].Value = model.user_type;
			parameters[16].Value = model.user_create_time;
			parameters[17].Value = model.user_modified_time;
			parameters[18].Value = model.user_quality_score;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from hitalert ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public DataAngineSet.Model.hitalert GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,face_query_image_path,threshold,occur_time,task_id,detail_id,rank,score,user_id,user_name,user_gender,user_card_id,user_person_dataset_id,user_image_id,user_face_image_path,user_type,user_create_time,user_modified_time,user_quality_score from hitalert ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			DataAngineSet.Model.hitalert model=new DataAngineSet.Model.hitalert();
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
		public DataAngineSet.Model.hitalert DataRowToModel(DataRow row)
		{
			DataAngineSet.Model.hitalert model=new DataAngineSet.Model.hitalert();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["face_query_image_path"]!=null)
				{
					model.face_query_image_path=row["face_query_image_path"].ToString();
				}
				if(row["threshold"]!=null && row["threshold"].ToString()!="")
				{
					model.threshold=decimal.Parse(row["threshold"].ToString());
				}
				if(row["occur_time"]!=null && row["occur_time"].ToString()!="")
				{
					model.occur_time=DateTime.Parse(row["occur_time"].ToString());
				}
				if(row["task_id"]!=null && row["task_id"].ToString()!="")
				{
					model.task_id=int.Parse(row["task_id"].ToString());
				}
				if(row["detail_id"]!=null && row["detail_id"].ToString()!="")
				{
					model.detail_id=int.Parse(row["detail_id"].ToString());
				}
				if(row["rank"]!=null && row["rank"].ToString()!="")
				{
					model.rank=int.Parse(row["rank"].ToString());
				}
				if(row["score"]!=null && row["score"].ToString()!="")
				{
					model.score=decimal.Parse(row["score"].ToString());
				}
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["user_name"]!=null)
				{
					model.user_name=row["user_name"].ToString();
				}
				if(row["user_gender"]!=null)
				{
					model.user_gender=row["user_gender"].ToString();
				}
				if(row["user_card_id"]!=null)
				{
					model.user_card_id=row["user_card_id"].ToString();
				}
				if(row["user_person_dataset_id"]!=null && row["user_person_dataset_id"].ToString()!="")
				{
					model.user_person_dataset_id=int.Parse(row["user_person_dataset_id"].ToString());
				}
				if(row["user_image_id"]!=null)
				{
					model.user_image_id=row["user_image_id"].ToString();
				}
				if(row["user_face_image_path"]!=null)
				{
					model.user_face_image_path=row["user_face_image_path"].ToString();
				}
				if(row["user_type"]!=null)
				{
					model.user_type=row["user_type"].ToString();
				}
				if(row["user_create_time"]!=null && row["user_create_time"].ToString()!="")
				{
					model.user_create_time=DateTime.Parse(row["user_create_time"].ToString());
				}
				if(row["user_modified_time"]!=null && row["user_modified_time"].ToString()!="")
				{
					model.user_modified_time=DateTime.Parse(row["user_modified_time"].ToString());
				}
				if(row["user_quality_score"]!=null && row["user_quality_score"].ToString()!="")
				{
					model.user_quality_score=decimal.Parse(row["user_quality_score"].ToString());
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
			strSql.Append("select id,face_query_image_path,threshold,occur_time,task_id,detail_id,rank,score,user_id,user_name,user_gender,user_card_id,user_person_dataset_id,user_image_id,user_face_image_path,user_type,user_create_time,user_modified_time,user_quality_score ");
			strSql.Append(" FROM hitalert ");
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
			strSql.Append("select count(1) FROM hitalert ");
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
			strSql.Append(")AS Row, T.*  from hitalert T ");
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
			parameters[0].Value = "hitalert";
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

