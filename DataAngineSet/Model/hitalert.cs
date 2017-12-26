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
namespace DataAngineSet.Model
{
	/// <summary>
	/// hitalert:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class hitalert
	{
		public hitalert()
		{}
		#region Model
		private int? _id=0;
		private string _face_query_image_path;
		private decimal? _threshold;
		private DateTime? _occur_time;
		private int? _task_id;
		private int _detail_id=0;
		private int _rank;
		private decimal _score;
		private int? _user_id=0;
		private string _user_name;
		private string _user_gender;
		private string _user_card_id;
		private int? _user_person_dataset_id;
		private string _user_image_id;
		private string _user_face_image_path;
		private string _user_type;
		private DateTime? _user_create_time;
		private DateTime? _user_modified_time;
		private decimal? _user_quality_score;
		/// <summary>
		/// 
		/// </summary>
		public int? id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string face_query_image_path
		{
			set{ _face_query_image_path=value;}
			get{return _face_query_image_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? threshold
		{
			set{ _threshold=value;}
			get{return _threshold;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? occur_time
		{
			set{ _occur_time=value;}
			get{return _occur_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? task_id
		{
			set{ _task_id=value;}
			get{return _task_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int detail_id
		{
			set{ _detail_id=value;}
			get{return _detail_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int rank
		{
			set{ _rank=value;}
			get{return _rank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_name
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_gender
		{
			set{ _user_gender=value;}
			get{return _user_gender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_card_id
		{
			set{ _user_card_id=value;}
			get{return _user_card_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? user_person_dataset_id
		{
			set{ _user_person_dataset_id=value;}
			get{return _user_person_dataset_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_image_id
		{
			set{ _user_image_id=value;}
			get{return _user_image_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_face_image_path
		{
			set{ _user_face_image_path=value;}
			get{return _user_face_image_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_type
		{
			set{ _user_type=value;}
			get{return _user_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? user_create_time
		{
			set{ _user_create_time=value;}
			get{return _user_create_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? user_modified_time
		{
			set{ _user_modified_time=value;}
			get{return _user_modified_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? user_quality_score
		{
			set{ _user_quality_score=value;}
			get{return _user_quality_score;}
		}
		#endregion Model

	}
}

