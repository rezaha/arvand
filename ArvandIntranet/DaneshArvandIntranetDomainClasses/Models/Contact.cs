using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Contact
    {
        public int DIVISION_ID { get; set; }
        public int CONTACT_ID { get; set; }
        public int CONTACT_NO { get; set; }
        public string CONTACT_NAME { get; set; }
        public string CONTACT_POSITION { get; set; }
        public string CONTACT_LOCATION { get; set; }
        public string CONTACT_TEL1 { get; set; }
        public string CONTACT_TEL2 { get; set; }
        public string CONTACT_TEL3 { get; set; }
        public string CONTACT_TEL4 { get; set; }
        public string CONTACT_FAX { get; set; }
        public string CONTACT_EMAIL { get; set; }
        public string CONTACT_WEBSITE { get; set; }
        public string CONTACT_ADDRESS { get; set; }
        public bool ACTIVE { get; set; }
        public string REMARK { get; set; }
    }
}
