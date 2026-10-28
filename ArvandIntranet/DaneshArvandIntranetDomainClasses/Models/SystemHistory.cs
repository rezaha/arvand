using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class SystemHistory 
    {
        public int HistoryId { get; set; }
        public int? DivisionId { get; set; }
        public string FormName { get; set; }
        public string TableName { get; set; }
        public string ActionName { get; set; }
        public int LoginUserId { get; set; }
        public string LoginUserName { get; set; }
        public string ActionDate { get; set; }
        public string ActionTime { get; set; }
        public string OsUser { get; set; }
        public string OsName { get; set; }
        public string IpAddress { get; set; }
        public string BrowserType { get; set; }
        public int? ParentHistoryId { get; set; }
        public string Remark { get; set; }
        public string XmlDate { get; set; }

        public virtual PlantDivisions PlantDivisions { get; set; }
        public virtual SystemHistory ParentHistory { get; set; }
        public virtual ICollection<SystemHistory> SystemHistorys { get; set; }
    }
}
