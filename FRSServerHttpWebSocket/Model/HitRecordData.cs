using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FRS;
using System.Data;
using Newtonsoft.Json;

namespace FRSServerHttp.Model
{

    
    class HitRecordData
    {
        public int id { get; set; }
        public string FaceQueryImagePath { get; set; }
        public float Threshold { get; set; }
        public string OccurTime { get; set; }//yyyy-MM-dd HH:mm:ss       
        public int task_id { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static HitAlert[] CreateInstanceFromFRSHitAlert(FRS.HitAlert[] result)
        {
            if (null == result) return null;
            HitAlert[] hits = new HitAlert[result.Length];
            for (int i = 0; i < result.Length; i++)
            {
                hits[i] = new HitAlert(result[i]);
            }
            return hits;
        }

        public static HitRecordData[] CreateInstanceFromDataAngineDataSet(DataSet ds)
        {
            if (0 == ds.Tables.Count)
            {
                return null;
            }

            DataTable dt = ds.Tables[0];
            int HitCount = dt.Rows.Count;
            HitRecordData[] hits = new HitRecordData[HitCount];

            for (int i = 0; i < HitCount; ++i)
            {
                HitRecordData hitalertdata = new HitRecordData();
                hitalertdata.id = Convert.ToInt32(dt.Rows[i]["id"]);
                hitalertdata.FaceQueryImagePath = dt.Rows[i]["face_query_image_path"].ToString();
                hitalertdata.Threshold = Convert.ToSingle(dt.Rows[i]["Threshold"]);
                hitalertdata.OccurTime = dt.Rows[i]["occur_time"].ToString();
                hitalertdata.task_id = Convert.ToInt32(dt.Rows[i]["task_id"]);
                hits[i] = hitalertdata;
            }
            return hits;
        }


    }

}
