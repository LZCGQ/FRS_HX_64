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
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Net;

namespace FRSServerHttp.Service
{
    /// <summary>
    /// 以图搜图
    /// </summary>
    class RecordingByImgService : BaseService
    {

        /// <summary>
        /// 访问当前service的URL
        /// </summary>
        //hitalert bll = new hitalert();
        //person_dataset person_datasetbll = new person_dataset();
        public static string Domain
        {
            get
            {
                return "recordingbyimg";
            }
        }
        public override void OnPost(HttpRequest request, HttpResponse response)
        {
            hitalert bll = new hitalert();
            person_dataset person_datasetbll = new person_dataset();
            if (request.RestConvention != null)//根据ID获得数据库
            {
                Log.Debug(string.Format("请求地址无效", request.RestConvention));
                //int id = -1;
                //try
                //{
                //    id = Convert.ToInt32(request.RestConvention);
                //}
                //catch
                //{
                //}

                //SearchInfo searchinfo = SearchInfo.CreateInstanceFromJSON(request.PostParams);
                //if (searchinfo != null)
                //{
                //    DataAngineSet.Model.person_dataset ds = new DataAngineSet.Model.person_dataset();
                //    ds = person_datasetbll.GetModel(id);
                //    //int num = bll.GetListByTime(searchinfo.StartTime, searchinfo.EndTime, ds.id.ToString()).Tables[0].Rows.Count;
                //    HitAlertData[] ha = HitAlertData.CreateInstanceFromDataAngineDataSet(bll.GetListByTime(searchinfo.StartTime, searchinfo.EndTime, searchinfo.StartIndex, searchinfo.PageSize, ds.id.ToString()));

                //    HitAlertData[] haALL = HitAlertData.CreateInstanceFromDataAngineDataSet(bll.GetListByTime_TaskId(searchinfo.StartTime, searchinfo.EndTime, ds.id.ToString()));
                //    JObject jo = new JObject(new JProperty("num", haALL.Length), new JProperty("pageData", JsonConvert.DeserializeObject(JsonConvert.SerializeObject(ha))));

                //    response.SetContent(JsonConvert.SerializeObject(jo));
                //}       
            }
            else
            {
                Log.Debug("根据图片的轨迹查询");

                string result = Base64Decode(request.PostParams);
                //string result = request.PostParams;
                Trajectory_Search_ByImg trajectory_search = Trajectory_Search_ByImg.CreateInstanceFromJSON(result);
                if (trajectory_search != null)
                {

                    InitFRS();
                    fa.LoadData();
                    fa.ScoreThresh = (float)0.5;
                    Log.Debug(string.Format("阈值:{0}", fa.ScoreThresh));
                    Log.Debug(string.Format("top值:{0}", fa.TopK));
                    FRS.HitAlert[] hits;

                    if (trajectory_search.PicSrc != null)
                    {
                        Bitmap Bitmapsrc = Base64ToImage(trajectory_search.PicSrc);
                        Bitmap bmpsrc = new Bitmap(Bitmapsrc.Width, Bitmapsrc.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                        Graphics.FromImage(bmpsrc).DrawImage(Bitmapsrc, new Rectangle(0, 0, bmpsrc.Width, bmpsrc.Height));
                        hits = fa.Search(bmpsrc);
                        bmpsrc.Dispose();
                    }
                    else
                    {
                        //Image src = Image.FromFile(trajectory_search.PicSrc_Path);
                        Image src = Get_UrlImage(trajectory_search.PicSrc_Path);
                        hits = fa.Search(src);
                    }

                    if (hits == null)
                    {
                        Log.Debug("该图没有人脸");
                        JObject jo = new JObject(new JProperty("num", 0), new JProperty("pageData", null));

                        response.SetContent(JsonConvert.SerializeObject(jo));
                    }
                    else
                    {
                        if (hits[0].Details.Length == 0)
                        {
                            Log.Debug("没有找到该图像对应的人脸");
                            JObject jo = new JObject(new JProperty("num", 0), new JProperty("pageData", null));

                            response.SetContent(JsonConvert.SerializeObject(jo));
                        }
                        else
                        {
                            int UserId = (int)hits[0].Details[0].UserId;
                            Console.WriteLine(UserId);
                            Log.Debug(string.Format("{0}, {1}, {2}, {3}", trajectory_search.StartTime, trajectory_search.EndTime, trajectory_search.StartIndex, trajectory_search.PageSize));

                            System.Data.DataSet a = bll.GetListById(UserId, trajectory_search.StartTime, trajectory_search.EndTime, trajectory_search.StartIndex, trajectory_search.PageSize);

                            Console.WriteLine(a.Tables);

                            HitAlertData_Trajectory_Search[] ha = HitAlertData_Trajectory_Search.CreateInstanceFromDataAngineDataSet(bll.GetListById(UserId, trajectory_search.StartTime, trajectory_search.EndTime, trajectory_search.StartIndex, trajectory_search.PageSize));
                            HitAlertData_Trajectory_Search[] haALL = HitAlertData_Trajectory_Search.CreateInstanceFromDataAngineDataSet(bll.GetListById(UserId, trajectory_search.StartTime, trajectory_search.EndTime));
                            JObject jo = new JObject(new JProperty("num", haALL.Length), new JProperty("pageData", JsonConvert.DeserializeObject(JsonConvert.SerializeObject(ha))));

                            response.SetContent(JsonConvert.SerializeObject(jo));
                        }
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

        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(string result)
        {
            return Base64Decode(Encoding.UTF8, result);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="encodeType">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(Encoding encodeType, string result)
        {
            string decode = string.Empty;
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encodeType.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }

        public static Image Get_UrlImage(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Image img = Image.FromStream(response.GetResponseStream());
            return img;
        }

        /// <summary>
        /// Get时调用
        /// </summary>
        public override void OnGet(HttpRequest request, HttpResponse response)
        {
        }

    }

}
