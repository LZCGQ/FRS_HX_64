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
    class DevicePlacetype
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static DevicePlacetype CreateInstanceFromJSON(string json)
        {
            DevicePlacetype msg = null;
            try
            {
                msg = (DevicePlacetype)JsonConvert.DeserializeObject(json, typeof(DevicePlacetype));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace + e.Message);
            }
            return msg;
        }
        public device_placetype ToDataAngineModel()
        {
            device_placetype d = new device_placetype();
            d.id = this.ID;
            d.name = this.Name;
            return d;

        }

        public static DevicePlacetype CreateInstanceFromDataAngineModel(device_placetype d)
        {
            if (null == d) return null;
            DevicePlacetype de = new DevicePlacetype();
            de.ID = d.id;
            de.Name = d.name;
            return de;

        }

        public static DevicePlacetype[] CreateInstanceFromDataAngineModel(device_placetype[] ds)
        {
            if (null == ds) return null;
            DevicePlacetype[] des = new DevicePlacetype[ds.Length];
            for (int i = 0; i < ds.Length; i++)
            {
                DevicePlacetype de = new DevicePlacetype();
                de.ID = ds[i].id;
                de.Name = ds[i].name;
                des[i] = de;
            }
            return des;

        }
    }

}