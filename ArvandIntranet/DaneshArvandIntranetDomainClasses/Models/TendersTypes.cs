using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class TendersTypes
    {
        public TendersTypes()
        {
            this.TENDERS = new List<Tender>();
        }

        public int TYPE_ID { get; set; }
        public string TYPE_NAME { get; set; }
        public string REMARK { get; set; }
        public virtual ICollection<Tender> TENDERS { get; set; }
    }
}
