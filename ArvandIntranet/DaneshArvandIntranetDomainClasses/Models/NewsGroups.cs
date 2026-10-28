using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class NewsGroups
    {
        public NewsGroups()
        {
            this.NEWS = new List<News>();
        }

        public int GROUP_ID { get; set; }
        public int GROUP_NO { get; set; }
        public string NAME_PERSIAN { get; set; }
        public string NAME_LATIN { get; set; }
        public string REMARK { get; set; }
        public virtual ICollection<News> NEWS { get; set; }
    }
}
