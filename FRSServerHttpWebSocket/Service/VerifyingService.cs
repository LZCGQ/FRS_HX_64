using DataAngineSet.BLL;
using FRSServerHttp.Model;
using FRSServerHttp.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            //Log.Debug("比较图片");
        }

        /// <summary>
        /// Post时调用
        /// </summary>
        public override void OnPost(HttpRequest request, HttpResponse response)
        {
            bool status = false;

            //OneVsOne
            if (request.RestConvention == "0")
            {
                Log.Debug("比较图片");
                //http://127.0.0.1:8080/v1/verify/0      
                //VerifyOneVsOne verify = VerifyOneVsOne.CreateInstanceFromJSON(request.PostParams);
                string result = Base64Decode(request.PostParams);
                VerifyOneVsOne verify = VerifyOneVsOne.CreateInstanceFromJSON(result);
                if (verify != null)
                {
                    double score = 0;
                    //初始化                   
                    InitFRS();
                    if (verify.PicSrc != null && verify.PicDst != null)
                    {
                        Bitmap Bitmapsrc = Base64ToImage(verify.PicSrc);
                        Bitmap Bitmapdst = Base64ToImage(verify.PicDst);

                        Bitmap bmpsrc = new Bitmap(Bitmapsrc.Width, Bitmapsrc.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                        Graphics.FromImage(bmpsrc).DrawImage(Bitmapsrc, new Rectangle(0, 0, bmpsrc.Width, bmpsrc.Height));

                        Bitmap bmpdst = new Bitmap(Bitmapdst.Width, Bitmapdst.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                        Graphics.FromImage(bmpdst).DrawImage(Bitmapdst, new Rectangle(0, 0, bmpdst.Width, bmpdst.Height));

                        Bitmapsrc.Save("Bitmapsrc.jpg");
                        Bitmapdst.Save("Bitmapdst.jpg");
                        
                        score = fa.Compare(bmpsrc, bmpdst);
                        bmpsrc.Dispose();
                        bmpdst.Dispose();
                    }
                    else
                    {
                        Image src = Image.FromFile(verify.PicSrc_Path);
                        Image dst = Image.FromFile(verify.PicDst_Path);
                        score = fa.Compare(src, dst);
                    }
               
                   
                    Log.Debug(string.Format("相似度:{0}", score));
                    response.SetContent(JsonConvert.SerializeObject(score));
                    //response.SetContent("0.8");
                    
                }

            }
            else
            {
                Log.Debug("查找图片");
                //VerifyOneVsN verify = VerifyOneVsN.CreateInstanceFromJSON(request.PostParams);
                string result = Base64Decode(request.PostParams);
                VerifyOneVsN verify = VerifyOneVsN.CreateInstanceFromJSON(result);
                if (verify != null)
                {
                    int DatasetId = Convert.ToInt32(request.RestConvention);
                    DataAngineSet.Model.person_dataset ds = new DataAngineSet.Model.person_dataset();
                    ds = bll.GetModel(DatasetId);

                    // 获取Post的阈值和top值
                    double ScoreThresh = Convert.ToDouble(verify.ScoreThresh);
                    int TopK = Convert.ToInt32(verify.TopK);

                    if (ScoreThresh == 0)
                        ScoreThresh = 0.6;
                    if (TopK == 0)
                        TopK = 3;


                    //初始化                   
                    InitFRS();
                    fa.LoadData(DatasetId);

                    Log.Debug(string.Format("初始阈值:{0}", fa.ScoreThresh));
                    Log.Debug(string.Format("初始top值:{0}", fa.TopK));

                    // 设置阈值和top值
                    fa.ScoreThresh = (float)ScoreThresh;
                    fa.TopK = TopK;

                    Log.Debug(string.Format("设置阈值:{0}", fa.ScoreThresh));
                    Log.Debug(string.Format("设置top值:{0}", fa.TopK));

                    FRS.HitAlert[] hits;
                    if (verify.PicSrc != null)
                    {

                        Bitmap Bitmapsrc = Base64ToImage(verify.PicSrc);
                        Bitmap bmpsrc = new Bitmap(Bitmapsrc.Width, Bitmapsrc.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                        Graphics.FromImage(bmpsrc).DrawImage(Bitmapsrc, new Rectangle(0, 0, bmpsrc.Width, bmpsrc.Height));
                        //Bitmapsrc.Save("Bitmapsrc.jpg");


                        hits = fa.Search(bmpsrc);
                        bmpsrc.Dispose();
                    }
                    else
                    {
                         Image src = Image.FromFile(verify.PicSrc_Path);
                        hits = fa.Search(src);
                    }
                    string msg = JsonConvert.SerializeObject(Model.HitAlert.CreateInstanceFromFRSHitAlert(hits));
                    if(hits==null)
                    {
                        JObject jo = new JObject(new JProperty("num", 0));
                        response.SetContent(JsonConvert.SerializeObject(jo));
                    }
                    response.SetContent(msg);
                    
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
        /// Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string Base64Encode(string source)
        {
            return Base64Encode(Encoding.UTF8, source);
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="encodeType">加密采用的编码方式</param>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string Base64Encode(Encoding encodeType, string source)
        {
            string encode = string.Empty;
            byte[] bytes = encodeType.GetBytes(source);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = source;
            }
            return encode;
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
        

    }
}
