using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class ContactUs
    {
        public int DIVISION_ID { get; set; }
        public int CONTACT_ID { get; set; }
        public int CONTACT_TYPE { get; set; }
        public string CONTACT_NAME { get; set; }
        public string CONTACT_EMAIL { get; set; }
        public string CONTACT_SUBJECT { get; set; }
        public string CONTACT_TEXT { get; set; }
        public string CONTACT_DATE { get; set; }
        public string CONTACT_TIME { get; set; }
        public bool IS_READ { get; set; }
        public bool IS_DELETE { get; set; }
    }
}
