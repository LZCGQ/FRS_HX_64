using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAngineTest
{
    class Program
    {
        static void userAddTest()
        {
            DataAngineSet.BLL.person personbll = new DataAngineSet.BLL.person();
            DataAngineSet.Model.person usr = new DataAngineSet.Model.person();
            usr.card_id = "32145123451";
            usr.face_image_path = "E:/11i.jpg";
            usr.feature_data = new byte[2048];
            usr.gender = "nan";
            usr.person_dataset_id = 1;
            usr.type = "2";
            usr.quality_score = 80;
            personbll.Add(usr);
        }

        //static void libraryAddTest()
        //{
        //    DataAngine.BLL.table tablebll = new DataAngine.BLL.table();
        //    DataAngine.Model.table table = new DataAngine.Model.table();
        //    table.name = "test";

        //    tablebll.Add(table);
        //}
        static void hitrecordAddTest()
        {
            DataAngineSet.BLL.hitrecord habll = new DataAngineSet.BLL.hitrecord();
            DataAngineSet.Model.hitrecord hit = new DataAngineSet.Model.hitrecord();
            hit.threshold = (Decimal)0.6f;
            hit.face_query_image_path = "D:/1.jpg";
            hit.occur_time = DateTime.Now;
            habll.Add(hit);

        }
        static void hitalertAddTest()
        {

            DataAngineSet.BLL.hitalert habll = new DataAngineSet.BLL.hitalert();
            DataAngineSet.Model.hitrecord_detail hd1 = new DataAngineSet.Model.hitrecord_detail();
            DataAngineSet.Model.hitrecord_detail hd2 = new DataAngineSet.Model.hitrecord_detail();
            DataAngineSet.Model.hitalert ha = new DataAngineSet.Model.hitalert();
            DataAngineSet.Model.hitrecord hit = new DataAngineSet.Model.hitrecord();
            hit.threshold = (Decimal)0.6f;
            hit.face_query_image_path = "D:/1.jpg";
            hit.occur_time = DateTime.Now;
            hd1.rank = 1;
            hd1.score = (Decimal)0.867f;
            hd2.user_id = 1;
            hd2.rank = 2;
            hd2.score = (Decimal)0.8f;
            hd2.user_id = 1;
            ha.details = new DataAngineSet.Model.hitrecord_detail[2];
            ha.details[0] = hd1;
            ha.details[1] = hd2;
            ha.hit = hit;
            habll.Add(ha);

        }
        static void Main(string[] args)
        {
            userAddTest();
            //hitalertAddTest();
        }
    }
}
