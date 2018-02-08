using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRSServerHttp.Model;
using System.IO;
using Newtonsoft.Json;
using FRSServerHttp.Server;
using DataAngineSet.BLL;

namespace FRSServerHttp.Service
{
    /// <summary>
    /// 以图搜图
    /// </summary>
    class RecordingService : BaseService
    {

        /// <summary>
        /// 访问当前service的URL
        /// </summary>
        hitalert bll = new hitalert();
        person_dataset person_datasetbll = new person_dataset();
        public static string Domain
        {
            get
            {
                return "recording";
            }
        }
        public override void OnPost(HttpRequest request, HttpResponse response)
        {
            if (request.RestConvention != null)//根据ID获得数据库
            {
                Log.Debug(string.Format("返回数据库{0}的信息", request.RestConvention));
                int id = -1;
                try
                {
                    id = Convert.ToInt32(request.RestConvention);
                }
                catch
                {
                }
               
                SearchInfo searchinfo = SearchInfo.CreateInstanceFromJSON(request.PostParams);
                if (searchinfo != null)
                {
                    DataAngineSet.Model.person_dataset ds = new DataAngineSet.Model.person_dataset();
                    ds = person_datasetbll.GetModel(id);
                    int num = bll.GetListByTime(searchinfo.StartTime, searchinfo.EndTime, ds.id.ToString()).Tables[0].Rows.Count;
                    HitAlertData[] ha = HitAlertData.CreateInstanceFromDataAngineDataSet(bll.GetListByTime(searchinfo.StartTime, searchinfo.EndTime, searchinfo.StartIndex, searchinfo.PageSize, ds.id.ToString()));
                    response.SetContent("RecordNum:" + num + "," + JsonConvert.SerializeObject(ha));
                }
                //if(request.GetParams!=null)
                //{
                //    DateTime starttime=new DateTime(); 
                //    DateTime endtime=new DateTime();
                //    int startindex = 0;
                //    int pagesize = 30;
                //    starttime = Convert.ToDateTime(request.GetParams["starttime"]);
                //    endtime = Convert.ToDateTime(request.GetParams["endtime"]);
                //    startindex = Convert.ToInt32(request.GetParams["startindex"]);
                //    pagesize = Convert.ToInt32(request.GetParams["pagesize"]);
                //    HitAlertData[] ha = HitAlertData.CreateInstanceFromDataAngineDataSet(bll.GetListByTime(starttime, endtime, startindex, pagesize, library));
                //     response.SetContent(JsonConvert.SerializeObject(ha));
                   
                //}          
            }
            else
            {
                Log.Debug("轨迹查询");

                Trajectory_Search trajectory_search = Trajectory_Search.CreateInstanceFromJSON(request.PostParams);
                if (trajectory_search != null)
                {
                    HitAlertData_Trajectory_Search[] ha = HitAlertData_Trajectory_Search.CreateInstanceFromDataAngineDataSet(bll.GetListById(trajectory_search.UserId, trajectory_search.StartTime, trajectory_search.EndTime));
                    response.SetContent(JsonConvert.SerializeObject(ha));
                }
            }
            response.Send();
        }
        /// <summary>
        /// Get时调用
        /// </summary>
        public override void OnGet(HttpRequest request, HttpResponse response)
        {         

        }
       
    }
    
}
