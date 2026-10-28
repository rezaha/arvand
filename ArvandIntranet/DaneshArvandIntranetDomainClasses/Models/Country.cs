using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Country
    {
        public Country()
        {
            this.PROVINCES = new List<Province>();
        }

        public int COUNTRY_ID { get; set; }
        public string NAME_PERSIAN { get; set; }
        public string NAME_LATIN { get; set; }
        public string REMARK { get; set; }
        public virtual ICollection<Province> PROVINCES { get; set; }
    }
}
