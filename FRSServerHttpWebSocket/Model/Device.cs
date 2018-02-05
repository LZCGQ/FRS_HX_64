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

    class SearchInfo_Device
    {
        public int StartIndex { get; set; }
        public int PageSize { get; set; }

        public static SearchInfo_Device CreateInstanceFromJSON(string json)
        {
            SearchInfo_Device msg = null;
            try
            {
                msg = (SearchInfo_Device)JsonConvert.DeserializeObject(json, typeof(SearchInfo_Device));
            }
            catch
            {
            }
            return msg;
        }

    }

    /// <summary>
    /// 摄像地址
    /// </summary>
    class Device
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Video_Address { get; set; }//视频地址
        public string DepartmentID { get; set; }//公安ID
        public double? Longitude { get; set; }//经度
        public double? Latitude { get; set; }//纬度
        public string LocationType { get; set; }//区域类型，汽车站，公交站，酒吧
        public string Type { get; set; }//类型
        public string Remark { get; set; }//备注

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Device CreateInstanceFromJSON(string json)
        {
            Device msg = null;
            try
            {
                msg = (Device)JsonConvert.DeserializeObject(json, typeof(Device));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace + e.Message);
            }
            return msg;
        }
        public device ToDataAngineModel()
        {
            device d = new device();
            d.id = this.ID;
            d.latitude = this.Latitude;
            d.location_type = this.LocationType;
            d.longitude = this.Longitude;
            d.name = this.Name;
            d.remark = this.Remark;
            d.video_address = this.Video_Address;
            d.departmentment_id = this.DepartmentID;
            d.type = this.Type;
            return d;

        }

        public static Device CreateInstanceFromDataAngineModel(device d)
        {
            if (null == d) return null;
            Device de = new Device();
            de.ID = d.id;
            de.Latitude = d.latitude;
            de.LocationType = d.location_type;
            de.Longitude = d.longitude;
            de.Name = d.name;
            de.Remark = d.remark;
            de.Video_Address = d.video_address;
            de.DepartmentID = d.departmentment_id;
            de.Type = d.type;
            return de;

        }

        public static Device[] CreateInstanceFromDataAngineModel(device[] ds)
        {
            if (null == ds) return null;
            Device[] des = new Device[ds.Length];
            for (int i = 0; i < ds.Length; i++)
            {


                Device de = new Device();
                de.ID = ds[i].id;
                de.Latitude = ds[i].latitude;
                de.LocationType = ds[i].location_type;
                de.Longitude = ds[i].longitude;
                de.Name = ds[i].name;
                de.Remark = ds[i].remark;
                de.Video_Address = ds[i].video_address;
                de.DepartmentID = ds[i].departmentment_id;
                de.Type = ds[i].type;
                des[i] = de;
            }
            return des;

        }
    }
    //class DeviceData
    //{
    //    public Device[] Devices { get; set; }
    //    public string SelectedDeviceName
    //    {
    //        get
    //        {
    //            return selectedDeviceName;
    //        }
    //    }

    //    string selectedDeviceName;

    //    public DeviceData()
    //    {
    //        try
    //        {
    //            selectedDeviceName = ConfigurationManager.AppSettings["selectedDeviceName"];
    //        }
    //        catch
    //        {
    //            selectedDeviceName = "";
    //        }
    //    }
    //    /// <summary>
    //    /// 保存设置
    //    /// </summary>
    //    /// <param name="setting"></param>
    //    /// <returns></returns>
    //    public static int SaveSelectedDeviceName(string selectedDeviceName)
    //    {
    //        try
    //        {
    //            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

    //            //写入元素的Value

    //            config.AppSettings.Settings["SelectedDeviceName"].Value = selectedDeviceName;

    //            //一定要记得保存，写不带参数的config.Save()也可以
    //            config.Save(ConfigurationSaveMode.Modified);
    //        }
    //        catch
    //        {
    //            return ReturnCode.FAIL;
    //        }
    //        return ReturnCode.SUCCESS;
    //    }

    //    public string ToJson()
    //    {
    //        return JsonConvert.SerializeObject(this);
    //    }
    //}
}
