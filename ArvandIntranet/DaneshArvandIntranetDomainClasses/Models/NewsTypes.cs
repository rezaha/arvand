using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class NewsTypes
    {
        public NewsTypes()
        {
            this.News = new List<News>();
        }

        public int TypeId { get; set; }
        public int TypeNo { get; set; }
        public string NamePersian { get; set; }
        public string NameLatin { get; set; }
        public string Remark { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}
