using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using DataAngineSet.Model;
using System.Data;
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
        public DateTime? CreateTime { get; set; }
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

    class SearchInfo_PersonDateSet
    {
        public int StartIndex { get; set; }
        public int PageSize { get; set; }

        public static SearchInfo_PersonDateSet CreateInstanceFromJSON(string json)
        {
            SearchInfo_PersonDateSet msg = null;
            try
            {
                msg = (SearchInfo_PersonDateSet)JsonConvert.DeserializeObject(json, typeof(SearchInfo_PersonDateSet));
            }
            catch
            {
            }
            return msg;
        }

    }

    class RegisterInfo
    {
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

    class RegisterSingleInfo
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string CardId { get; set; }

        public static RegisterSingleInfo CreateInstanceFromJSON(string json)
        {
            RegisterSingleInfo msg = null;
            try
            {
                msg = (RegisterSingleInfo)JsonConvert.DeserializeObject(json, typeof(RegisterSingleInfo));
            }
            catch
            {
            }
            return msg;
        }
    }

    class ViewInfo
    {
        public int StartIndex { get; set; }
        public int PageSize { get; set; }

        public static ViewInfo CreateInstanceFromJSON(string json)
        {
            ViewInfo msg = null;
            try
            {
                msg = (ViewInfo)JsonConvert.DeserializeObject(json, typeof(ViewInfo));
            }
            catch
            {
            }
            return msg;
        }
    }

    class PersonData
    {
        public int id { get; set; }
        public int person_dataset_id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string card_id { get; set; }
        public string image_id { get; set; }
        public string face_image_path { get; set; }


        public static PersonData CreateInstanceFromJSON(string json)
        {
            PersonData msg = null;
            try
            {
                msg = (PersonData)JsonConvert.DeserializeObject(json, typeof(PersonData));
            }
            catch
            {
            }
            return msg;
        }

        public static PersonData[] CreateInstanceFromDataAngineDataSet(DataSet ds)
        {
            if (0 == ds.Tables.Count)
            {
                return null;
            }

            DataTable dt = ds.Tables[0];
            int UserCount = dt.Rows.Count;
            PersonData[] users = new PersonData[UserCount];

            for (int i = 0; i < UserCount; ++i)
            {
                PersonData userdata = new PersonData();
                userdata.id = Convert.ToInt32(dt.Rows[i]["id"]);
                userdata.person_dataset_id = Convert.ToInt32(dt.Rows[i]["person_dataset_id"]);
                userdata.name = dt.Rows[i]["name"].ToString();
                userdata.gender = dt.Rows[i]["gender"].ToString();
                userdata.card_id = dt.Rows[i]["card_id"].ToString();
                userdata.image_id = dt.Rows[i]["image_id"].ToString();
                userdata.face_image_path = dt.Rows[i]["face_image_path"].ToString();
                users[i] = userdata;
            }
            return users;
        }
    }

    class PersonDataSet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public string CreateTime { get; set; }
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
            d.ID = dt.id;
            d.Name = dt.name;     
            d.Source = dt.source;
            if (dt.create_time != null)
                d.CreateTime = dt.create_time.ToString();
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
                d.ID = dts[i].id;
                d.Name = dts[i].name;
                d.Source = dts[i].source;
                if (dts[i].create_time != null)
                    d.CreateTime = dts[i].create_time.ToString();         
                d.Type = dts[i].type;
                d.Remark = dts[i].remark;
                ds[i] = d;
            }
            return ds;
        }
        public person_dataset ToDataAngineModel()
        {
            person_dataset d = new person_dataset();
            d.id = this.ID;
            d.name = this.Name;
            d.source = this.Source;
            d.create_time = Convert.ToDateTime(this.CreateTime);
            d.type = this.Type;
            d.remark = this.Remark;
            return d;
        }
    }
}
