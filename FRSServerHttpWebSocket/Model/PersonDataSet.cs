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
    /// 添加人员库时所用的结构
    /// </summary>
    class AddInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public DateTime CreateTime { get; set; }
        public string Remark { get; set; }

        public static AddInfo CreateInstanceFromJSON(string json)
        {
            AddInfo msg = null;
            try
            {
                msg = (AddInfo)JsonConvert.DeserializeObject(json, typeof(AddInfo));
            }
            catch
            {
            }
            return msg;
        }

    }

    class RegisterInfo
    {
        public int DatasetId { get; set; }
        public string Path { get; set; }

        public static RegisterInfo CreateInstanceFromJSON(string json)
        {
            RegisterInfo msg = null;
            try
            {
                msg = (RegisterInfo)JsonConvert.DeserializeObject(json, typeof(RegisterInfo));
            }
            catch
            {
            }
            return msg;
        }
    }

    class PersonDataSet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public DateTime CreateTime { get; set; }
        public string Type { get; set; }
        public string Remark { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static PersonDataSet CreateInstanceFromJSON(string json)
        {
            PersonDataSet msg = null;
            try
            {
                msg = (PersonDataSet)JsonConvert.DeserializeObject(json, typeof(PersonDataSet));
            }
            catch
            {

            }
            return msg;
        }


        public static PersonDataSet CreateInstanceFromDataAngineModel(person_dataset dt)
        {
            if (null == dt)
            {
                return null;
            }
            PersonDataSet d = new PersonDataSet();
            d.Name = dt.name;     
            d.Source = dt.source;
            d.CreateTime = (DateTime)dt.create_time;
            d.Type = dt.type;
            d.Remark = dt.remark;
            return d;
        }

        public static PersonDataSet[] CreateInstanceFromDataAngineModel(person_dataset[] dts)
        {
            if (null == dts)
            {
                return null;
            }
            PersonDataSet[] ds = new PersonDataSet[dts.Length];
            for (int i = 0; i < dts.Length; i++)
            {
                PersonDataSet d = new PersonDataSet();
                d.Name = dts[i].name;
                d.Source = dts[i].source;
                d.CreateTime = (DateTime)dts[i].create_time;
                d.Type = dts[i].type;
                d.Remark = dts[i].remark;
                ds[i] = d;
            }
            return ds;
        }
        public person_dataset ToDataAngineModel()
        {
            person_dataset d = new person_dataset();
            d.name = this.Name;
            d.source = this.Source;
            d.create_time = (DateTime)this.CreateTime;
            d.type = this.Type;
            d.remark = this.Remark;
            return d;
        }
    }
}
