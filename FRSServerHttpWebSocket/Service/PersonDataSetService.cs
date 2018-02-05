using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FRSServerHttp.Server;
using DataAngineSet.BLL;
using FRSServerHttp.Model;
using Newtonsoft.Json;
using FRS;
namespace FRSServerHttp.Service
{


    class PersonDataSetService : BaseService
    {
        person_dataset bll = new person_dataset();
        person personbll = new person();
        public static string Domain
        {
            get
            {
                return "person-dataset";
            }
        }


        public override void OnGet(HttpRequest request, HttpResponse response)
        {
            if (request.RestConvention != null)
            {
                Log.Debug(string.Format("返回ID:{0}人员库", request.RestConvention));

                int id = -1;
                try
                {
                    id = Convert.ToInt32(request.RestConvention);
                }
                catch
                {
                }
                PersonDataSet da = PersonDataSet.CreateInstanceFromDataAngineModel(bll.GetModel(id));
                if (null != da)
                {
                    response.SetContent(da.ToJson());
                }
            }
            else if (request.Domain != string.Empty)
            {
                Log.Debug(string.Format("返回所有库信息"));
                List<DataAngineSet.Model.person_dataset> datasets = bll.DataTableToList(bll.GetAllList().Tables[0]);
                response.SetContent(JsonConvert.SerializeObject(PersonDataSet.CreateInstanceFromDataAngineModel(datasets.ToArray())));
            }
            response.Send();

        }
        /// <summary>
        /// Post时调用
        /// </summary>
        public override void OnPost(HttpRequest request, HttpResponse response)
        {

            bool status = false;        
            if (request.Operation == null)//添加一条数据
            {
                Log.Debug("添加一个人员库");

                AddInfo addinfo = AddInfo.CreateInstanceFromJSON(request.PostParams);
                if (addinfo != null)
                {
                    DataAngineSet.Model.person_dataset ds = new DataAngineSet.Model.person_dataset();
                    ds.name = addinfo.Name;
                    ds.type = addinfo.Type;
                    ds.source = addinfo.Source;
                    ds.create_time = addinfo.CreateTime;
                    ds.remark = addinfo.Remark;
                    status = bll.Add(ds);
                    if (status)
                    {
                        Log.Debug(string.Format("创建人员库成功"));
                        //初始化
                        //InitFRS();
                        //int num = fa.RegisterInBulk1(addinfo.Path, ds.datasetname);
                        //Log.Debug(string.Format("共注册{0}人", num));
                    }
                }
                response.SetContent(status.ToString());

            }
            else
            {
                if (request.Operation == "update")//更新
                {
                    PersonDataSet persondataset = PersonDataSet.CreateInstanceFromJSON(request.PostParams);
                    if (null != persondataset)
                    {
                        status = bll.Update(persondataset.ToDataAngineModel());
                    }
                    response.SetContent(status.ToString());
                }
                else if (request.Operation == "delete")//删除
                {
                    Log.Debug("删除更新一个人员库");

                    int id = -1;
                    try
                    {
                        id = Convert.ToInt32(request.RestConvention);
                    }
                    catch
                    {

                    }
                    status = bll.Delete(id);
                    //删除设备
                    response.SetContent(status.ToString());
                }
                else if (request.Operation == "list")
                {
                    Log.Debug(string.Format("返回所有库信息"));
                    SearchInfo_PersonDateSet searchinfo = SearchInfo_PersonDateSet.CreateInstanceFromJSON(request.PostParams);
                    if (searchinfo != null)
                    {
                        List<DataAngineSet.Model.person_dataset> datasets = bll.DataTableToList(bll.GetAllList(searchinfo.StartIndex, searchinfo.PageSize, "").Tables[0]);
                        response.SetContent(JsonConvert.SerializeObject(PersonDataSet.CreateInstanceFromDataAngineModel(datasets.ToArray())));
                    }
                }
            }
            response.Send();
        }
    }
}
