using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Opinion
    {
        public int OPINION_ID { get; set; }
        public string PART_TYPE { get; set; }
        public int PART_ID { get; set; }
        public string OPINION_DATE { get; set; }
        public string OPINION_TIME { get; set; }
        public string OPINION_NAME { get; set; }
        public string OPINION_COMPANY { get; set; }
        public string OPINION_TEL { get; set; }
        public string OPINION_EMAIL { get; set; }
        public string OPINION_SUBJECT { get; set; }
        public string OPINION_CONTENT { get; set; }
        public Nullable<int> OPINION_RECIEVER { get; set; }
        public bool OPINION_SEND { get; set; }
        public bool ADMIN_READ { get; set; }
        public bool ADMIN_APPROVE { get; set; }
        public bool ADMIN_DELETE { get; set; }
        public string REMARK { get; set; }
    }
}
