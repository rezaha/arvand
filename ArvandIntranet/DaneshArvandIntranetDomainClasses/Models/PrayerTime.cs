using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class PrayerTime
    {
        public int PrayerId { get; set; }
        public int CityId { get; set; }
        public string PrayerDate { get; set; }
        public string MorningPrayer { get; set; }
        public string Sunrise { get; set; }
        public string NoonPrayer { get; set; }
        public string Sunset { get; set; }
        public string MaghribPrayer { get; set; }
        public string MidNight { get; set; }
        public string Remark { get; set; }
        public virtual City City { get; set; }
    }
}
