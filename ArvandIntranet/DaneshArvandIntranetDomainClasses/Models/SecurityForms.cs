using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class SecurityForms
    {
       

        public int FormPermisionId { get; set; }
        public int ListOrder { get; set; }
        public int SubSystemId { get; set; }
        public string FormTag { get; set; }
        public string FormName { get; set; }
        public string FormTitle { get; set; }
        public int TabNo { get; set; }
        public string TabName { get; set; }
        public string TabTitle { get; set; }
        public bool InsertRecord { get; set; }
        public bool DeleteRecord { get; set; }
        public bool UpdateRecord { get; set; }
        public bool SearchRecord { get; set; }
        public bool PrintRecord { get; set; }
        public bool ApproveAction { get; set; }
        public bool EtcAction { get; set; }
        public bool EtcAction2 { get; set; }
        public virtual ICollection<SecurityFormsGranted> SecurityFormGranteds { get; set; }
    }
}
