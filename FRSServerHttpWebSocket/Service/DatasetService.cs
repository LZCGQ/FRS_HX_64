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
    class DatasetService : BaseService
    {
        person_dataset bll = new person_dataset();
        public static string Domain
        {
            get
            {
                return "dataset";
            }
        }

        public override void OnGet(HttpRequest request, HttpResponse response)
        {
            if (request.RestConvention != null)//根据ID获得数据库
            {

               Log.Debug(string.Format("返回ID{0}的数据库信息", request.RestConvention));
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
            else if (request.Domain != null)//获得所有数据库
            {
                Log.Debug(string.Format("返回所哟数据库信息", request.RestConvention));
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
                PersonDataSet da = PersonDataSet.CreateInstanceFromJSON(request.PostParams);

                if (null != da)
                {
                    //添加到数据库
                    Console.WriteLine("添加数据库信息");
                    status = bll.Add(da.ToDataAngineModel());

                }
            }
            else
            {
                if (request.Operation == "update")//更新
                {
                    Console.WriteLine("更新数据库信息");
                    PersonDataSet da = PersonDataSet.CreateInstanceFromJSON(request.PostParams);
                    if (null != da)
                    {
                        status = bll.Update(da.ToDataAngineModel());
                    }
                }
                else if (request.Operation == "delete")//删除
                {
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
            }
            response.SetContent(status.ToString());
            response.Send();

        }
    }
}
