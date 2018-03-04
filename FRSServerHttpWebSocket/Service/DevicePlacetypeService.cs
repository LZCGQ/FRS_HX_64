using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FRSServerHttp.Model;
using FRSServerHttp.Server;
using Newtonsoft.Json;
using DataAngineSet.BLL;
namespace FRSServerHttp.Service
{
    class DevicePlacetypeService : BaseService
    {
        /// <summary>
        /// 数据操作类
        /// </summary>
        device_placetype bll = new device_placetype();

        /// <summary>
        /// 访问当前service的URL
        /// </summary>
        public static string Domain
        {
            get
            {
                return "device-placetype";
            }
        }
        public override void OnGet(HttpRequest request, HttpResponse response)
        {
            if (request.RestConvention != null)
            {
                Log.Debug(string.Format("返回ID:{0}布控任务类型信息", request.RestConvention));
            }
            else if (request.Domain != string.Empty)
            {
                Log.Debug(string.Format("返回所有布控任务类型信息"));
                List<DataAngineSet.Model.device_placetype> device_placetypes = bll.DataTableToList(bll.GetAllList().Tables[0]);
                response.SetContent(JsonConvert.SerializeObject(DevicePlacetype.CreateInstanceFromDataAngineModel(device_placetypes.ToArray())));
            }
            response.Send();

        }
        /// <summary>
        /// Post时调用
        /// </summary>
        public override void OnPost(HttpRequest request, HttpResponse response)
        {

        }
    }
}
