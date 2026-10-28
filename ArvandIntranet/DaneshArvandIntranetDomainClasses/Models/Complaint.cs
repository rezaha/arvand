using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Complaint
    {
        public int COMPLAINT_ID { get; set; }
        public int COMPLAINT_NO { get; set; }
        public string SENDER_NAME { get; set; }
        public string SENDER_COMPANY { get; set; }
        public string SENDER_TEL { get; set; }
        public string SENDER_FAX { get; set; }
        public string SENDER_EMAIL { get; set; }
        public int SUBSCRIPTION_NO { get; set; }
        public int DRAFT_NO { get; set; }
        public string DRAFT_ISSUE_DATE { get; set; }
        public string DELIVERY_DATE { get; set; }
        public Nullable<int> PRODUCT_ID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_GRADE { get; set; }
        public int COMPLAINT_TYPE { get; set; }
        public string COMPLAINT_DESCRIPTION { get; set; }
        public int RECIEVER_ID { get; set; }
        public bool COMPLAINT_READ { get; set; }
        public bool ACTIVE { get; set; }
        public string REMARK { get; set; }
    }
}
