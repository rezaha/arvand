using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Tender
    {
        public int DIVISION_ID { get; set; }
        public int TENDER_ID { get; set; }
        public int TENDER_TYPE { get; set; }
        public string TENDER_NO { get; set; }
        public string TENDER_DATE { get; set; }
        public int TENDER_STEPS { get; set; }
        public string TENDER_TITLE { get; set; }
        public string TENDER_CONTENT { get; set; }
        public int TENDER_GROUP { get; set; }
        public string SHOW_DATE { get; set; }
        public string EXPIRE_DATE { get; set; }
        public string SELL_FROM_DATE { get; set; }
        public string SELL_TO_DATE { get; set; }
        public Nullable<int> SELL_PRICE { get; set; }
        public string DELIVER_DATE { get; set; }
        public string POCKETS_OPENING_DATE { get; set; }
        public string POCKETS_OPENING_TIME { get; set; }
        public string POCKETS_OPENING_LOCATION { get; set; }
        public Nullable<bool> POCKETS_OPENING_FREE { get; set; }
        public string NEWSPAPER_PRINT { get; set; }
        public string TENDER_FILE_LINK { get; set; }
        public byte[] TENDER_FILE { get; set; }
        public string INSERT_DATE { get; set; }
        public string INSERT_TIME { get; set; }
        public int USER_ID { get; set; }
        public bool ACTIVE { get; set; }
        public string REMARK { get; set; }
        public virtual TendersGroups TENDERS_GROUPS { get; set; }
        public virtual TendersTypes TENDERS_TYPES { get; set; }
    }
}
