using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Resume
    {
        public int RESUME_ID { get; set; }
        public bool SEX_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string FATHER_NAME { get; set; }
        public string BIRTH_DATE { get; set; }
        public Nullable<long> BIRTH_CERT_ID { get; set; }
        public string NATIONAL_ID { get; set; }
        public bool MARRIED { get; set; }
        public int MILITARY_TYPE { get; set; }
        public double DIPLOMA_AVERAGE { get; set; }
        public int CERTIFICATE_LEVEL { get; set; }
        public string UNIVERSITY { get; set; }
        public int CERTIFICATE { get; set; }
        public double CERTIFICATE_AVERAGE { get; set; }
        public string TEL_NO { get; set; }
        public string MOBILE_NO { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public string ADDRESS { get; set; }
        public int PETROCHEMICAL_EXPERIENCE { get; set; }
        public int USER_QUOTA { get; set; }
        public string RESUME_FILE_ADDRESS { get; set; }
        public string RESUME_FILE_ADDRESS1 { get; set; }
        public string RESUME_FILE_ADDRESS2 { get; set; }
        public string RESUME_FILE_ADDRESS3 { get; set; }
        public string RESUME_FILE_ADDRESS4 { get; set; }
        public string RESUME_FILE_ADDRESS5 { get; set; }
        public string RESUME_FILE_ADDRESS6 { get; set; }
        public string RESUME_FILE_ADDRESS7 { get; set; }
        public string RESUME_FILE_ADDRESS8 { get; set; }
        public string INSERT_DATE { get; set; }
        public string INSERT_TIME { get; set; }
        public string TRACKING_CODE { get; set; }
        public Nullable<int> SEAT_NO { get; set; }
        public Nullable<int> BIDS_NO { get; set; }
        public Nullable<bool> GENDER_ACCEPT { get; set; }
        public Nullable<bool> CERT_ACCEPT { get; set; }
        public Nullable<bool> AGE_ACCEPT { get; set; }
        public bool RESUME_READ { get; set; }
        public bool RESUME_ACCEPT { get; set; }
        public string REMARK { get; set; }
    }
}
