/**  版本信息模板在安装目录下，可自行修改。
* device.cs
*
* 功 能： N/A
* 类 名： device
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
	/// device:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class device
	{
		public device()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _video_address;
		private string _departmentment_id;
		private double? _longitude;
		private double? _latitude;
		private string _location_type;
		private string _type;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string video_address
		{
			set{ _video_address=value;}
			get{return _video_address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string departmentment_id
		{
			set{ _departmentment_id=value;}
			get{return _departmentment_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double? longitude
		{
			set{ _longitude=value;}
			get{return _longitude;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double? latitude
		{
			set{ _latitude=value;}
			get{return _latitude;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string location_type
		{
			set{ _location_type=value;}
			get{return _location_type;}
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
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

