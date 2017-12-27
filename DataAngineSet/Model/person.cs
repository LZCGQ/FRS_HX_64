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
namespace DataAngineSet.Model
{
	/// <summary>
	/// person:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class person
	{
		public person()
		{}
		#region Model
		private int _id;
		private int? _person_dataset_id;
		private string _name;
		private string _gender;
		private string _card_id;
		private DateTime? _bitrhday;
		private string _image_id;
		private string _face_image_path;
        private byte[] _feature_data;
		private string _type;
		private DateTime _create_time;
		private DateTime _modified_time;
		private int? _quality_score;
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
		public int? person_dataset_id
		{
			set{ _person_dataset_id=value;}
			get{return _person_dataset_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gender
		{
			set{ _gender=value;}
			get{return _gender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string card_id
		{
			set{ _card_id=value;}
			get{return _card_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? bitrhday
		{
			set{ _bitrhday=value;}
			get{return _bitrhday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string image_id
		{
			set{ _image_id=value;}
			get{return _image_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string face_image_path
		{
			set{ _face_image_path=value;}
			get{return _face_image_path;}
		}
		/// <summary>
		/// 
		/// </summary>
        public byte[] feature_data
		{
			set{ _feature_data=value;}
			get{return _feature_data;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime create_time
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime modified_time
		{
			set{ _modified_time=value;}
			get{return _modified_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? quality_score
		{
			set{ _quality_score=value;}
			get{return _quality_score;}
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

