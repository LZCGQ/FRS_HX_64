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


    class PersonService : BaseService
    {
        person_dataset bll = new person_dataset();
        person personbll = new person();
        public static string Domain
        {
            get
            {
                return "person";
            }
        }


        public override void OnGet(HttpRequest request, HttpResponse response)
        {
        }
        /// <summary>
        /// Post时调用
        /// </summary>
        public override void OnPost(HttpRequest request, HttpResponse response)
        {

            bool status = false;

            if (request.Operation == "update")//更新
            {
                Log.Debug("更新一个人员库");
                RegisterInfo registerInfo = RegisterInfo.CreateInstanceFromJSON(request.PostParams);
                if (registerInfo != null)
                {
                    int DatasetId = Convert.ToInt32(request.RestConvention);
                    //初始化                   
                    InitFRS();
                    int num = fa.RegisterInBulk1(registerInfo.Path, DatasetId);
                    if (num > 0)
                        status = true;
                    Log.Debug(string.Format("共注册{0}人", num));
                }
                response.SetContent(status.ToString());
            }

            else if (request.Operation == "add")//单人添加
            {
                Log.Debug("添加一个人员");
                int id = -1;
                try
                {
                    id = Convert.ToInt32(request.RestConvention);
                }
                catch
                {
                }

                UserInfo usr = new UserInfo();
                RegisterSingleInfo registersingleinfo = RegisterSingleInfo.CreateInstanceFromJSON(request.PostParams);
                usr.personDatasetId = id;
                usr.name = registersingleinfo.Name;
                usr.gender = registersingleinfo.Gender;
                usr.cardId = registersingleinfo.CardId;             

                
                //初始化                   
                InitFRS();
                int statusnum = fa.Register(registersingleinfo.Path, usr);
                if (statusnum == 0)
                {
                    status = true;
                    Log.Debug(string.Format("共注册成功"));
                }
                
                response.SetContent(status.ToString());
            }
            else if (request.Operation == "delete")//删除
            {
                Log.Debug("删除一个人员");

                int id = -1;
                try
                {
                    id = Convert.ToInt32(request.RestConvention);
                }
                catch
                {
                }
                status = personbll.Delete(id);
                //删除设备
                response.SetContent(status.ToString());
            }
            else if (request.Operation == "view")//查看
            {
                Log.Debug("查看一个人员库");
                ViewInfo viewinfo = ViewInfo.CreateInstanceFromJSON(request.PostParams);
                if (viewinfo != null)
                {
                    
                    int DatasetId = Convert.ToInt32(request.RestConvention);
                    int num = personbll.DataTableToList(personbll.GetList_Library(DatasetId.ToString()).Tables[0]).Count;
                    PersonData[] users = PersonData.CreateInstanceFromDataAngineDataSet(personbll.GetList(viewinfo.StartIndex, viewinfo.PageSize, DatasetId.ToString()));
                    response.SetContent("PersonNum:" + num + "," + JsonConvert.SerializeObject(users));
                }
            }

            response.Send();
        }
    }
}
