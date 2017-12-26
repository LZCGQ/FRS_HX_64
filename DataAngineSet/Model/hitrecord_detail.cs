/**  版本信息模板在安装目录下，可自行修改。
* hitrecord_detail.cs
*
* 功 能： N/A
* 类 名： hitrecord_detail
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
	/// hitrecord_detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class hitrecord_detail
	{
		public hitrecord_detail()
		{}
		#region Model
		private int _id;
		private int _hit_record_id;
		private int _user_id;
		private int _rank;
		private decimal _score;
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
		public int hit_record_id
		{
			set{ _hit_record_id=value;}
			get{return _hit_record_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
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
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

