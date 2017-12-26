/**  版本信息模板在安装目录下，可自行修改。
* hitrecord.cs
*
* 功 能： N/A
* 类 名： hitrecord
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
	/// hitrecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class hitrecord
	{
		public hitrecord()
		{}
		#region Model
		private int _id;
		private string _face_query_image_path;
		private decimal _threshold;
		private DateTime _occur_time;
		private int? _task_id;
		private string _remark;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
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
		public decimal threshold
		{
			set{ _threshold=value;}
			get{return _threshold;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime occur_time
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
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

