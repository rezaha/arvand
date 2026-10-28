using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class City
    {
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string NamePersian { get; set; }
        public string NameLatin { get; set; }
        public string Remark { get; set; }
        public virtual Province Province { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<PrayerTime> PrayerTimes { get; set; }
        public virtual ICollection<Weather> Weathers { get; set; }
    }
}
