﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FRSServerHttp.Model;
using Newtonsoft.Json;
using FRSServerHttp.Server;
using DataAngineSet.BLL;
namespace FRSServerHttp.Service
{
    class SurveillanceTaskService : BaseService
    {

        surveillance_task bll = new surveillance_task();
        /// <summary>
        /// 访问当前service的URL
        /// </summary>
        public static string Domain
        {
            get
            {
                return "surveillance-task";
            }
        }
        /// <summary>
        /// Get时调用
        /// </summary>
        public override void OnGet(HttpRequest request, HttpResponse response)
        {

            if (request.RestConvention != null)//根据ID获布控的任务
            {
                Console.WriteLine("获取一条布控任务");
                //构造响应报文

                //SurveillanceTask t = new SurveillanceTask();
                //t.ID = 1;
                //t.Name = "布控1";
                //t.DatasetID = 1;
                //t.DeviceID = 2;


                int id = -1;
                try
                {
                    id = Convert.ToInt32(request.RestConvention);
                }
                catch
                {

                }
                //SurveillanceTask da = SurveillanceTask.CreateInstanceFromDataAngineModel(bll.GetModel(id));
                SurveillanceTask_Cascade da = SurveillanceTask_Cascade.CreateInstanceFromDataAngineModel(bll.GetModel_Cascade(id));
                if (null != da)
                {
                    response.SetContent(da.ToJson());
                }

                response.Send();

            }
            else if (request.Domain != null)
            {//获得所有布控的任务


                //构造响应报文

                //List<DataAngineSet.Model.surveillance_task> datasets = bll.DataTableToList(bll.GetAllList().Tables[0]);
                SurveillanceTask_Cascade[] des = SurveillanceTask_Cascade.CreateInstanceFromDataAngineDataSet(bll.GetAllList_Cascade());
                response.SetContent(JsonConvert.SerializeObject(des));
                response.Send();

            }

        }
        /// <summary>
        /// Post时调用
        /// </summary>
        public override void OnPost(HttpRequest request, HttpResponse response)
        {
            bool status = false;

            if (request.Operation == null)//添加一条数据
            {
                Log.Debug("添加布控任务");
                SurveillanceTask task = SurveillanceTask.CreateInstanceFromJson(request.PostParams);
                if (null != task)
                {

                    //添加到数据库
                    status = bll.Add(task.ToDataAngineModel());
                }
            }
            else
            {
                if (request.Operation == "update")//更新
                {
                    Log.Debug("更新布控任务");
                    SurveillanceTask task = SurveillanceTask.CreateInstanceFromJson(request.PostParams);
                    if (null != task)
                    {
                        //添加到数据库
                        status = bll.Update(task.ToDataAngineModel());
                    }
                }
                else if (request.Operation == "delete")//删除
                {
                    Log.Debug("删除布控任务");
                    int id = -1;
                    try
                    {
                        id = Convert.ToInt32(request.RestConvention);
                    }
                    catch
                    {

                    }
                    status = bll.Delete(id);
                }
                else if (request.Operation == "list")
                {
                    Log.Debug(string.Format("返回所有库信息"));
                    SearchInfo_SurveillanceTask searchinfo = SearchInfo_SurveillanceTask.CreateInstanceFromJSON(request.PostParams);
                    if (searchinfo != null)
                    {
                        //Log.Debug("xxxx");
                        //int num = bll.DataTableToList(bll.GetAllList().Tables[0]).Count;
                        //List<DataAngineSet.Model.surveillance_task> datasets = bll.DataTableToList(bll.GetAllList(searchinfo.StartIndex, searchinfo.PageSize, "").Tables[0]);
                        SurveillanceTask_Cascade[] des = SurveillanceTask_Cascade.CreateInstanceFromDataAngineDataSet(bll.GetAllList_Cascade(searchinfo.StartIndex, searchinfo.PageSize, ""));
                        response.SetContent(JsonConvert.SerializeObject(des));
                    }
                }
            }
            response.Send();
        }
    }
}
