using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Personnel
    {
        public int PERSON_ID { get; set; }
        public long PERSON_NO { get; set; }
        public bool SEX_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string FATHER_NAME { get; set; }
        public string BIRTH_DATE { get; set; }
        public Nullable<long> BIRTH_CERT_ID { get; set; }
        public string NATIONAL_ID { get; set; }
        public int CERTIFICATE_ID { get; set; }
        public int EMP_TYPE { get; set; }
        public string EMP_DATE { get; set; }
        public int POSITION_ID { get; set; }
        public bool ACTIVE { get; set; }
        public string REMARK { get; set; }
    }
}
