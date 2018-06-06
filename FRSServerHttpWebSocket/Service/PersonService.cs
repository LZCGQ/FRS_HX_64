using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FRSServerHttp.Server;
using DataAngineSet.BLL;
using FRSServerHttp.Model;
using Newtonsoft.Json;
using FRS;
using System.Drawing;
using System.IO;
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
                string result = Base64Decode(request.PostParams);
                RegisterSingleInfo registersingleinfo = RegisterSingleInfo.CreateInstanceFromJSON(result);
                usr.personDatasetId = id;
                usr.name = registersingleinfo.Name;
                usr.gender = registersingleinfo.Gender;
                usr.cardId = registersingleinfo.CardId;

                
                //初始化                   
                InitFRS();
                //Console.WriteLine("TEST1!");
                //Bitmap Bitmapsrc = Base64ToImage(registersingleinfo.PicSrc);
                //Console.WriteLine("TEST2!");
                //Bitmap bmpsrc = new Bitmap(Bitmapsrc.Width, Bitmapsrc.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                //Console.WriteLine("TEST3!");
                //Graphics.FromImage(bmpsrc).DrawImage(Bitmapsrc, new Rectangle(0, 0, bmpsrc.Width, bmpsrc.Height));

                //Console.WriteLine("TEST4!");

                int statusnum = fa.Register(registersingleinfo.PicSrc, usr);
                //int statusnum = fa.Register("E:/phpStudy/PHPTutorial/WWW/hisense/data/upload/portal/20180408/5ac9be9e264b5.jpg", usr);
                Console.WriteLine(statusnum);
                if (statusnum == 0)
                {
                    status = true;
                    Log.Debug(string.Format("注册成功"));
                }

                response.SetContent(statusnum.ToString());
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
                    //int num = personbll.DataTableToList(personbll.GetList_Library(DatasetId.ToString()).Tables[0]).Count;
                    PersonData[] users = PersonData.CreateInstanceFromDataAngineDataSet(personbll.GetList(viewinfo.StartIndex, viewinfo.PageSize, DatasetId.ToString()));
                    response.SetContent(JsonConvert.SerializeObject(users));
                }
                else
                {
                    int DatasetId = Convert.ToInt32(request.RestConvention);
                    int num = personbll.DataTableToList(personbll.GetList_Library(DatasetId.ToString()).Tables[0]).Count;
                    response.SetContent(num.ToString());
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
