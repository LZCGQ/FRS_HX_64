using DataAngineSet.BLL;
using FRSServerHttp.Model;
using FRSServerHttp.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRSServerHttp.Service
{
    /// <summary>
    /// 比对两张图片
    /// </summary>
    class VerifyingService : BaseService
    {
        person_dataset bll = new person_dataset();
        public static string Domain
        {
            get
            {
                return "verify";
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
            if (request.Operation == "verify")//添加一条数据
            {
                Log.Debug("比较图片");

                //OneVsOne
                if (request.RestConvention == "0")
                {
                    //http://127.0.0.1:8080/v1/person-database/0/verify
                    VerifyOneVsOne verify = VerifyOneVsOne.CreateInstanceFromJSON(request.PostParams);
                    if (verify != null)
                    {
                        Bitmap Bitmapsrc = Base64ToImage(verify.PicSrc);

                        Bitmap Bitmapdst = Base64ToImage(verify.PicDst);
                        //Bitmapsrc.Save("Bitmapsrc.jpg");
                        //Bitmapsrc.Save("Bitmapdst.jpg");
                        double score = fa.Compare(Bitmapsrc, Bitmapdst);

                        response.SetContent(JsonConvert.SerializeObject(score));
                        //response.SetContent("0.8");
                    }

                }
                else
                {
                    VerifyOneVsN verify = VerifyOneVsN.CreateInstanceFromJSON(request.PostParams);
                    if (verify != null)
                    {
                        int DatasetId = Convert.ToInt32(request.RestConvention);
                        DataAngineSet.Model.person_dataset ds = new DataAngineSet.Model.person_dataset();
                        ds = bll.GetModel(DatasetId);

                        Bitmap Bitmapsrc = Base64ToImage(verify.PicSrc);
                        fa.LoadData(DatasetId);
                        FRS.HitAlert[] hits = fa.Search(Bitmapsrc);
                        string msg = JsonConvert.SerializeObject(Model.HitAlert.CreateInstanceFromFRSHitAlert(hits));
                        response.SetContent(msg);
                    }
                }

            }
            response.Send();

        }

        public static Bitmap Base64ToImage(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            return BytesToBitmap(bytes);
        }

        public static Bitmap BytesToBitmap(byte[] Bytes)
        {
            MemoryStream stream = null;
            try
            {
                stream = new MemoryStream(Bytes);
                return new Bitmap((Image)new Bitmap(stream));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            finally
            {
                stream.Close();
            }
        }   
  
    }
}
