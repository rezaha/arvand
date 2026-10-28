using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Weather
    {
        public int WEATHER_ID { get; set; }
        public int WEATHER_CITY { get; set; }
        public Nullable<int> WEATHER_CODE { get; set; }
        public bool CITY_DEFAULT { get; set; }
        public int SHOW_TYPE { get; set; }
        public string WEATHER_HTML { get; set; }
        public bool ACTIVE { get; set; }
        public string REMARK { get; set; }
        public virtual City CITy { get; set; }
    }
}
