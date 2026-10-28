using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class MasterpageWebparts
    {
        public int MASTERPAGE_WEBPART { get; set; }
        public int MASTERPAGE_ID { get; set; }
        public int WEBPART_ID { get; set; }
        public int ROW_NO { get; set; }
        public int COL_NO { get; set; }
        public int COL_ORDER { get; set; }
        public bool COLLAPSE_OPTION { get; set; }
        public bool MOVE_OPTION { get; set; }
        public bool DELETE_OPTION { get; set; }
        public string REMARK { get; set; }
        public virtual Masterpage MASTERPAGE { get; set; }
        public virtual Webpart WEBPART { get; set; }
    }
}
