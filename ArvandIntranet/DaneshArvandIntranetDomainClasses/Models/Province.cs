using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Province
    {
        public Province()
        {
            this.CITIES = new List<City>();
        }

        public int COUNTRY_ID { get; set; }
        public int PROVINCE_ID { get; set; }
        public string NAME_PERSIAN { get; set; }
        public string NAME_LATIN { get; set; }
        public string REMARK { get; set; }
        public virtual ICollection<City> CITIES { get; set; }
        public virtual Country COUNTRy { get; set; }
    }
}
