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
    public partial class hitalert
    {
	    public hitrecord hit { get; set; }
        public hitrecord_detail[] details { get; set; }

	}
}

