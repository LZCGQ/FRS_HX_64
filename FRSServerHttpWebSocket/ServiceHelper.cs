using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRSServerHttp.Service;

namespace FRSServerHttp
{
    /// <summary>
    /// 工厂类，根据url 返回不同的服务
    /// </summary>
    class ServiceHelper
    {
      
       /// <summary>
       /// 根据Domain查找服务
       /// </summary>
       /// <param name="url"></param>
       /// <returns>null表示查找失败</returns>
        public static BaseService GetService(string domain)
       {


           if (HitAlertService.Domain == domain)
           {
               return new HitAlertService();
           }
           else if (SurveillanceTaskService.Domain == domain)
           {
               return new SurveillanceTaskService();
           }
           else if (DeviceService.Domain == domain)
           {
               return new DeviceService();
           }        
           else if (RecordingService.Domain == domain)
           {
               return new RecordingService();
           }
           else if (HitrecordService.Domain == domain)
           {
               return new HitrecordService();
           }
           else if (PersonDataSetService.Domain == domain)
           {
               return new PersonDataSetService();
           }
           else if (VerifyingService.Domain == domain)
           {
               return new VerifyingService();
           }
           else if (PersonService.Domain == domain)
           {
               return new PersonService();
           }
           else if (SurveillanceTaskTypeService.Domain == domain)
           {
               return new SurveillanceTaskTypeService();
           }
           else if (DevicePlacetypeService.Domain == domain)
           {
               return new DevicePlacetypeService();
           }
           else if (RecordingByImgService.Domain == domain)
           {
               return new RecordingByImgService();
           }

           return null;
       }

    }
}
