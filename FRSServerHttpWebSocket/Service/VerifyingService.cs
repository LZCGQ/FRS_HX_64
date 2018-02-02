﻿using DataAngineSet.BLL;
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
            //Log.Debug("比较图片");
        }

        /// <summary>
        /// Post时调用
        /// </summary>
        public override void OnPost(HttpRequest request, HttpResponse response)
        {
            bool status = false;

            Log.Debug("比较图片");

            //OneVsOne
            if (request.RestConvention == "0")
            {
                //http://127.0.0.1:8080/v1/verify/0
                VerifyOneVsOne verify = VerifyOneVsOne.CreateInstanceFromJSON(request.PostParams);
                if (verify != null)
                {
                    Bitmap Bitmapsrc = Base64ToImage(verify.PicSrc);
                    Bitmap Bitmapdst = Base64ToImage(verify.PicDst);

                    Bitmap bmpsrc = new Bitmap(Bitmapsrc.Width, Bitmapsrc.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    Graphics.FromImage(bmpsrc).DrawImage(Bitmapsrc, new Rectangle(0, 0, bmpsrc.Width, bmpsrc.Height));

                    Bitmap bmpdst = new Bitmap(Bitmapdst.Width, Bitmapdst.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    Graphics.FromImage(bmpdst).DrawImage(Bitmapdst, new Rectangle(0, 0, bmpdst.Width, bmpdst.Height));

                    Bitmapsrc.Save("Bitmapsrc.jpg");
                    Bitmapdst.Save("Bitmapdst.jpg");
               
                    //初始化                   
                    InitFRS();
                    double score = fa.Compare(bmpsrc, bmpdst);

                    response.SetContent(JsonConvert.SerializeObject(score));
                    //response.SetContent("0.8");
                    bmpsrc.Dispose();
                    bmpdst.Dispose();
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

                    // 获取Post的阈值和top值
                    double ScoreThresh = Convert.ToDouble(verify.ScoreThresh);
                    int TopK = Convert.ToInt32(verify.TopK);

                    Bitmap Bitmapsrc = Base64ToImage(verify.PicSrc);
                    Bitmap bmpsrc = new Bitmap(Bitmapsrc.Width, Bitmapsrc.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    Graphics.FromImage(bmpsrc).DrawImage(Bitmapsrc, new Rectangle(0, 0, bmpsrc.Width, bmpsrc.Height));
                    Bitmapsrc.Save("Bitmapsrc.jpg");
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

                    FRS.HitAlert[] hits = fa.Search(bmpsrc);
                    string msg = JsonConvert.SerializeObject(Model.HitAlert.CreateInstanceFromFRSHitAlert(hits));
                    response.SetContent(msg);
                    bmpsrc.Dispose();
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
