﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DataAngineSet.Model;
using System.Data;
namespace FRSServerHttp.Model
{

    class SearchInfo_SurveillanceTask
    {
        public int StartIndex { get; set; }
        public int PageSize { get; set; }

        public static SearchInfo_SurveillanceTask CreateInstanceFromJSON(string json)
        {
            SearchInfo_SurveillanceTask msg = null;
            try
            {
                msg = (SearchInfo_SurveillanceTask)JsonConvert.DeserializeObject(json, typeof(SearchInfo_SurveillanceTask));
            }
            catch
            {
            }
            return msg;
        }

    }

    /// <summary>
    /// 布控任务
    /// </summary>
    class SurveillanceTask
    {
        public int ID { get; set; }
        public string Name { get; set; }//
        public int DatasetID { get; set; }
        public int DeviceID { get; set; }
        public string Type { get; set; }//布控类型
        public string Remark { get; set; }//备注
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public static SurveillanceTask CreateInstanceFromJson(string json)
        {
            SurveillanceTask msg = null;
            try
            {
                msg = (SurveillanceTask)JsonConvert.DeserializeObject(json, typeof(SurveillanceTask));
            }
            catch
            {

            }
            return msg;
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }


        public static SurveillanceTask CreateInstanceFromDataAngineModel(surveillance_task st)
        {
            SurveillanceTask s = new SurveillanceTask();
            s.DatasetID = st.person_dataset_id;
            s.DeviceID = st.device_id;
            s.ID = st.id;
            s.Name = st.name;
            s.Remark = st.remark;
            s.Type = st.type;
            s.StartTime = st.start_time.ToString();
            s.EndTime = st.end_time.ToString();
            return s;
        }

        public static SurveillanceTask[] CreateInstanceFromDataAngineModel(surveillance_task[] sts)
        {
            SurveillanceTask[] ss = new SurveillanceTask[sts.Length];
            for (int i = 0; i < sts.Length; i++)
            {
                SurveillanceTask s = new SurveillanceTask();
                s.DatasetID = sts[i].person_dataset_id;
                s.DeviceID = sts[i].device_id;
                s.ID = sts[i].id;
                s.Name = sts[i].name;
                s.Remark = sts[i].remark;
                s.Type = sts[i].type;
                s.StartTime = sts[i].start_time.ToString();
                s.EndTime = sts[i].end_time.ToString();
                ss[i] = s;
            }
            return ss;
        }
        public surveillance_task ToDataAngineModel()
        {
            surveillance_task s = new surveillance_task();
            s.person_dataset_id = this.DatasetID;
            s.device_id = this.DeviceID;
            s.id = this.ID;
            s.name = this.Name;
            s.remark = this.Remark;
            s.type = this.Type;
            s.start_time = Convert.ToDateTime(this.StartTime);
            s.end_time = Convert.ToDateTime(this.EndTime);
            return s;
        }

    }

    //级联类
    class SurveillanceTask_Cascade
    {
        public int ID { get; set; }
        public string Name { get; set; }//
        public int DatasetID { get; set; }
        public string DatasetName { get; set; }
        public int DeviceID { get; set; }
        public string DeviceName { get; set; }
        public string Type { get; set; }//布控类型
        public string Type_Name { get; set; }//布控类型
        public string Remark { get; set; }//备注
        public string StartTime { get; set; }
        public string EndTime { get; set; }

       
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static SurveillanceTask_Cascade[] CreateInstanceFromDataAngineDataSet(DataSet ds)
        {
            if (0 == ds.Tables.Count)
            {
                return null;
            }

            DataTable dt = ds.Tables[0];
            int StCount = dt.Rows.Count;
            SurveillanceTask_Cascade[] sts = new SurveillanceTask_Cascade[StCount];

            for (int i = 0; i < StCount; ++i)
            {
                SurveillanceTask_Cascade st = new SurveillanceTask_Cascade();
                st.ID = Convert.ToInt32(dt.Rows[i]["id"]);
                st.Name = dt.Rows[i]["name"].ToString();
                st.DatasetID = Convert.ToInt32(dt.Rows[i]["person_dataset_id"]);
                st.DatasetName = dt.Rows[i]["person_dataset_name"].ToString();
                st.DeviceID = Convert.ToInt32(dt.Rows[i]["device_id"]);
                st.DeviceName = dt.Rows[i]["device_name"].ToString();
                st.Type = dt.Rows[i]["type"].ToString();
                st.Type_Name = dt.Rows[i]["type_name"].ToString();
                st.Remark = dt.Rows[i]["remark"].ToString();
                st.StartTime = dt.Rows[i]["start_time"].ToString();
                st.EndTime = dt.Rows[i]["end_time"].ToString();
                sts[i] = st;
            }
            return sts;
        }


        public static SurveillanceTask_Cascade CreateInstanceFromDataAngineModel(DataSet ds)
        {
            if (1 != ds.Tables.Count)
            {
                return null;
            }

            DataTable dt = ds.Tables[0];
            SurveillanceTask_Cascade st = new SurveillanceTask_Cascade();
            st.ID = Convert.ToInt32(dt.Rows[0]["id"]);
            st.Name = dt.Rows[0]["name"].ToString();
            st.DatasetID = Convert.ToInt32(dt.Rows[0]["person_dataset_id"]);
            st.DatasetName = dt.Rows[0]["person_dataset_name"].ToString();
            st.DeviceID = Convert.ToInt32(dt.Rows[0]["device_id"]);
            st.DeviceName = dt.Rows[0]["device_name"].ToString();
            st.Type = dt.Rows[0]["type"].ToString();
            st.Type_Name = dt.Rows[0]["type_name"].ToString();
            st.Remark = dt.Rows[0]["remark"].ToString();
            st.StartTime = dt.Rows[0]["start_time"].ToString();
            st.EndTime = dt.Rows[0]["end_time"].ToString();
            return st;
        }
    }
}
