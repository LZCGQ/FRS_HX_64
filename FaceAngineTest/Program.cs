using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FRS;
using System.IO;
namespace FaceAngineTest
{
    class Program
    {
        static List<string> list = new List<string>();

        static  void RegisterOneFinised(int count, string msg)
        {
            Console.WriteLine(count + "，" + msg);
        }
         static void InitFRS()
        {
            //            System.Console.WriteLine(System.Environment.CurrentDirectory);
            FRSParam param = new FRSParam();

            param.nMinFaceSize = 50;
            param.nRollAngle = 10;
            param.bOnlyDetect = true;

            FaceImage.Create(1, param);
            Feature.Init(1);
        }
        static void RegisterTest()
        {
            InitFRS();
            FeatureData fa = new FeatureData();
            fa.RegisterOneFinisedEvent += new FeatureData.RegisterOneFinisedCallback(RegisterOneFinised);
            Image image=Image.FromFile("G:/科研项目/新街口/三逃底库/NGL/njust14.jpg");
            UserInfo userinfo=new UserInfo ();
            userinfo.cardId="321342";

            userinfo.imgPath = "G:/科研项目/新街口/三逃底库/NGL/njust14.jpg";
            userinfo.name="pkj";
            userinfo.gender = "M";
            userinfo.type = "2";
            userinfo.personDatasetId = 1;
            fa.Register(image, userinfo);
            
        }
        static void SearchTest()
        {
            InitFRS();
            FeatureData fa = new FeatureData();
            fa.LoadData(1);
            Image image = Image.FromFile("G:/科研项目/新街口/三逃底库/NGL/njust14.jpg");
            HitAlert[] hits = fa.Search(image);
            Console.WriteLine("find result:"+hits.Length);
            //getPath("D:/Users/McLarry/Downloads/测试库1(101)/测试库1(100)/测试图像");
            //foreach (string filename in list)
            //{
            //    Console.WriteLine(filename);
            //    Image image = Image.FromFile(filename);
            //    Console.WriteLine("aaa");
            //    HitAlert[] hits = fa.Search(image);
            //    Console.WriteLine("bbb");
            //    //Console.WriteLine(hits[0].Details.Length); 
            //    //Console.WriteLine(hits[0].Details[0].Score);
            //}                        
        }

        public static List<string> getPath(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles();
            DirectoryInfo[] dii = dir.GetDirectories();
            foreach (FileInfo f in fil)
            {
                list.Add(f.FullName);//添加文件的路径到列表
            }
            ////获取子文件夹内的文件列表，递归遍历
            //foreach (DirectoryInfo d in dii)
            //{
            //    getPath(d.FullName);
            //    list.Add(d.FullName);//添加文件夹的路径到列表
            //}
            return list;
        }

        static void bytetest()
        {
            InitFRS();
            FeatureData fa = new FeatureData();
            fa.LoadData(1);
            Bitmap bitmap = new Bitmap("D:\\test.jpg");
            byte[] b = BitmapToBytes(bitmap);
            Console.WriteLine(BitConverter.ToString(b));
           
            Bitmap Bitmapsrc = BytesToBitmap(b);
            Bitmapsrc.Save("D:\\test1.jpg");
            Bitmap bitmaptest = new Bitmap("D:\\test1.jpg");
            fa.LoadData(2);
            FRS.HitAlert[] hits = fa.Search(bitmaptest);
            
            Console.WriteLine(hits[0].Details[0].Score);
           
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


        public static byte[] BitmapToBytes(Bitmap Bitmap)
        {
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream();
                Bitmap.Save(ms, Bitmap.RawFormat);
                byte[] byteImage = new Byte[ms.Length];
                byteImage = ms.ToArray();
                return byteImage;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            finally
            {
                ms.Close();
            }
        }  

        static void Main(string[] args)
        {
            //RegisterTest();
            bytetest();
            Console.WriteLine("执行完毕");
            Console.ReadLine();
        }
    }
}
