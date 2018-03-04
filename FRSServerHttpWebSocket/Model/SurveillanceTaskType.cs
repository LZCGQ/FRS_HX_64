using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using DataAngineSet.Model;
namespace FRSServerHttp.Model
{

    /// <summary>
    /// 摄像地址
    /// </summary>
    class SurveillanceTaskType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static SurveillanceTaskType CreateInstanceFromJSON(string json)
        {
            SurveillanceTaskType msg = null;
            try
            {
                msg = (SurveillanceTaskType)JsonConvert.DeserializeObject(json, typeof(SurveillanceTaskType));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace + e.Message);
            }
            return msg;
        }
        public surveillance_task_type ToDataAngineModel()
        {
            surveillance_task_type d = new surveillance_task_type();
            d.id = this.ID;
            d.name = this.Name;
            return d;

        }

        public static SurveillanceTaskType CreateInstanceFromDataAngineModel(surveillance_task_type d)
        {
            if (null == d) return null;
            SurveillanceTaskType de = new SurveillanceTaskType();
            de.ID = d.id;
            de.Name = d.name;
            return de;

        }

        public static SurveillanceTaskType[] CreateInstanceFromDataAngineModel(surveillance_task_type[] ds)
        {
            if (null == ds) return null;
            SurveillanceTaskType[] des = new SurveillanceTaskType[ds.Length];
            for (int i = 0; i < ds.Length; i++)
            {
                SurveillanceTaskType de = new SurveillanceTaskType();
                de.ID = ds[i].id;
                de.Name = ds[i].name;
                des[i] = de;
            }
            return des;

        }
    }

}