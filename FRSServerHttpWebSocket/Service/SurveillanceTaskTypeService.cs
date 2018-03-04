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
    class SurveillanceTaskTypeService : BaseService
    {
        /// <summary>
        /// 数据操作类
        /// </summary>
        surveillance_task_type bll = new surveillance_task_type();

        /// <summary>
        /// 访问当前service的URL
        /// </summary>
        public static string Domain
        {
            get
            {
                return "surveillance-task-type";
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
                List<DataAngineSet.Model.surveillance_task_type> surveillance_task_types = bll.DataTableToList(bll.GetAllList().Tables[0]);
                response.SetContent(JsonConvert.SerializeObject(SurveillanceTaskType.CreateInstanceFromDataAngineModel(surveillance_task_types.ToArray())));
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
