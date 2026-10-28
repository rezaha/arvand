using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class TendersGroups
    {
        public TendersGroups()
        {
            this.TENDERS = new List<Tender>();
        }

        public int GROUP_ID { get; set; }
        public string GROUP_NAME { get; set; }
        public string REMARK { get; set; }
        public virtual ICollection<Tender> TENDERS { get; set; }
    }
}
