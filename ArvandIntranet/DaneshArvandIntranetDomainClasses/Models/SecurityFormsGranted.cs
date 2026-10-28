using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class SecurityFormsGranted
    {
        public int UserId { get; set; }
        public int FormPermission { get; set; }
        public bool InsertRecord { get; set; }
        public bool DeleteRecord { get; set; }
        public bool UpdateRecord { get; set; }
        public bool SearchRecord { get; set; }
        public bool PrintRecord { get; set; }
        public bool ApproveAction { get; set; }
        public bool EtcAction { get; set; }
        public bool EtcAction2 { get; set; }
        public virtual SecurityForms SecurityForm { get; set; }
        public virtual SecurityUsers SecurityUser { get; set; }
    }
}
